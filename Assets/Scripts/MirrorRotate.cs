using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorRotate : MonoBehaviour
{
    private float speed = 10.0f;
    private float horizontalInput;
    private float forwardInput;

    // Update is called once per frame

    void Update()
    {
        
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        //We move vehicle forward
        transform.Rotate(Vector3.forward, Time.deltaTime * speed * forwardInput);


        transform.Rotate(Vector3.up, Time.deltaTime * speed * horizontalInput);
    }

}
