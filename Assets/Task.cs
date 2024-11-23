using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Task : MonoBehaviour
{

    public void Initialize(string task){
        GetComponentInChildren<TextMeshProUGUI>().text = task;
    }

    public void CompleteTask(){
        StartCoroutine("completeTask");
    }
    IEnumerator completeTask(){
        LeanTween.alphaCanvas(GetComponent<CanvasGroup>(),
        0,0.4f);
        yield return new WaitForSecondsRealtime(0.4f);
        Destroy(gameObject);
    }

    public void StopTyping(){
        TMP_InputField input = GetComponentInChildren<TMP_InputField>();
        
        if (string.IsNullOrWhiteSpace(input.text))
        {
            Debug.Log("Input field is empty. Not disabling the field.");
            return; // Exit if no text was entered
        }

        input.interactable = false;
        input.GetComponent<Image>().enabled = false;    
    }
}
