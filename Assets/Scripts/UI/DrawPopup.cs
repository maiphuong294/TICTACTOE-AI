using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPopup : Popup
{
    public override void Open()
    {
        base.Open();
    }

    public override void Close()
    {
        base.Close();
    }

    public void OnHomeButton()
    {
        Close();
        UIManager.Instance.OpenScreen(EScreen.Home);
    }

    public void OnPlayAgainButton()
    {
        GameplayManager.Instance.ResetLevel();
        Close();
    }
}
