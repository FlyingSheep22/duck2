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
            focusInput.text = string.IsNullOrWhiteSpace(instance.focusTime.ToString()) ? 25.ToString() : instance.focusTime.ToString();
            breakInput.text = string.IsNullOrWhiteSpace(instance.breakTime.ToString()) ? 5.ToString() : instance.breakTime.ToString();

            autoPomoToggle.isOn = instance.autoStartPomo;
            autoBreakToggle.isOn = instance.autoStartBreak;

            reminderInput.text = string.IsNullOrWhiteSpace(instance.endReminder.ToString()) ? 5.ToString() : instance.endReminder.ToString();
        }
    }
}
