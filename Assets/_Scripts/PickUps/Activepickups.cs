using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activepickups : MonoBehaviour
   
{
    public GameObject inst;

    void Start()
    {
       inst.SetActive(true);
    }
}
