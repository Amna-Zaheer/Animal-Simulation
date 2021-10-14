using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonSwitching : MonoBehaviour
{
    public GameObject Panel;
    public void Active()
    {
        if (Panel != null)
        {
            bool isActive = Panel.activeSelf;
            Panel.SetActive(!isActive);
        }
    }
}