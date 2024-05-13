using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScreen : UIScreen
{
    public GameObject button1, button2, button3;
    public override void Appear()
    {
        base.Appear();
        Utils.AnimAppear(button1.transform);
        Utils.AnimAppear(button2.transform);
        Utils.AnimAppear(button3.transform);

    }

    public override void DisAppear()
    {
        Utils.AnimDisAppear(button1.transform);
        Utils.AnimDisAppear(button2.transform);
        Utils.AnimDisAppear(button3.transform);
        base.DisAppear();
    }

    public void OnEasyButton()
    {
        AudioManager.Instance.PlayClickButtonSound();
        GameplayManager.Instance.Level = ELevel.Easy;
        UIManager.Instance.SetLevelUI(ELevel.Easy);
        UIManager.Instance.OpenScreen(EScreen.Play);
    }

    public void OnMediumButton()
    {
        AudioManager.Instance.PlayClickButtonSound();
        GameplayManager.Instance.Level = ELevel.Medium;
        UIManager.Instance.SetLevelUI(ELevel.Medium);
        UIManager.Instance.OpenScreen(EScreen.Play);
    }

    public void OnHardButton()
    {
        AudioManager.Instance.PlayClickButtonSound();
        GameplayManager.Instance.Level = ELevel.Hard;
        UIManager.Instance.SetLevelUI(ELevel.Hard);
        UIManager.Instance.OpenScreen(EScreen.Play);
    }


}
