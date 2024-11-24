using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PomoDuckControls : MonoBehaviour
{
    [SerializeField] GameObject buttons;
    private bool buttonsOpen = false;

    void Start(){
        buttons.GetComponent<CanvasGroup>().alpha = 0;

        LeanTween.alphaCanvas(buttons.GetComponent<CanvasGroup>(),1f,1f);
    }

 
    public void toggleButtons(){
        
        LeanTween.alphaCanvas(buttons.GetComponent<CanvasGroup>(),
            buttonsOpen ? 0 : 1,
            0.3f
        );

        buttonsOpen = !buttonsOpen;
    }

    public void toggleButtonsSlow(){
        
        LeanTween.alphaCanvas(buttons.GetComponent<CanvasGroup>(),
            0,0.3f);

        buttonsOpen = false;
    }
}

