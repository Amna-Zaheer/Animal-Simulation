using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
      public static CameraController instance;
    
     private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
                Destroy(gameObject);

        }
    public GameObject player;
    private Vector3 offset;
    bool isPlayer;

    void Start()
    {
        isPlayer = false;
       StartCoroutine(SetOffset());
    }

    IEnumerator SetOffset()
    {
        yield return new WaitForSeconds(0.1f);
        offset = transform.position - player.transform.position;
        isPlayer = true;
        
    }


    void LateUpdate()
    {
        if (isPlayer)
        {
            transform.position = player.transform.position + offset;
        }
    }
}