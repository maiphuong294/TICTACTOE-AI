using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public static Board Instance {  get; private set; }

    private Cell[,] cells = new Cell[4, 4];

    public int BoardSize { get; private set; } = 3;

    public float BoardWidth;

    public Vector3 UpLeftCorner;
    
    [SerializeField] private GameObject cellPrefab;
    public SpriteRenderer spriteRenderer;
    private void Awake()
    {
        Instance = this; 
    }
    public void Start()
    {
        BoardWidth = spriteRenderer.sprite.bounds.size.x;
        UpLeftCorner = Vector3.zero - new Vector3(BoardWidth, -BoardWidth, 0f);
        Instantiate(cellPrefab, UpLeftCorner, Quaternion.identity);
    }

    [Button]
    public void SpawnCells()
    {
        for (int i = 1; i <= BoardSize; i++)
        {
            for (int j = 1; j <= BoardSize; j++)
            {
                cells[i, j] = Instantiate(cellPrefab, transform).GetComponent<Cell>();
                cells[i, j].SetPosInBoard(i, j);
            }
        }
    }
}
