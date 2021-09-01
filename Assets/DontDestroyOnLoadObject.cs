using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoadObject : MonoBehaviour
{
    static DontDestroyOnLoadObject dontDestroyObject;

    private void Awake()
    {
        if(dontDestroyObject == null)
        {
            dontDestroyObject = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
