using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeScreen : UIScreen
{
    public GameObject button1, button2;
    public override void Appear()
    {
        base.Appear();
        Utils.AnimAppear(button1.transform);
        Utils.AnimAppear(button2.transform);
    }

    public override void DisAppear()
    {
        Utils.AnimDisAppear(button1.transform);
        Utils.AnimDisAppear(button2.transform);
        base.DisAppear();
    }

    public void OnPvPButton()
    {
        GameplayManager.Instance.Mode = EMode.PvP;
        UIManager.Instance.SetModeUI(EMode.PvP);
        UIManager.Instance.OpenScreen(EScreen.Play);
        

    }
    public void OnPvEButton()
    {
        GameplayManager.Instance.Mode = EMode.PvE;
        UIManager.Instance.SetModeUI(EMode.PvE);
        UIManager.Instance.OpenScreen(EScreen.Level);
    }
}
