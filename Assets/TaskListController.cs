using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskListController : MonoBehaviour
{
    [SerializeField] GameObject taskTemplate;
    [SerializeField] GameObject button;

    [SerializeField] Transform[] taskParents;

    private bool tasksOpen = false;

    // if i is 0 then add to the tasks list
    // if i is 1 then add to the break tasks list
    public void AddNewTask(int i){
        Transform parent = taskParents[i];

        GameObject newTask = Instantiate(taskTemplate,parent);
        newTask.GetComponent<Task>().Initialize("new task");
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
            tasksOpen ? -1000f : -780f,
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
}
