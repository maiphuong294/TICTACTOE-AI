using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinPopup : Popup
{
    public TextMeshProUGUI title;
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

    public void SetTitle(string s)
    {
        title.SetText(s);
    }
}
