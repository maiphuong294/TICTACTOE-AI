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
    Opponent
}
public class GameplayManager : MonoBehaviour
{
    public static GameplayManager Instance { get; private set; }
    public EMode Mode { get; private set; }
    public ELevel Level { get; private set; }
    public ETurn Turn { get; private set; }

    public Line linePrefab;
    public void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        Mode = EMode.PvP;
        Turn = ETurn.Player;
    }

    #region CHECK ENDGAME

    public async void CheckEndGame(Cell cell)
    {
        bool check = false;
        if (CheckWin(cell)) check = true;      
        if (CheckTie()) check = true;

        if (check)
        {
            print("NEXT LEVEL");
            await Task.Delay(400);
            ResetLevel();
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
        DrawLine(ELine.Vertical, Board.Instance.Cells[2, cell.Column].transform.position);
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
        DrawLine(ELine.Horizontal, Board.Instance.Cells[cell.Row, 2].transform.position);
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
        DrawLine(ELine.Cross1, Board.Instance.Cells[2,2].transform.position);
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
        DrawLine(ELine.Cross2, Board.Instance.Cells[2, 2].transform.position);
        return true;
    }
    #endregion

    public void HandlePickCell(Cell cell)
    {
        if (Mode == EMode.PvP)
        {
            if (cell.IsHaveSign() == true) return;
            MakeAMove(cell);
        }
        if (Mode == EMode.PvE)
        {
            if (cell.IsHaveSign() == false) return;
            if (Turn == ETurn.Opponent) return;
            MakeAMove(cell);
        }
    }
    public void MakeAMove(Cell cell)
    {
        if (Turn == ETurn.Player)
        {
            cell.DrawSign(ESign.X);
        }
        else cell.DrawSign(ESign.O);
        TurnBase();
        CheckEndGame(cell);
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
    }

    public void DrawLine(ELine type, Vector3 position)
    {
        Line line = Instantiate(linePrefab, transform);
        line.SetPosition(position);
        line.Draw(type);
    }

    public void ResetLevel()
    {
        Utils.DestroyAllChildren(gameObject);
        Board.Instance.ResetBoard();
        Turn = ETurn.Player;
    }
}
