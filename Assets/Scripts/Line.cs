using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ELine
{
    Vertical,
    Horizontal,
    Cross1,
    Cross2,
}
public class Line : MonoBehaviour
{
    public void Draw(ELine line)
    {
        if (line == ELine.Vertical)
        {
            transform.localEulerAngles = Vector3.forward * 90f;
            return;
        }
        if (line == ELine.Horizontal)
        {
            transform.localEulerAngles = Vector3.zero;
            return;
        }
        if (line == ELine.Cross1)
        {
            transform.localEulerAngles = Vector3.forward * 135f;
            return;
        }
        if ( line == ELine.Cross2) 
        {
            transform.localEulerAngles = Vector3.forward * 45f;
        }
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }
}
