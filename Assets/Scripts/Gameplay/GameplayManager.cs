using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
public enum EMode
{
    PvP,
    PvE
}

public enum ELevel
{
    Easy,
    Medium,
    Hard
}

public enum ETurn
{
    Player,
    Opponent,
    Null
}
public class GameplayManager : MonoBehaviour
{
    public static GameplayManager Instance { get; private set; }
    public EMode Mode;
    public ELevel Level;
    public ETurn Turn;

    public ETurn Winner;

    public Line linePrefab;
    public bool IsPlaying;
    public void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        Input.multiTouchEnabled = false;
        Application.targetFrameRate = 60;
        Application.lowMemory += () => GC.Collect();

        Mode = EMode.PvE;
        Turn = ETurn.Player;
        Level = ELevel.Hard;
        UIManager.Instance.SetTurnUI(Turn);
        IsPlaying = false;
        Winner = ETurn.Null;

    }

    #region CHECK ENDGAME

    public async void CheckEndGame(Cell cell)
    {
        bool check = false;
        if (CheckWin(cell))
        {
            Winner = Turn;
            check = true;
        }
        else
        {
            if (CheckTie())
            {
                Winner = ETurn.Null;
                check = true;
            }
        }
        
        if (check)
        {
            IsPlaying = false;
            print("NEXT LEVEL");
            await Task.Delay(600);
            Messenger.FireEvent(EventKey.OnEndGame, Winner, Mode);
        }

    }
    public bool CheckWin(Cell cell)
    {
        bool check = false;
        if(CheckVerticle(cell)) check = true;    
        if(CheckHorizontal(cell)) check = true;
        if(CheckCross1(cell)) check = true;
        if(CheckCross2(cell)) check = true;
        if (check) print("WIN");
        return check;
    }

    public bool CheckTie()
    {
        if (Board.Instance.CheckFull())
        {
            print("GAME TIE");
            return true;
        }
        return false;
    }

    public bool CheckVerticle(Cell cell)
    {
        for (int i = 1; i <= 3; i++)
        {
            if (Board.Instance.Cells[i, cell.Column].IsHaveSign() == false|| cell.IsHaveSign() == false) return false;
            if (Board.Instance.Cells[i, cell.Column].sign.eSign != cell.sign.eSign)
            {
                return false;
            }
        }
        if (cell.sign.eSign == ESign.X)
        {
            DrawLine(ELine.Vertical, Board.Instance.Cells[2, cell.Column].transform.position, ETurn.Player);
        }else DrawLine(ELine.Vertical, Board.Instance.Cells[2, cell.Column].transform.position, ETurn.Opponent);

        return true;
    }

    public bool CheckHorizontal(Cell cell)
    {
        for (int i = 1; i <= 3; i++)
        {
            if (Board.Instance.Cells[cell.Row, i].IsHaveSign() == false || cell.IsHaveSign() == false) return false;
            if (Board.Instance.Cells[cell.Row, i].sign.eSign != cell.sign.eSign)
            {
                return false;
            }
        }
        if (cell.sign.eSign== ESign.X)
        {
            DrawLine(ELine.Horizontal, Board.Instance.Cells[cell.Row, 2].transform.position, ETurn.Player);
        }else DrawLine(ELine.Horizontal, Board.Instance.Cells[cell.Row, 2].transform.position, ETurn.Opponent);

        return true;
    }

    public bool CheckCross1(Cell cell)
    {
        if (cell.Row != cell.Column) return false;
        for (int i = 1; i <= 3; i++)
        {
            if (Board.Instance.Cells[i, i].IsHaveSign() == false) return false;
            if (Board.Instance.Cells[i, i].sign.eSign != cell.sign.eSign)
            {
                return false;
            }
        }
        if (cell.sign.eSign == ESign.X)
        {
            DrawLine(ELine.Cross1, Board.Instance.Cells[2, 2].transform.position, ETurn.Player);
        }else DrawLine(ELine.Cross1, Board.Instance.Cells[2, 2].transform.position, ETurn.Opponent);

        return true;
    }
    public bool CheckCross2(Cell cell)
    {
        if (cell.Row != 4 - cell.Column) return false;
        for (int i = 1; i <= 3; i++)
        {
            if (Board.Instance.Cells[i, 4 - i].IsHaveSign() == false) return false;
            if (Board.Instance.Cells[i, 4 - i].sign.eSign != cell.sign.eSign)
            {
                return false;
            }
        }
        if (cell.sign.eSign == ESign.X)
        {
            DrawLine(ELine.Cross2, Board.Instance.Cells[2, 2].transform.position, ETurn.Player);
        }else DrawLine(ELine.Cross2, Board.Instance.Cells[2, 2].transform.position, ETurn.Opponent);

        return true;
    }
    #endregion

    public void HandlePickCell(Cell cell)
    {
        if (IsPlaying == false) return;
        if (Mode == EMode.PvP)
        {
            if (cell.IsHaveSign() == true) return;
            MakeAMove(cell);
        }
        if (Mode == EMode.PvE)
        {
            if (Turn == ETurn.Opponent) return;
            if (cell.IsHaveSign() == true) return;        
            MakeAMove(cell);
            if (IsPlaying == false) return;
            Bot.Instance.DoBestMove(Level);
        }
    }
    public void MakeAMove(Cell cell)
    {
        if (Turn == ETurn.Player)
        {
            cell.DrawSign(ESign.X);
        }
        else cell.DrawSign(ESign.O);
        CheckEndGame(cell);
        if (Winner != ETurn.Null)
        {
            return;
        }
        TurnBase();
        
    }

    public void TurnBase()
    {
        if (Turn == ETurn.Player)
        {
            Turn = ETurn.Opponent;
        }
        else
        {
            Turn = ETurn.Player;
        }
        UIManager.Instance.SetTurnUI(Turn);
    }

    public void DrawLine(ELine type, Vector3 position, ETurn winner)
    {
        Line line = Instantiate(linePrefab, transform);
        line.SetPosition(position);
        line.SetDirection(type);
        line.SetColor(winner);
        line.Draw(type);
    }

    public void ResetLevel()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        Board.Instance.ResetBoard();
        Turn = ETurn.Player;
        UIManager.Instance.SetTurnUI(Turn);
        IsPlaying = true;
        Winner = ETurn.Null;
    }

    public void ClearLevel()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        Board.Instance.ResetBoard();
    }
}
