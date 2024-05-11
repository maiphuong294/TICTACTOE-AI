using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayScreen : UIScreen
{
    public GameObject turn1, turn2;
    public override void Appear()
    {
        base.Appear();
    }

    public override void DisAppear()
    {
        base.DisAppear(); 
    }
    public void SetTurnUI(ETurn turn)
    {
        if (turn == ETurn.Player)
        {
            Utils.AnimUpScale(turn1.transform);
            Utils.AnimDownScale(turn2.transform);
        }
        else
        {
            Utils.AnimUpScale(turn2.transform);
            Utils.AnimDownScale(turn1.transform);
        }
    }

    public void OnHomeButton()
    {
        UIManager.Instance.OpenScreen(EScreen.Home);

    }
}
