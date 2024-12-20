using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIPomoManager : MonoBehaviour
{
    [SerializeField] TMP_InputField focusInput;
    [SerializeField] TMP_InputField breakInput;
    [SerializeField] TMP_InputField reminderInput;
    [SerializeField] PomoSettingsButton settingsButton;

    public static SettingsData instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = SettingsData.instance;
        if (instance == null){
            Debug.Log("settings data object not found!");
        } else {
            focusInput.text = instance.focusTime.ToString();
            breakInput.text = instance.breakTime.ToString();

            reminderInput.text = instance.endReminder.ToString();
        }

    }
    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape)){
            EscapeFunction();
        }
    }
    private void EscapeFunction(){
        settingsButton.TimerSettings();
    }
}
