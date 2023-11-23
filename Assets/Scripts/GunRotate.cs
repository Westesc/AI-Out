using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotate : MonoBehaviour
{
    private float speed1 = 10.0f;
    private float speed2 = 10.0f;
    private float horizontalInput;
    private float VerticalInput;
    private float timer1;
    private float timer2;
    // Update is called once per frame

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");
        if(VerticalInput == 0)
        {
            timer1 = 0;
            speed1 = 10.0f;
        }
        else
        {
            timer1 += Time.deltaTime;
            if (timer1 > 1 && timer1 <1.9)
            {
                speed1 += 1.0f;
            }
        }
        if (horizontalInput == 0)
        {
            timer2 = 0;
            speed2 = 10.0f;
        }
        else
        {
            timer2 += Time.deltaTime;
            if (timer2 > 1 && timer2<1.9)
            {
                speed2 += 1.0f;
            }
        }
        //We rotate gun up and down
        transform.Rotate(Vector3.forward, Time.deltaTime * speed1 * VerticalInput); 
        //We move gun right and left
        transform.Rotate(Vector3.up, Time.deltaTime * speed2 * horizontalInput);
    }
}
