using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Utils
{
    /// <summary> 
    /// Destroy children of an object. 
    /// </summary>
    public static void DestroyAllChildren(this GameObject gameObject)
    {
        foreach (var child in gameObject.transform.Cast<Transform>()) UnityEngine.Object.Destroy(child.gameObject);
    }
    public static void DestroyAllChildren(this Transform gameObject)
    {
        foreach (var child in gameObject.transform.Cast<Transform>()) UnityEngine.Object.Destroy(child.gameObject);
    }

    /// <summary>
    /// Destroy child at index
    /// </summary>
    public static void DestroyChildAt(this Transform transform, int index)
    {
        UnityEngine.Object.Destroy(transform.Cast<Transform>().ToList()[index]);
    }

    /// <summary>
    /// Set active all children of an object.
    /// </summary>
    public static void SetActiveAllChildren(this GameObject gameObject, bool enable)
    {
        foreach (Transform child in gameObject.transform)
        {
            child.gameObject.SetActive(enable);
        }
    }
    public static void SetActiveAllChildren(this Transform gameObject, bool enable)
    {
        foreach (Transform child in gameObject.transform)
        {
            child.gameObject.SetActive(enable);
        }
    }
}
