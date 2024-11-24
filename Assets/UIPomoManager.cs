using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIPomoManager : MonoBehaviour
{
    [SerializeField] TMP_InputField focusInput;
    [SerializeField] TMP_InputField breakInput;

    [SerializeField] Toggle autoPomoToggle;
    [SerializeField] Toggle autoBreakToggle;

    [SerializeField] TMP_InputField reminderInput;

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

            autoPomoToggle.isOn = instance.autoStartPomo;
            autoBreakToggle.isOn = instance.autoStartBreak;

            reminderInput.text = instance.endReminder.ToString();
        }
    }
}
