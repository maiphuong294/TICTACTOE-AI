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
    }
    public virtual void Close()
    {
        Utils.AnimDisAppear(board.transform);
        gameObject.SetActive(false);
        GameplayManager.Instance.ClearLevel();
    }
}
