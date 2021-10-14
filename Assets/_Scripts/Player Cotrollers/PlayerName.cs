using UnityEngine;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour
{
    public GameObject menupanel;
    public GameObject levelselectPanel;
    public InputField playerName;
    public static PlayerName instance;
    public Text errorMsg;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    
    void Start()
    {
        playerName.text = PlayerPrefs.GetString("");
        Constants.PlayerName = playerName.text;
   
    }

    private void OnEnable()
    {
        playerName.onValueChanged.AddListener(delegate { SetName(); CheckEmpty(); });
    }

    void SetName()
    {
        PlayerPrefs.SetString("", playerName.text);
        Constants.PlayerName = playerName.text;
        Debug.Log("name: " + playerName.text);
    }
    public void check()
    {
        if(Constants.PlayerName=="")
        {
            menupanel.SetActive(true);
            levelselectPanel.SetActive(false);
            errorMsg.text = "PLEASE! ENTER YOUR NAME";
        }
        else
        {
            menupanel.SetActive(false);
            levelselectPanel.SetActive(true);
        } 
    }
    public void CheckEmpty()
    {
        errorMsg.text = "";
    }
}