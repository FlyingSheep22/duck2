using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PomoTimerSettings : MonoBehaviour
{
    [SerializeField] CountDown cd;
    [SerializeField] TMP_InputField focusInput;
    [SerializeField] TMP_InputField breakInput;
    [SerializeField] TMP_InputField reminderInput;


    void Start(){
    }

    public void UpdateFocus(){
        cd.ChangeFocusTime(int.Parse(focusInput.text));    
    }

    public void UpdateBreak(){
        cd.ChangeBreakTime(int.Parse(breakInput.text));

    }
}
