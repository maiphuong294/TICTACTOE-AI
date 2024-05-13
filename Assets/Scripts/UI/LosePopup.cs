using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosePopup : Popup
{
    public override void Open()
    {
        AudioManager.Instance.PlaySound(AudioManager.Instance.lose);
        base.Open();
    }

    public override void Close()
    {
        base.Close();
    }



}
