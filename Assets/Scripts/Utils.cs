using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public static class Utils
{
    public static void AnimUpScale(Transform transform)
    {
        transform.localScale = Vector3.one;
        transform.DOScale(Vector3.one * 1.1f, 0.3f).SetEase(Ease.OutBack);

    }
    public static void AnimDownScale(Transform transform)
    {
        //transform.localScale = Vector3.one * 1.1f;
        transform.DOScale(Vector3.one, 0.3f).SetEase(Ease.OutBack);
    }
    public static void AnimPrompt(Transform transform)
    {
        transform.DOScale(Vector3.one * 1.1f, 0.5f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }
    public static void AnimAppear(Transform transform)
    {
        transform.localScale = Vector3.zero;
        transform.DOScale(Vector3.one, 0.3f).SetEase(Ease.OutSine);

    }
    public static void AnimDisAppear(Transform transform)
    {
        transform.DOScale(Vector3.zero, 0.3f).SetEase(Ease.InSine);

    }
    public static string Color(this string content, string color)
    {
        return $"<color={color}>{content}</color>";
    }
}
