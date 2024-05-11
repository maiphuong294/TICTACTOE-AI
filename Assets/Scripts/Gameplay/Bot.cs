using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public enum EResult
{
    Player = -10,
    AI = +10,
    Tie = 0,
    Null = -99
}

public class Bot : MonoBehaviour
{
    public static Bot Instance { get; private set; }
    public int BestScore;
    public void Awake()
    {
        Instance = this; 
    }

    public Cell CalculateBestMove(ELevel level)
    {
        if (level == ELevel.Easy)
        {
            return RandomMove();
        }

        int bestScore = int.MinValue;
        Cell move = Board.Instance.Cells[2, 2];

        int[,] board = Board.Instance.ConvertBoard();
        for (int i = 1; i <= 3; i++)
        {
            for (int j = 1; j <= 3; j++)
            {
                if (board[i, j] == 0)
                {
                    board[i, j] = -1;//assume bot move

                    int score = 0;
                    if (level == ELevel.Medium)
                    {
                        score = Minimax(board, false);
                    }else if (level == ELevel.Hard)
                    {
                        score = Minimax(board, false, 0);
                    }

                    board[i, j] = 0;//undo bot move

                    if (score > bestScore)
                    {
                        bestScore = score;
                        move = Board.Instance.Cells[i, j];
                    }
                }
            }
        }
        return move;

    }

    public async void DoBestMove(ELevel level)
    {
        await Task.Delay(500);
        Cell move = CalculateBestMove(level);
        GameplayManager.Instance.MakeAMove(move);

    }

    public Cell RandomMove()
    {
        List<Cell> availableCells = Board.Instance.GetAllFreeCell();     
        int random = UnityEngine.Random.Range(0, availableCells.Count);
        return availableCells[random];
    }

    public EResult GetWinner(int[,] board)
    {
        //check win
        if (board[1, 1] != 0 && board[1, 1] == board[2, 2] && board[2, 2] == board[3, 3])
        {
            return board[1, 1] == 1? EResult.Player : EResult.AI;
        }
        if (board[3, 1] != 0 && board[3, 1] == board[2, 2] && board[2, 2] == board[1, 3])
        {
            return board[3, 1] == 1? EResult.Player: EResult.AI;
        }
        for (int i = 1; i <= 3; i++)
        {
            if (Math.Abs(board[1, i] + board[2, i] + board[3, i]) == 3)
            {
                return board[1, i] + board[2, i] + board[3, i] == 3? EResult.Player : EResult.AI;
            }
            if (Math.Abs(board[i, 1] + board[i, 2] + board[i, 3]) == 3){
                return board[i, 1] + board[i, 2] + board[i, 3] == 3? EResult.Player : EResult.AI;
            }
        }

        //check tie or not end yet
        for (int i = 1; i <= 3; i++)
        {
            for (int j = 1; j <= 3; j++)
            {
                if (board[i, j] == 0)
                {
                    return EResult.Null;
                }
            }
        }
        return EResult.Tie;          
    }

    #region MINIMAX WITHOUT DEPTH
    public int Minimax(int[,] board, bool isMax)
    {
        EResult result = GetWinner(board);
        if (result != EResult.Null)
        {
            return (int)result;
        }

        int sign = isMax == true? -1 : 1;
        int bestScore = isMax == true? int.MinValue : int.MaxValue;
        for (int i = 1; i <= 3; i++)
        {
            for(int j = 1; j <= 3; j++)
            {
                if (board[i, j] == 0)
                {
                    board[i, j] = sign;
                    int score = Minimax(board, !isMax);
                    bestScore = GetMinMax(isMax, bestScore, score);

                    board[i, j] = 0;
                }
            }
        }
        return bestScore;
    }
    #endregion

    #region MINIMAX WITH DEPTH

    public int Minimax(int[,] board, bool isMax, int depth)
    {
        EResult result = GetWinner(board);
        if (result != EResult.Null)
        {
            return (int)result - depth;
        }

        int sign = (isMax == true) ? -1 : 1;
        int bestScore = (isMax == true) ? int.MinValue : int.MaxValue;
        for (int i = 1; i <= 3; i++)
        {
            for (int j = 1; j <= 3; j++)
            {
                if (board[i, j] == 0)
                {
                    board[i, j] = sign;
                    int score = Minimax(board, !isMax, depth + 1);
                    bestScore = GetMinMax(isMax, bestScore, score);
                    board[i, j] = 0;
                }
            }
        }
        return bestScore;
    }

    #endregion

    public int GetMinMax(bool isMax, int a, int b)
    {
        if (isMax) return a > b ? a : b;
        return a < b ? a : b;
    }

}
