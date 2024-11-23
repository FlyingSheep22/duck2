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
    public int focusTime;
    public int breakTime;

    public int endReminder;

    public bool autoStartPomo;
    public bool autoStartBreak;

    void Awake(){
        if (instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }


    public void SaveSettings(){
        focusTime = int.Parse(focusInput.text);
        breakTime = int.Parse(breakInput.text);

        autoStartPomo = autoPomoToggle.isOn;
        autoStartBreak = autoBreakToggle.isOn;

        endReminder = int.Parse(reminderInput.text);

        Debug.Log("timer settings have been saved");
    }

    
}
