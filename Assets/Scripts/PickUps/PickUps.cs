using UnityEngine;
public class PickUps : MonoBehaviour
{
    void Start()
    {
        Setposition();
    }
   public void Setposition()
    {
        //28,37
        float xRange = Random.Range(28f,48f);
        float zRange = Random.Range(37f,54f);
        transform.position = new Vector3(xRange,transform.position.y,zRange);
    }
}
