using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    private GameObject[] characterList;
    private int index;
    void Start()
    {
        index = PlayerPrefs.GetInt("CharacterSelected");

        characterList = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            characterList[i] = transform.GetChild(i).gameObject;
        }
        foreach (GameObject animal in characterList)
            animal.SetActive(false);

        if (characterList[index])
        {
            characterList[index].SetActive(true);
            if (CameraControl.instance != null)
                CameraControl.instance.target = characterList[index].transform.GetChild(characterList[index].transform.childCount - 1);
        }

    }
    public void toggleLeft()
    {
        characterList[index].SetActive(false);
        index--;
        if (index < 0)
        {
            index = characterList.Length - 1;
        }
        characterList[index].SetActive(true);
    }
    public void toggleRight()
    {
        characterList[index].SetActive(false);
        index++;
        if (index == characterList.Length)
        {
            index = 0;
        }
        characterList[index].SetActive(true);
    }

    public void selectbutton()
    {
        PlayerPrefs.SetInt("CharacterSelected", index); 
    }

    public void RestartScene()
    {
        Constants.Points = 0;
        PlayerController.countDownStartValue = 60;

    }
}