using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotate : MonoBehaviour
{
    private float speed = 15.0f;
    private float horizontalInput;
    private float VerticalInput;
    int tmp = 0;

    void Start()
    {
        LaserBeam.ctrl[0] = GameObject.FindWithTag("Gun");

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            tmp++;
            if (tmp > LaserBeam.ctrlN - 1)
            {
                tmp = 0;
            }
        }
        if (LaserBeam.ctrl[tmp] == this.gameObject)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            VerticalInput = Input.GetAxis("Vertical");
        }
        //We rotate gun up and down
        Debug.Log(tmp);
        transform.Rotate(Vector3.forward, Time.deltaTime * speed * VerticalInput); 
        //We move gun right and left
        transform.Rotate(Vector3.up, Time.deltaTime * speed * horizontalInput);
    }
}
