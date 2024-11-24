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
    public int direction = 1; // 1 for right-to-left, -1 for left-to-right
    
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

        while(seconds <= 2.4f)
        {
            seconds += Time.deltaTime;
            rt.anchoredPosition += new Vector2(-40 * direction * Time.deltaTime, 0);
            yield return null;
        }

        anim.SetTrigger("Confetti");
        yield return new WaitForSeconds(1.25f);

        anim.SetTrigger("WalkingConfetti");
        yield return new WaitForSeconds(0.2f);
        scale = rt.localScale;
        scale.x *= -1; // Invert the X scale
        rt.localScale = scale;
        rt.anchoredPosition = new Vector2(rt.anchoredPosition.x+(50*direction), rt.anchoredPosition.y);
        
        while (seconds <= (2.4f*2))
        {
            seconds += Time.deltaTime;
            rt.anchoredPosition += new Vector2(40 * direction * Time.deltaTime, 0);
            yield return null;
        }
        
        scale = rt.localScale;
        scale.x *= -1; // Invert the X 
        rt.localScale = scale;
        rt.anchoredPosition = new Vector2(rt.anchoredPosition.x-(50*direction), rt.anchoredPosition.y);
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
