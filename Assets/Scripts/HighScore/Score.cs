using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Score 
{
    public string nam;
    public int score;
    public Score(string nam, int score)
    {
        this.nam = nam;
        this.score = score;
    }
}
