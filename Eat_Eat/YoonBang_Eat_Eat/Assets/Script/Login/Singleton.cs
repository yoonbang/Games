﻿using UnityEngine;
using System.Collections;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T instance = null;
    public static T GetInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(T)) as T;
                if (instance == null)
                {
                    //Debug.Log("Noting" + instance.ToString());
                    return null;
                }
            }
            return instance;
        }
    }
}
