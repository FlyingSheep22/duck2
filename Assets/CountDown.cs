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

    // Start is called before the first frame update
    void Start()
    {

        FocusTime = SettingsData.instance != null ? SettingsData.instance.focusTime : 25;
        BreakTime = SettingsData.instance != null ? SettingsData.instance.breakTime : 5;

        timeRemaining = FocusTime * 60 - 1;

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
        breakTime = false;

        //change into pause button
        button.image.sprite = pauseImage;
        Debug.Log("restarted timer");
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

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
                timeRemaining = 0;
                timerIsRunning = false;
                // if a 25 min timer ran out
                if(!breakTime)
                {
                    timeRemaining = BreakTime * 60;
                    //add message to tell user break start here later
                    timerIsRunning = true;
                    breakTime = true;
                }
                //if 5 min timer ran out
                else
                {
                    breakTime = false;
                    timeRemaining = FocusTime * 60;
                    //add message to tell user work start here later
                    timerIsRunning = true;
                }
            }
        }
        else
        {
            DisplayTime(timeRemaining);
        }
    }
}