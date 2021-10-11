using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

[RequireComponent(typeof(AudioSource))]
public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
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
    public static int count;
    public static int highscore;
    public Text highScoreView;
    public GameObject checkTime;

    public GameObject Restartpanel;
    public float rotationSpeed;
    public GameObject winpanel;
    [SerializeField]
    public static int countDownStartValue = 60;    
    public Text time;

    public float speed;
    public Text countText;

    private Rigidbody rb;
   
    public AudioClip winnersound;
    public AudioClip impact;
    AudioSource audioSource;
    public FixedJoystick Joystick;

    private Animator Anim;

    void Start()
    {
        Joystick = FindObjectOfType<FixedJoystick>();
        InvokeRepeating("SetCountText", 0, 1f);
        rb = GetComponent<Rigidbody>();
        Anim = GetComponentInChildren<Animator>();
        count = 0;
        highscore = PlayerPrefs.GetInt("HighScore");
        highScoreView.text = highscore.ToString();
    } 
    void FixedUpdate()
    {
        audioSource = GetComponent<AudioSource>();
        float moveVertical = Joystick.Vertical;
        float moveHorizontal = Joystick.Horizontal;
        Anim.SetFloat("State", moveVertical);
        Vector3 movement = new Vector3( moveHorizontal, 0.0f, moveVertical);
        Vector3 localmov = transform.TransformDirection(movement);
        rb.AddForce(localmov * speed);
        if (localmov != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(localmov, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUps"))
        {
            other.gameObject.SetActive(false);
            count = count + 10;
            SetCountText();
            HighScore();
            audioSource.PlayOneShot(impact, 0.7F);
        }
    }
    public void SetCountText()
    {
        countText.text =  count.ToString();

        if (countDownStartValue > 0)
        {
            TimeSpan spanTime = TimeSpan.FromSeconds(countDownStartValue);
            time.text = "Timer : " + spanTime.Minutes + " : " + spanTime.Seconds;
            if (checkTime.active == true)
            {
                countDownStartValue--;
            }
        }
        else if ( count >= 50)
        {
            winpanel.SetActive(true);
            audioSource.PlayOneShot(winnersound, 0.7F);
            CancelInvoke("SetCountText");
            for (int i = 0; i < ScoreManager.instance.sd.scores.Count; i++)
            {

                if (ScoreManager.instance.sd.scores[i].nam.Equals(Constants.PlayerName))
                {

                    ScoreManager.instance.sd.scores[i].score = count;
                    ScoreManager.instance.SaveScore();
                    return;
                }

            }
            ScoreManager.instance.AddScore(new Score(Constants.PlayerName, count));
        }
         else
        {
            Restartpanel.SetActive(true);
            CancelInvoke("SetCountText");
            for (int i = 0; i < ScoreManager.instance.sd.scores.Count; i++)
            {

                if (ScoreManager.instance.sd.scores[i].nam.Equals(Constants.PlayerName))
                {

                    ScoreManager.instance.sd.scores[i].score = count;
                    ScoreManager.instance.SaveScore();
                    return;
                }

            }
            ScoreManager.instance.AddScore(new Score(Constants.PlayerName, count));
        }
    }
    public void HighScore()
    {
        if (count> highscore)
        {
            highscore = count;
            highScoreView.text = highscore.ToString();
            PlayerPrefs.SetInt("HighScore", highscore);
        }
    }
    public static void DoubleScore()
    {
        count *= 2;
    }
    public static void AddExtraTime()
    {

    }
}

