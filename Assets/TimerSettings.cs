using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerSettings : MonoBehaviour
{

    [SerializeField] TMP_InputField focusIn;
    [SerializeField] TMP_InputField breakIn;
    [SerializeField] TMP_InputField reminderIn;

    void Start()
    {
        SettingsData.instance.focusInput = focusIn;
        SettingsData.instance.breakInput = breakIn;
        SettingsData.instance.reminderInput = reminderIn;
    }
}
