using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPopup : Popup
{
    public override void Open()
    {
        base.Open();
        AudioManager.Instance.PlaySound(AudioManager.Instance.tie);
    }

    public override void Close()
    {
        base.Close();
    }

}
