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

    public static UIManager instance;
    public String State = "idle";

    // singleton behavior implementation
    void Awake(){
        if (instance == null){
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    

    void Start(){
        menuButtons.alpha = 0;
        timerSettings.alpha = 0;
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
