using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AnimationBehaviourController : MonoBehaviour
{
    public Animator anim;
    private RectTransform rt;
    [SerializeField] TextMeshProUGUI message;

    private float eventInterval = 300f;
    private int[] Triggers = {0,1,0,1,2};
    private int currentEvent = 0;


    void Awake(){
        anim = GetComponent<Animator>();
        rt = GetComponent<RectTransform>();
    }

    public void SetIdle(){
        anim.SetTrigger("Resting");
    }

    public void SetStretch(){
        anim.SetTrigger("Stretch");
        StartCoroutine(SetMessage("Time to stretch!"));
    }

    public void SetWater(){
        StartCoroutine("WaterSequence");
    }

    IEnumerator WaterSequence(){
        float seconds = 0f;
        
        Vector3 scale = rt.localScale;
        scale.x *= -1; // Invert the X scale
        rt.localScale = scale;


        anim.SetTrigger("Walking");

        while(rt.position.x >= -95){
            seconds += Time.deltaTime;
            rt.anchoredPosition += new Vector2(-70 * Time.deltaTime, 0);
            yield return null;
        }

        scale = rt.localScale;
        scale.x *= -1; // Invert the X scale
        rt.localScale = scale;


        anim.SetTrigger("Water");
        rt.anchoredPosition = new Vector2(rt.anchoredPosition.x, 140);
        

        while (rt.anchoredPosition.x <= 125){
            seconds += Time.deltaTime;
            rt.anchoredPosition += new Vector2(60 * Time.deltaTime, 0);
            yield return null;
        }
        StartCoroutine(SetMessage("Time to drink some water!"));

    }


    public void SetWalk(){
        anim.SetTrigger("Walk");
    }


    public void SetCelebrate(){
        anim.SetTrigger("PomoDone");
    }


    void Update(){
        if (Input.GetKeyDown(KeyCode.S)){
            SetStretch();
        }
        else if (Input.GetKeyDown(KeyCode.W)){
            SetWater();
        }


        EventTimerRun();

    }



    private void EventTimerRun(){
        eventInterval -= Time.deltaTime;

        if (eventInterval >= 0){
            return;

        } else {

            eventInterval = 300f;

            switch (currentEvent)
            {
                case 0:
                    SetStretch();
                    break;

                case 1:
                    SetWater();
                    break;

                case 2:
                    SetWalk();
                    break;

                default:
                    break;
            }

            currentEvent = ++currentEvent % 5;
        }
    }


    IEnumerator SetMessage(string messagetext){
        message.transform.parent.gameObject.SetActive(true);
        message.text = messagetext;

        LeanTween.alphaCanvas(message.transform.parent.GetComponent<CanvasGroup>(),
        1f, 0.5f);
        yield return new WaitForSecondsRealtime(0.5f);

        yield return new WaitForSecondsRealtime(1f);

        LeanTween.alphaCanvas(message.transform.parent.GetComponent<CanvasGroup>(),
        0f, 0.5f);
        yield return new WaitForSecondsRealtime(0.5f);
        message.transform.parent.gameObject.SetActive(false);
    }
}
