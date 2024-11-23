using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
}
