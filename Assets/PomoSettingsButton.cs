using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PomoSettingsButton : MonoBehaviour
{
    [SerializeField] GameObject timerSettings;
    private bool timerSettingsOpen = false;    

    public void TimerSettings(){
        StartCoroutine("timerToggleIENUM");
    }

    IEnumerator timerToggleIENUM(){        
        if (!timerSettingsOpen) timerSettings.SetActive(true);

        LeanTween.alphaCanvas(timerSettings.GetComponent<CanvasGroup>(),
        timerSettingsOpen ? 0f : 1f, 
        0.3f).setIgnoreTimeScale(true);
        yield return new WaitForSecondsRealtime(0.3f);

        // Save data inputted to Dont Destroy On Load
        if (timerSettingsOpen){
            SettingsData.instance.SaveSettings();
        }

        timerSettings.SetActive(!timerSettingsOpen);
        timerSettings.GetComponent<CanvasGroup>().interactable = true;

        timerSettingsOpen = !timerSettingsOpen;
    }
}
