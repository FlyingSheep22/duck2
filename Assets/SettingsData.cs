using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsData : MonoBehaviour
{
    public static SettingsData instance;

    // INPUT REFERNECES
    [SerializeField] TMP_InputField focusInput;
    [SerializeField] TMP_InputField breakInput;

    [SerializeField] TMP_InputField reminderInput;

    public string[] tasksSave;
    public string[] breakSave;


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


    public void SaveTasks(){
        // Get all components of type Transform in the children (including the parent itself).
        Task[] childTasks = TaskListController.instance.taskParents[0].GetComponentsInChildren<Task>();
        Task[] childBreaks = TaskListController.instance.taskParents[1].GetComponentsInChildren<Task>();

        // Convert to an array of GameObjects
        string[] tasks = new string[childTasks.Length];
        for (int i = 0; i < childTasks.Length; i++)
        {
            tasks[i] = childTasks[i].input.text;
        }

        string[] breaktasks = new string[childBreaks.Length];
        for (int i = 0; i < childBreaks.Length; i++)
        {
            breaktasks[i] = childBreaks[i].input.text;
        }

        tasksSave = tasks;
        breakSave = breaktasks;
    }

    // public void LoadTasks(){
    //     if (TaskListController.instance == null) return;

    //     foreach (GameObject t in tasksSave){
    //         TaskListController.instance.AddNewTask(0, t);
    //     }

    //     foreach (GameObject b in breakSave){
    //         TaskListController.instance.AddNewTask(1, b);
    //     }
    // }
    
}
