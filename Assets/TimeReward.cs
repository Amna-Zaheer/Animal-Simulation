using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeReward : MonoBehaviour
{
    public Text Time;
    void Start()
    {
        TimeAdd();
    }

    public void TimeAdd()
    {
        Time.text = PlayerController.countDownStartValue.ToString();
    }
}
