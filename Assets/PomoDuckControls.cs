using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PomoDuckControls : MonoBehaviour
{
    [SerializeField] GameObject buttons;
    [SerializeField] MenuButtons menu;
 
    private bool buttonsOpen = true;

    public void toggleButtons(){
        
        LeanTween.alphaCanvas(buttons.GetComponent<CanvasGroup>(),
            buttonsOpen ? 0 : 1,
            0.3f
        );

        buttons.GetComponent<CanvasGroup>().interactable = true;
        buttonsOpen = !buttonsOpen;
    }

    public void CloseButtons(){
        if (buttonsOpen) toggleButtons();
    }
}

