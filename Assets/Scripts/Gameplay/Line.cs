using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public enum ELine
{
    Vertical,
    Horizontal,
    Cross1,
    Cross2,
}
// FFBEBB red
// D2FFA3 green
public class Line : MonoBehaviour
{
    public Color redColor, greenColor;
    public SpriteRenderer spriteRenderer;
    public void SetDirection(ELine line)
    {
        if (line == ELine.Vertical)
        {
            transform.localEulerAngles = Vector3.forward * 90f;
            return;
        }
        if (line == ELine.Horizontal)
        {
            transform.localEulerAngles = Vector3.zero;
            return;
        }
        if (line == ELine.Cross1)
        {
            transform.localEulerAngles = Vector3.forward * 135f;
            return;
        }
        if ( line == ELine.Cross2) 
        {
            transform.localEulerAngles = Vector3.forward * 45f;
        }
        
    }

    public void Draw(ELine line)
    {
        if (line == ELine.Vertical || line == ELine.Horizontal )
        {
            transform.localScale = Vector3.zero;
            transform.DOScale(new Vector3(0.8f, 1f, 1f), 1f).SetEase(Ease.OutBack);
            return;
        }
        transform.localScale = Vector3.zero;
        transform.DOScale(Vector3.one, 1f).SetEase(Ease.OutBack);
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    public void SetColor(ETurn winner)
    {
        if (winner == ETurn.Player)
        {
            spriteRenderer.color = redColor;
        }
        else
        {
            spriteRenderer.color = greenColor;  
        }
    }
}
