using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayScreen : UIScreen
{
    public GameObject turn1, turn2;
    public TextMeshProUGUI text1, text2, levelText;
    public override void Appear()
    {
        base.Appear();
    }

    public override void DisAppear()
    {
        base.DisAppear(); 
    }
    public void SetModeUI(EMode mode)
    {
        if (mode == EMode.PvP)
        {
            text1.SetText("PLAYER ONE");
            text2.SetText("PLAYER TWO");
            levelText.gameObject.SetActive(false);  
        }
        else
        {
            text1.SetText("PLAYER");
            text2.SetText("BOT");
            levelText.gameObject.SetActive(true);
        }
        
    }

    public void SetLevelUI(ELevel level)
    {
        if (level == ELevel.Easy)
        {
            levelText.SetText("EASY");
        }else if (level == ELevel.Medium)
        {
            levelText.SetText("MEDIUM");
        }
        else
        {
            levelText.SetText("HARD");
        }
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
