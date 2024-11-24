using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
using Unity.VisualScripting;

public class CountDown : MonoBehaviour
{
    public ConfettiManager ConfettiManager;

    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] Animator anim;

    [SerializeField] TextMeshProUGUI message;
    [SerializeField] Slider slider;

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

    public static CountDown instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        FocusTime = SettingsData.instance != null ? SettingsData.instance.focusTime : 25;
        BreakTime = SettingsData.instance != null ? SettingsData.instance.breakTime : 5;
        ReminderTime = SettingsData.instance != null ? SettingsData.instance.endReminder : 5;

        timeRemaining = FocusTime * 60 - 1;
        message.transform.parent.gameObject.SetActive(false);
    }

    public void setNewSettings(){
        Debug.Log(SettingsData.instance.focusTime.ToString());
        FocusTime = SettingsData.instance != null ? SettingsData.instance.focusTime : 25;
        BreakTime = SettingsData.instance != null ? SettingsData.instance.breakTime : 5;
        ReminderTime = SettingsData.instance != null ? SettingsData.instance.endReminder : 5;

        timeRemaining = FocusTime * 60 - 1;
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

            anim.SetBool("PomoStarted",true);
        }
        else //user is trying to pause timer
        {
            timerIsRunning = false;
            button.image.sprite = startImage;
            anim.SetBool("PomoStarted",false);
        }

    }

    // RESTART
    public void restart()
    {
        timeRemaining = FocusTime*60;
        timerIsRunning = true;

        breakTime = false;
        anim.SetBool("PomoStarted",true);
        //change into pause button
        button.image.sprite = pauseImage;

        //StartCoroutine(SetMessage("Session restarted!"));
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
        
        
        float timeRatio = timeToDisplay / ((breakTime ? (float) BreakTime : (float) FocusTime) * 60f);
        slider.value = timeRatio;
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
            }
            else
            {
                Debug.Log("Time has run out!");
                //timeRemaining = 0;
                timerIsRunning = false;
                // if a 25 min timer ran out
                if(!breakTime)
                {
                    breakTime = true;
                    timeRemaining = BreakTime * 60-1;                    
                    StartCoroutine("delay5min"); //delayed start 5 min timer
                    
                }
                //if 5 min timer ran out
                else
                {
                    timeRemaining = FocusTime * 60-1;
                    StartCoroutine("delay25min");
                }
            }
        }
        
        DisplayTime(timeRemaining);
        
    }

    //delayed start 25 min timer (so the animation has time to switch & message play)
        IEnumerator delay25min()
    {
        // display message
        StartCoroutine(SetMessage("Time to focus!"));
        yield return new WaitForSecondsRealtime(3.5f);

        timerIsRunning = true;
        breakTime = false;
    }

    // delayed start 5 min timer
    IEnumerator delay5min()
    {
        ConfettiManager.TriggerConfetti();
        DisplayTime(timeRemaining);
        
        // display message
        StartCoroutine(SetMessage("Time for a break!"));

        yield return new WaitForSecondsRealtime(3.5f);

        timerIsRunning = true;
        
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


    public void ChangeFocusTime(int i){
        FocusTime = i;

        if (!timerIsRunning && !breakTime){
            timeRemaining = FocusTime * 60 -1;
        }
        if (!breakTime){
            timeRemaining = Mathf.Min(timeRemaining,FocusTime) * 60 -1;
        }
    }

    public void ChangeBreakTime(int i){
        BreakTime = i;

        if (!timerIsRunning && breakTime){
            timeRemaining = BreakTime * 60 - 1;
        }

        else if (breakTime){
            timeRemaining = Mathf.Min(timeRemaining,BreakTime) * 60 -1;

        } 
    }

    public void Stats(){
        Debug.Log($"FOCUS TIME: {FocusTime} BREAK TIME: {BreakTime}");
    }
}