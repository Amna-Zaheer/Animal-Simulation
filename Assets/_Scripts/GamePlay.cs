using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GamePlay : MonoBehaviour
{
    public void GamePlayScene()
    {
        SceneManager.LoadScene("GamePlay");
        Constants.Points = 0;
        PlayerController.countDownStartValue = 60;
    }

}
