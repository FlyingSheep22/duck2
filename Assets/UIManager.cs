using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] CanvasGroup menuButtons;
    [SerializeField] CanvasGroup timerSettings;
    [SerializeField] MenuButtons menu;
    [SerializeField] DuckControls duck;
    

    private Animator duckAnim;

    public static UIManager instance;

    // STATES OF THE DUCK: entering, idle, timerSettings, menuButtons

    public String State = "entering";

    // singleton behavior implementation
    void Awake(){
        if (instance == null){
            instance = this;
        } else {
            Destroy(gameObject);
        }

        //duckAnim = duck.GetComponent<Animator>();
    }

    

    void Start(){
        StartCoroutine("enterSequence");

        menuButtons.alpha = 0;
        timerSettings.alpha = 0;
    } 


    IEnumerator enterSequence(){
        RectTransform duckTr = duck.GetComponent<RectTransform>();

        while (duckTr.anchoredPosition.x <= 125){
            duckTr.anchoredPosition += new Vector2(50 * Time.deltaTime, 0);
            yield return null;
        }

        duckAnim.SetTrigger("Resting");
        State = "idle";
    }


    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape)){
            EscapeFunction(State);
        }
    }

    private void EscapeFunction(String state){
        if (state == "timerSettings"){
            menu.TimerSettings();
        }

        if (state == "menuButtons"){
            duck.toggleButtons();
        }
    }
}
