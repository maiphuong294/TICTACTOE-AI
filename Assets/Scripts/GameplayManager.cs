using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EMode
{
    PvP,
    PvE
}

public enum ELevel
{
    Easy,
    Medium,
    Hard
}
public class GameplayManager : MonoBehaviour
{
    public static GameplayManager Instance { get; private set; }
    public void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        
    }

    public void CheckWinner()
    {

    }
}
