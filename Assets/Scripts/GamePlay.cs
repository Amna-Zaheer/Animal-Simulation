using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GamePlay : MonoBehaviour
{
    public void GamePlayScene()
    {
        SceneManager.LoadScene("NewGamePlay");
        PlayerController.count = 0;
        PlayerController.countDownStartValue = 60;
    }

}
