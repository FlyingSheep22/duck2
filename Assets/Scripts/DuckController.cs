using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DuckController : MonoBehaviour
{
    private float velocity = 3f;

    void Update()
    {
        
        if (transform.position.x > 9){
            velocity = -3f;
        } else if (transform.position.x < -9){
            velocity = 3f;
        }

        transform.position = Vector3.MoveTowards(transform.position, 
            new Vector3(100, transform.position.y, transform.position.z), 
            velocity*Time.deltaTime);

    }
}
