using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ESign
{
    X,
    O
}
public class Sign : MonoBehaviour
{
    public ESign eSign;

    public Sprite sprite_X, sprite_O;
    public SpriteRenderer spriteRenderer;
    public void Draw()
    {
        transform.localScale = Vector3.zero;
        float duration = 0.1f;
        transform.DOScale(10f, duration).SetEase(Ease.InOutBack);
    }

    public void SetSign(ESign sign)
    {
        this.eSign = sign;
        if (sign == ESign.X)
        {
            spriteRenderer.sprite = sprite_X;
        }
        else
        {
            spriteRenderer.sprite = sprite_O;
        }
        print("set sign for sign " + sign);
    }
}
