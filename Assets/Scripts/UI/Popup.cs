using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
{
    public GameObject board;
    public virtual void Open()
    {
        gameObject.SetActive(true);
        Utils.AnimAppear(board.transform);
        AudioManager.Instance.StopMusic();
        
    }
    public virtual void Close()
    {
        Utils.AnimDisAppear(board.transform);
        gameObject.SetActive(false);
        GameplayManager.Instance.ClearLevel();
        //AudioManager.Instance.PlayMusic(AudioManager.Instance.playMusic);
    }

    public void OnHomeButton()
    {
        AudioManager.Instance.PlayClickButtonSound();
        Close();
        UIManager.Instance.OpenScreen(EScreen.Home);      
    }

    public void OnPlayAgainButton()
    {
        AudioManager.Instance.PlayClickButtonSound();
        GameplayManager.Instance.ResetLevel();
        Close();
    }
}
