using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeScreen : UIScreen
{
    public GameObject playButton;
    public GameObject tictactoe;
    public override void Appear()
    {
        base.Appear();
        Utils.AnimAppear(playButton.transform);
        Utils.AnimAppear(tictactoe.transform);
    }

    public override void DisAppear()
    {     
        Utils.AnimDisAppear(playButton.transform);
        Utils.AnimDisAppear(tictactoe.transform);
        base.DisAppear();
    }

    public void OnPlayButton()
    {
        AudioManager.Instance.PlayClickButtonSound();
        UIManager.Instance.OpenScreen(EScreen.Mode);
    }

}
