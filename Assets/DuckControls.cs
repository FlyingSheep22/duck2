using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DuckControls : MonoBehaviour
{
    [SerializeField] GameObject buttons;
    [SerializeField] MenuButtons menu;
    [SerializeField] CanvasGroup welcomeMessage;
 
    private bool buttonsOpen = false;

    public void ButtonClick(){
        if (UIManager.instance.State == "timerSettings"){
            menu.TimerSettings();
            return;
        }

        if (welcomeMessage.alpha == 1){
            StartCoroutine("MessageDissapear");
        }

        toggleButtons();
    }

    IEnumerator MessageDissapear(){
        LeanTween.alphaCanvas(welcomeMessage,0,0.3f);
        yield return new WaitForSecondsRealtime(0.3f);

        welcomeMessage.gameObject.SetActive(false);
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

    public void StartPomo(){
        StartCoroutine("toggleButtonsSlow");
    }

    public IEnumerator toggleButtonsSlow(){
        
        LeanTween.alphaCanvas(buttons.GetComponent<CanvasGroup>(), 0, 0.8f);
        yield return new WaitForSecondsRealtime(0.8f);
        
        buttons.GetComponent<CanvasGroup>().interactable = true;
        buttonsOpen = !buttonsOpen;

        SceneManager.LoadScene(1);
    }
}
