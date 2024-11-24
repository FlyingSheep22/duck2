using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ConfettiAnimationScript : MonoBehaviour
{
    public Animator anim;
    private RectTransform rt; 
    
    void Awake()
    {
        anim = GetComponent<Animator>();
        rt = GetComponent<RectTransform>();
    }
    
    public void callConfetti() 
    {
        StartCoroutine("ConfettiSequence");
        Debug.Log("confetti called");
    }

    IEnumerator ConfettiSequence()
    {
        float seconds = 0f;
        
        Vector3 scale = rt.localScale;
        //scale.x *= -1; // Invert the X scale
        rt.localScale = scale;

        Debug.Log(rt.position.x);
        while(rt.position.x >= 700)
        {
            Debug.Log(rt.position.x);
            seconds += Time.deltaTime;
            rt.anchoredPosition += new Vector2(-90 * Time.deltaTime, 0);
            yield return null;
        }

        anim.SetTrigger("Confetti");
        yield return new WaitForSecondsRealtime(1.25f);

        anim.SetTrigger("WalkingConfetti");
        yield return new WaitForSecondsRealtime(0.2f);
        scale = rt.localScale;
        scale.x *= -1; // Invert the X scale
        rt.localScale = scale;
        rt.anchoredPosition = new Vector2(rt.anchoredPosition.x+150, rt.anchoredPosition.y);
        
        while (rt.anchoredPosition.x <= 1200){
            seconds += Time.deltaTime;
            rt.anchoredPosition += new Vector2(90 * Time.deltaTime, 0);
            yield return null;
        }
        
        scale = rt.localScale;
        scale.x *= -1; // Invert the X 
        rt.localScale = scale;
        rt.anchoredPosition = new Vector2(rt.anchoredPosition.x-150, rt.anchoredPosition.y);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
