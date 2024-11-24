using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Task : MonoBehaviour
{

    public TMP_InputField input;

    public void Initialize(string task){
        GetComponentInChildren<TextMeshProUGUI>().text = task;
    }

    void Start(){
        input = GetComponentInChildren<TMP_InputField>();
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

        input = GetComponentInChildren<TMP_InputField>();

        if (string.IsNullOrWhiteSpace(input.text))
        {
            Debug.Log("Input field is empty. Not disabling the field.");
            return; // Exit if no text was entered
        }

        StartCoroutine("stopTyping");
    }

    IEnumerator stopTyping(){
        
        if (EventSystem.current.currentSelectedGameObject == input.gameObject)
        {

            yield return new WaitForEndOfFrame();

            EventSystem.current.SetSelectedGameObject(null);
        }

        // yield return new WaitForEndOfFrame();

        input.interactable = false;
        input.GetComponent<Image>().enabled = false;    
    }
}
