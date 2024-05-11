using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeScreen : UIScreen
{
    public override void Appear()
    {
        base.Appear();
    }

    public override void DisAppear()
    {
        base.DisAppear();
    }

    public void OnPvPButton()
    {
        GameplayManager.Instance.Mode = EMode.PvP;
        UIManager.Instance.OpenScreen(EScreen.Play);

    }
    public void OnPvEButton()
    {
        GameplayManager.Instance.Mode = EMode.PvE;
        UIManager.Instance.OpenScreen(EScreen.Level);
    }
}
