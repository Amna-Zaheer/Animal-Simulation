using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGmusic : MonoBehaviour
{
    public static BGmusic bginstance;

    private void Awake()
    {
        if (bginstance != null && bginstance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        bginstance = this;
        DontDestroyOnLoad(this);
    }



}
