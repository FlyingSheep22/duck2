using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] CanvasGroup menuButtons;
    [SerializeField] CanvasGroup timerSettings;
    [SerializeField] CanvasGroup welcomeMessage;
    [SerializeField] MenuButtons menu;
    [SerializeField] DuckControls duck;
    

    private AnimationBehaviourController anim;

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
        anim = duck.GetComponent<AnimationBehaviourController>();
    }

    

    void Start(){
        StartCoroutine("enterSequence");

        menuButtons.alpha = 0;
        timerSettings.alpha = 0;
        welcomeMessage.alpha = 0;
    } 


    IEnumerator enterSequence(){
        RectTransform duckTr = duck.GetComponent<RectTransform>();

        while (duckTr.anchoredPosition.x <= 125){
            duckTr.anchoredPosition += new Vector2(70 * Time.deltaTime, 0);
            yield return null;
        }

        LeanTween.alphaCanvas(welcomeMessage.GetComponent<CanvasGroup>(),
        false ? 0f : 1f, 
        0.3f).setIgnoreTimeScale(true);
        yield return new WaitForSecondsRealtime(0.3f);

        anim.SetIdle();
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
