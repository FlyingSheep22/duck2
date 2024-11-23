using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBehaviourController : MonoBehaviour
{
    private Animator anim;

    void Awake(){
        anim = GetComponent<Animator>();
    }

    public void SetIdle(){
        anim.SetTrigger("Resting");
    }

    public void SetStretch(){
        anim.SetTrigger("Stretch");


    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.S)){
            SetStretch();
        }
    }
}
