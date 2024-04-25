using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private BoxCollider2D boxCollider;
    void Start()
    {
        
    }
    public void SetPosInBoard(int row, int column)
    {
        float spacing = 0.01f;
        float margin = 0.05f;

        float cellSize = (Board.Instance.BoardWidth - margin * 2 - spacing * (Board.Instance.BoardSize - 1)) / Board.Instance.BoardSize;
        print("cellSize " + cellSize);
        Resize(cellSize);
        float unitSize = cellSize + spacing;
        float localX = unitSize * (column - (Board.Instance.BoardSize + 1) / 2);
        float localY = unitSize * (row - (Board.Instance.BoardSize + 1) / 2);
        print("localX " + localX + " localY " + localY);
        transform.localPosition = new Vector3(localX, -localY, 0f);
    }

    public void Resize(float expectedSize)
    {
        Vector2 currentSize = spriteRenderer.bounds.size;

        float scaleX = expectedSize / currentSize.x;

        transform.localScale = Vector3.one * scaleX;
    }
   
}
