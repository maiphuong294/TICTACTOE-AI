using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public static Board Instance {  get; private set; }

    public Cell[,] Cells = new Cell[4, 4];

    public int BoardSize { get; private set; } = 3;

    public float BoardWidth;

    
    [SerializeField] private GameObject cellPrefab;
    public SpriteRenderer spriteRenderer;
    private void Awake()
    {
        Instance = this; 
    }
    public void Start()
    {
        BoardWidth = spriteRenderer.sprite.bounds.size.x;
        SpawnCells();
    }

    [Button]
    public void SpawnCells()
    {
        for (int i = 1; i <= BoardSize; i++)
        {
            for (int j = 1; j <= BoardSize; j++)
            {
                Cells[i, j] = Instantiate(cellPrefab, transform).GetComponent<Cell>();
                Cells[i, j].SetPosInBoard(i, j);
            }
        }
    }

    public void ResetBoard()
    {
        for (int i = 1; i <= 3; i++)
        {
            for (int j = 1; j <= 3; j++)
            {
                Cells[i, j].ResetCell();
            }
        }

    }   

    public bool CheckFull()
    {
        for (int i = 1; i <= 3; i++)
        {
            for (int j = 1; j <= 3; j++)
            {
                if (!Cells[i, j].IsHaveSign()) return false;
            }
        }
        return true;
    }
}
