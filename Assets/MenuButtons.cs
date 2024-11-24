using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] GameObject timerSettings;
    [SerializeField] DuckControls duck;

    private bool timerSettingsOpen = false;

    public void StartPomo(){
        SceneManager.LoadScene(1);
    }


    public void StartIdle(){

    }


    public void TimerSettings(){
        StartCoroutine("timerToggleIENUM");
    }

    IEnumerator timerToggleIENUM(){
        duck.toggleButtons();
        
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

        UIManager.instance.State = timerSettingsOpen ? "menuButtons" : "timerSettings";
        timerSettingsOpen = !timerSettingsOpen;
    }


    public void Close()
    {
        
        Application.Quit();
    }
}
