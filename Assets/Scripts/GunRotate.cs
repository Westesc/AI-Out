using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotate : MonoBehaviour
{
    private float speed = 10.0f;
    private float horizontalInput;
    private float VerticalInput;
    private float timer1;
    private float timer2;
    // Update is called once per frame

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 50.0f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 10.0f;
        }
        //We rotate gun up and down
        transform.Rotate(-Vector3.forward, Time.deltaTime * speed * VerticalInput); 
        //We move gun right and left
        transform.Rotate(Vector3.up, Time.deltaTime * speed * horizontalInput);
    }
}
