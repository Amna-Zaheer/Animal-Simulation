using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

[RequireComponent(typeof(AudioSource))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float rotateSpeed = 1f;
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
    
    public static int highscore;
    public Text highScoreView;
    public GameObject checkTime;

    public GameObject Restartpanel;
    public float rotationSpeed;
    public GameObject winpanel;
    [SerializeField] public static int countDownStartValue = 60;    
    public Text time;
    public float speed;
    public Text countText;

    private Rigidbody rb;
   
    public AudioClip winnersound;
    public AudioClip impact;
    AudioSource audioSource;
    public FixedJoystick Joystick;

    private Animator Anim;
    public static bool stop;

    void Start()
    {
        Joystick = FindObjectOfType<FixedJoystick>();
        rb = GetComponent<Rigidbody>();
        Anim = GetComponentInChildren<Animator>();
        Constants.Points = 0;
        highscore = PlayerPrefs.GetInt(Constants.HighScore);
        highScoreView.text = highscore.ToString();
        SetCountText();
    } 
    void FixedUpdate()
    {
        audioSource = GetComponent<AudioSource>();
        PlayerControls();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Constants.Pickups))
        {
            other.gameObject.SetActive(false);
            Constants.Points = Constants.Points + 10;
            
            audioSource.PlayOneShot(impact, 0.7F);
        }
    }
    public void SetCountText()
    {   
        countText.text =  Constants.Points.ToString();
        HighScore();
        if (countDownStartValue > 0)
        {
            TimeSpan spanTime = TimeSpan.FromSeconds(countDownStartValue);
            time.text = "Timer : " + spanTime.Minutes + " : " + spanTime.Seconds;
            if (checkTime.activeSelf == true)
            {
                countDownStartValue--;

            }
            Invoke(Constants.SetCountText, 1f);
        }
        else if ( Constants.Points >= 50)
        {
            winpanel.SetActive(true);
            audioSource.PlayOneShot(winnersound, 0.7F);
            for (int i = 0; i < ScoreManager.instance.sd.scores.Count; i++)
            {

                if (ScoreManager.instance.sd.scores[i].nam.Equals(Constants.PlayerName) && ScoreManager.instance.sd.scores[i].score<=Constants.Points)
                {

                    ScoreManager.instance.sd.scores[i].score = Constants.Points;
                    ScoreManager.instance.SaveScore();
                    return;
                }

            }
            ScoreManager.instance.AddScore(new Score(Constants.PlayerName, Constants.Points));
        }
         else
        {
            Restartpanel.SetActive(true);
        }
    }
    public void HighScore()
    {
        if (Constants.Points > highscore)
        {
            highscore = Constants.Points;
            highScoreView.text = Constants.Points.ToString();
            PlayerPrefs.SetInt(Constants.HighScore, Constants.Points);
        }
    }
    public static void DoubleScore()
    {
        Constants.Points *= 2;
    }
    public void PlayerControls()
    {
        rb.velocity = transform.TransformDirection(new Vector3(Joystick.Horizontal*moveSpeed, rb.velocity.y, Joystick.Vertical*moveSpeed));


        if (Joystick.Horizontal >= 0.1f || Joystick.Horizontal <= -0.1f)
        { 
            transform.Rotate(new Vector3(0, Joystick.Horizontal * rotateSpeed, 0));
        }

        if (Joystick.Horizontal != 0f || Joystick.Vertical != 0f)
        {
            Anim.SetBool(Constants.Animation, true);
            rb.isKinematic = false;
            stop = false;
        }
        else
        {
            Anim.SetBool(Constants.Animation, false);
            stop = true;

        }
    }
}

