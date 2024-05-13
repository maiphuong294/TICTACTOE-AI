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
        AudioManager.Instance.PlaySound(AudioManager.Instance.win);
    }

    public override void Close()
    {
        base.Close();
    }

    public void SetTitle(string s)
    {
        title.SetText(s);
    }
}
