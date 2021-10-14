using UnityEngine;
using System.Collections;

public class PickUpRotate : MonoBehaviour
{

    void Update()
    {
        transform.Rotate(new Vector3(0f, 45, 0f) * Time.deltaTime);
    }
}