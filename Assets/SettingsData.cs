using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsData : MonoBehaviour
{
    public static SettingsData instance;

    // INPUT REFERNECES
    [SerializeField] TMP_InputField focusInput;
    [SerializeField] TMP_InputField breakInput;

    [SerializeField] TMP_InputField reminderInput;


    // First time run
    public bool first {get;set;} = true;

    // DATA
    public int focusTime = 25;
    public int breakTime = 5;

    public int endReminder = 5;

    void Awake(){
        Debug.Log("here");
        if (instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }


    public void SaveSettings(){
        Debug.Log("here 2");
        focusTime = string.IsNullOrWhiteSpace(focusInput.text) ? 25 : int.Parse(focusInput.text);
        breakTime = string.IsNullOrWhiteSpace(breakInput.text) ? 5 : int.Parse(breakInput.text);

        endReminder = string.IsNullOrWhiteSpace(reminderInput.text) ? 5 : int.Parse(reminderInput.text);

        Debug.Log("timer settings have been saved");
        Debug.Log(focusInput.text);
    }
}
