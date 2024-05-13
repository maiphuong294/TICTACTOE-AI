using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum EScreen
{
    Home, 
    Play,
    Level,
    Mode
}

public enum EPopup
{
    Draw, 
    Win, 
    Lose
}


public class UIManager : MonoBehaviour
{
    //screens
    public GameObject playScreenPrefab;
    public GameObject homeScreenPrefab;
    public GameObject levelScreenPrefab;
    public GameObject modeScreenPrefab;

    public PlayScreen playScreen;
    public HomeScreen homeScreen;
    public LevelScreen levelScreen;
    public ModeScreen modeScreen;
    
    public UIScreen currentScreen;

    //popups

    public GameObject winPopupPrefab;
    public GameObject losePopupPrefab;
    public GameObject drawPopupPrefab;

    public WinPopup winPopup;
    public LosePopup losePopup;
    public DrawPopup drawPopup;

    public GameObject PopupCanvas;
    public static UIManager Instance { get; private set; }
    public void Awake()
    {
        Instance = this;
        //events
        Messenger.AddListener<ETurn, EMode>(EventKey.OnEndGame, OnEndGamePopup);

        SpawnScreens();
        SpawnPopups();
    }
    public void Start()
    {
        OpenScreen(EScreen.Home);
    }
    public void SpawnScreens()
    {
        //screens
        playScreen = Instantiate(playScreenPrefab, transform).GetComponent<PlayScreen>();
        playScreen.gameObject.SetActive(false);

        homeScreen = Instantiate(homeScreenPrefab, transform).GetComponent<HomeScreen>();
        homeScreen.gameObject.SetActive(false);

        levelScreen = Instantiate(levelScreenPrefab, transform).GetComponent<LevelScreen>();
        levelScreen.gameObject.SetActive(false);

        modeScreen = Instantiate(modeScreenPrefab, transform).GetComponent<ModeScreen>();
        modeScreen.gameObject.SetActive(false);
    }

    public void SpawnPopups()
    {
        //popups
        winPopup = Instantiate(winPopupPrefab, PopupCanvas.transform).GetComponent<WinPopup>();
        winPopup.gameObject.SetActive(false);

        losePopup = Instantiate(losePopupPrefab, PopupCanvas.transform).GetComponent<LosePopup>();
        losePopup.gameObject.SetActive(false);

        drawPopup = Instantiate(drawPopupPrefab, PopupCanvas.transform).GetComponent<DrawPopup>();
        drawPopup.gameObject.SetActive(false);
    }

    #region MANAGE PLAYSCREEN
    public void SetTurnUI(ETurn turn)
    {
        playScreen.SetTurnUI(turn);
    }
    public void SetModeUI(EMode mode)
    {
        playScreen.SetModeUI(mode);
    }
    public void SetLevelUI(ELevel level)
    {
        playScreen.SetLevelUI(level);
    }
    #endregion



    public void OpenScreen(EScreen screen)
    {
        if (currentScreen != null)
        {
            currentScreen.DisAppear();
        }
        switch (screen)
        {
            case EScreen.Home:
                currentScreen = homeScreen;
                GameplayManager.Instance.IsPlaying = false;
                //AudioManager.Instance.PlayMusic(AudioManager.Instance.homeMusic);
                break;
            case EScreen.Play:
                currentScreen = playScreen;
                GameplayManager.Instance.IsPlaying = true;
                GameplayManager.Instance.ResetLevel();
                //AudioManager.Instance.PlayMusic(AudioManager.Instance.playMusic);
                break;
            case EScreen.Level:
                currentScreen = levelScreen;
                GameplayManager.Instance.IsPlaying = false;
                break;
            case EScreen.Mode:
                currentScreen = modeScreen;
                GameplayManager.Instance.IsPlaying = false;
                break;
        }
        currentScreen.Appear();
    }


    #region POPUP
    public void OpenPopup(EPopup popup)
    {
        switch (popup)
        {
            case EPopup.Win:
                winPopup.Open();
                break;
            case EPopup.Lose:
                losePopup.Open();
                break;
            case EPopup.Draw:
                drawPopup.Open();
                break;
        }
     
    }

    public void OnEndGamePopup(ETurn turn, EMode mode)
    {
        if (mode == EMode.PvP)
        {
            if (turn == ETurn.Null)
            {
                drawPopup.Open();
                return;
            }
            else if (turn == ETurn.Player)
            {
                winPopup.SetTitle("PLAYER 1 WIN!");
            }
            else winPopup.SetTitle("PlAYER 2 WIN!");
            winPopup.Open();
        }
        else
        {
            if (turn == ETurn.Player)
            {
                winPopup.SetTitle("YOU WIN!");
                winPopup.Open();
            }
            else if (turn == ETurn.Opponent)
            {
                losePopup.Open();
            }
            else
            {
                drawPopup.Open();
            }
        }
    }

    #endregion
}
