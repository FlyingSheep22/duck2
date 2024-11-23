using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DuckControls : MonoBehaviour
{
    [SerializeField] GameObject buttons;
    [SerializeField] Outline outline;
    [SerializeField] MenuButtons menu;
    [SerializeField] CanvasGroup welcomeMessage;
 
    private bool buttonsOpen = false;

    public void ButtonClick(){
        if (UIManager.instance.State == "timerSettings"){
            menu.TimerSettings();
            return;
        }

        if (welcomeMessage.alpha == 1){
            LeanTween.alphaCanvas(welcomeMessage,0,0.3f);
        }

        toggleButtons();
    }

    public void toggleButtons(){
        
        LeanTween.alphaCanvas(buttons.GetComponent<CanvasGroup>(),
            buttonsOpen ? 0 : 1,
            0.3f
        );
        
        UIManager.instance.State = buttonsOpen ? "idle" : "menuButtons";

        buttons.GetComponent<CanvasGroup>().interactable = true;
        buttonsOpen = !buttonsOpen;
    }
}
