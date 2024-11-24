using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TaskListController : MonoBehaviour
{
    [SerializeField] GameObject taskTemplate;
    [SerializeField] GameObject button;

    public Transform[] taskParents;


    public static TaskListController instance;

    private bool tasksOpen = false;


    void Start(){
        instance = this;

        LoadTasks();
    }


    // if i is 0 then add to the tasks list
    // if i is 1 then add to the break tasks list
    public void AddNewTask(int i){
        Transform parent = taskParents[i];

        GameObject newTask = Instantiate(taskTemplate,parent);
        newTask.GetComponent<Task>().Initialize("New task");
    }

    public void AddNewTask(int i, string task){
        Transform parent = taskParents[i];

        GameObject newTask = Instantiate(taskTemplate,parent);
        newTask.GetComponentInChildren<TMP_InputField>().text = task;
        newTask.GetComponent<Task>().StopTyping();
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Tab)){
            ToggleTaskList();
        }
    }

    public void ToggleTaskList(){
        StartCoroutine("toggleTaskList");
    }
    IEnumerator toggleTaskList(){

        LeanTween.moveLocalX(gameObject,
            tasksOpen ? -1200f : -780f,
            0.3f
        );
        LeanTween.moveLocalX(button,
            tasksOpen ? -920f : -600f,
            0.3f
        );

        LeanTween.alphaCanvas(GetComponent<CanvasGroup>(),
            tasksOpen ? 0 : 1,
            0.3f);
        
        yield return new WaitForSecondsRealtime(0.3f);

        tasksOpen = !tasksOpen;

    }

    private void LoadTasks(){
        if (SettingsData.instance == null) return;

        foreach (string t in SettingsData.instance.tasksSave){
            AddNewTask(0, t);
        }

        foreach (string b in SettingsData.instance.breakSave){
            AddNewTask(1, b);
        }
    
    }
}
