using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private BoxCollider2D boxCollider;

    public Sign signPrefab;
    public Sign sign;

    public int Row;
    public int Column;
    void Start()
    {
        
    }

    public void OnMouseDown()
    {
        GameplayManager.Instance.HandlePickCell(this);
    }

    #region SIGN MANAGE
    public void DrawSign(ESign type)
    {
        Sign a = Instantiate(signPrefab, transform);
        a.SetSign(type);
        a.Draw();
        sign = a;
    }

    public bool IsHaveSign()
    {
        if (sign != null) return true;
        return false;
    }

    public void ResetCell()
    {
        if (IsHaveSign()) {
            Destroy(transform.GetChild(0).gameObject);
        }    
        sign = null;
    }
    #endregion

    #region SETUP
    public void SetPosInBoard(int row, int column)
    {
        Row = row;
        Column = column;

        float spacing = 0.01f;
        float margin = 0.05f;

        float cellSize = (Board.Instance.BoardWidth - margin * 2 - spacing * (Board.Instance.BoardSize - 1)) / Board.Instance.BoardSize;
        Resize(cellSize);
        float unitSize = cellSize + spacing;
        float localX = unitSize * (column - (Board.Instance.BoardSize + 1) / 2);
        float localY = unitSize * (row - (Board.Instance.BoardSize + 1) / 2);
        transform.localPosition = new Vector3(localX, -localY, 0f);
    }

    public void Resize(float expectedSize)
    {
        Vector2 currentSize = spriteRenderer.bounds.size;

        float scaleX = expectedSize / currentSize.x;

        transform.localScale = Vector3.one * scaleX;
    }
    #endregion
}
