using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
using Unity.VisualScripting;

public class CountDown : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] Animator anim;

    [SerializeField] TextMeshProUGUI message;

    public float timeRemaining = 25*60;
    public bool timerIsRunning = false;
    public bool breakTime = false;

    //time variables
    public float twentyFiveMin = 25*60;
    public float fiveMin = 5*60;

    //for spirte changing
    public Sprite pauseImage;
    public Sprite startImage;
    public Button button;


    private int FocusTime;
    private int BreakTime;
    private int ReminderTime;

    // Start is called before the first frame update
    void Start()
    {

        FocusTime = SettingsData.instance != null ? SettingsData.instance.FocusTime : 25;
        BreakTime = SettingsData.instance != null ? SettingsData.instance.BreakTime : 5;
        ReminderTime = SettingsData.instance != null ? SettingsData.instance.endReminder : 5;

        timeRemaining = FocusTime * 60 - 1;

        anim.SetBool("bop",false);

        message.transform.parent.gameObject.SetActive(false);
    }


    //start 
    public void startPauseClick()
    {
        if(!timerIsRunning) //user is trying to start/continue timer
        {
            timerIsRunning = true;
            //change into pause button
            button.image.sprite = pauseImage;
            Debug.Log("start timer");
        }
        else //user is trying to pause timer
        {
            timerIsRunning = false;
            button.image.sprite = startImage;
        }
    }

    // RESTART
    public void restart()
    {
        timeRemaining = FocusTime*60;
        timerIsRunning = true;
        anim.SetBool("bop",false);
        Debug.Log("2");

        breakTime = false;

        //change into pause button
        button.image.sprite = pauseImage;
        Debug.Log("restarted timer");

        StartCoroutine(SetMessage("Session restarted!"));
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;


        if (Mathf.FloorToInt(timeToDisplay) == ReminderTime * 60 && !breakTime){
            StartCoroutine(SetMessage($"{ReminderTime} minutes remaining!"));
        }


        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Update is called once per frame
   void Update()
    {
        if (timerIsRunning)
        {
            //timer keeps running
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);

            }
            else
            {
                Debug.Log("Time has run out!");
                //timeRemaining = 0;
                timerIsRunning = false;
                // if a 25 min timer ran out
                if(!breakTime)
                {
                    timeRemaining = BreakTime * 60-1;                    
                    StartCoroutine("delay5min"); //delayed start 5 min timer
                }
                //if 5 min timer ran out
                else
                {
                    anim.SetBool("bop",false);
                    timeRemaining = FocusTime * 60-1;
                    StartCoroutine("delay25min");
                }
            }
        }
        else
        {
            DisplayTime(timeRemaining);
        }
    }

    //delayed start 25 min timer (so the animation has time to switch & message play)
        IEnumerator delay25min()
    {
        DisplayTime(timeRemaining);
        // display message
        StartCoroutine(SetMessage("Time to focus!"));
        yield return new WaitForSecondsRealtime(3.5f);

        timerIsRunning = true;
        breakTime = false;
    }

    // delayed start 5 min timer
    IEnumerator delay5min()
    {
        DisplayTime(timeRemaining);
        
        // display message
        StartCoroutine(SetMessage("Time for a break!"));

        yield return new WaitForSecondsRealtime(3.5f);
        anim.SetBool("bop",true);
        Debug.Log("4");

        //add message to tell user break start here later
        timerIsRunning = true;
        breakTime = true;
    }

    IEnumerator SetMessage(string messagetext){
        message.transform.parent.gameObject.SetActive(true);
        message.text = messagetext;

        LeanTween.alphaCanvas(message.transform.parent.GetComponent<CanvasGroup>(),
        1f, 0.5f);
        yield return new WaitForSecondsRealtime(0.5f);

        yield return new WaitForSecondsRealtime(3f);

        LeanTween.alphaCanvas(message.transform.parent.GetComponent<CanvasGroup>(),
        0f, 0.5f);
        yield return new WaitForSecondsRealtime(0.5f);
        message.transform.parent.gameObject.SetActive(false);
    }
}