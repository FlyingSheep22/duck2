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

    [SerializeField] Toggle autoPomoToggle;
    [SerializeField] Toggle autoBreakToggle;

    [SerializeField] TMP_InputField reminderInput;


    // DATA
    public int focusTime = 25;
    public int breakTime = 5;

    public int endReminder = 5;

    public bool autoStartPomo = true;
    public bool autoStartBreak = true;

    void Awake(){
        if (instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }


    public void SaveSettings(){
        focusTime = string.IsNullOrWhiteSpace(focusInput.text) ? 25 : int.Parse(focusInput.text);
        breakTime = string.IsNullOrWhiteSpace(breakInput.text) ? 5 : int.Parse(breakInput.text);
        
        autoStartPomo = autoPomoToggle.isOn;
        autoStartBreak = autoBreakToggle.isOn;

        endReminder = string.IsNullOrWhiteSpace(reminderInput.text) ? 5 : int.Parse(reminderInput.text);

        Debug.Log("timer settings have been saved");
    }

    
}