using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeScreen : UIScreen
{
    public GameObject playButton;
    public override void Appear()
    {
        base.Appear();
        Utils.AnimAppear(playButton.transform);
    }

    public override void DisAppear()
    {     
        Utils.AnimAppear(playButton.transform);
        base.DisAppear();
    }

    public void OnPlayButton()
    {
        UIManager.Instance.OpenScreen(EScreen.Mode);
    }

}
