using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScreen : UIScreen
{
    public override void Appear()
    {
        base.Appear();
    }

    public override void DisAppear()
    {
        base.DisAppear();
    }

    public void OnEasyButton()
    {
        GameplayManager.Instance.Level = ELevel.Easy;
        UIManager.Instance.OpenScreen(EScreen.Play);
    }

    public void OnMediumButton()
    {
        GameplayManager.Instance.Level = ELevel.Medium;
        UIManager.Instance.OpenScreen(EScreen.Play);
    }

    public void OnHardButton()
    {
        GameplayManager.Instance.Level = ELevel.Hard;
        UIManager.Instance.OpenScreen(EScreen.Play);
    }


}
