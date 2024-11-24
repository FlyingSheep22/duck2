using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitToMain : MonoBehaviour
{

    [SerializeField] PomoDuckControls duck;

    public void Quit(){
        StartCoroutine("quitToMain");
    }

    IEnumerator quitToMain(){
        duck.toggleButtonsSlow();
        yield return new WaitForSecondsRealtime(0.3f);
        SceneManager.LoadScene(0);
    }
}