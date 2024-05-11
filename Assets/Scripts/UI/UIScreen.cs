using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScreen : MonoBehaviour
{
    public virtual void Appear()
    {
        gameObject.SetActive(true);
    }
    public virtual void DisAppear() {
        gameObject.SetActive(false);
    }
}