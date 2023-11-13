using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    private float rotationSpeed = 200f;
    Camera cam;
    private bool isRotating = false;
    public void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {
        
         if (Input.GetMouseButtonDown(0))
         {
             isRotating = !isRotating;
         }


         if (isRotating)
         {
             Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
             Vector3 diff = mousePosition - transform.position;
             diff.Normalize();
             float rotationZ = Mathf.Atan2(diff.y, diff.z)*Mathf.Rad2Deg;
             transform.rotation = Quaternion.Euler(0f, 0f, -rotationZ+180);
         }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 11f);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, -11f);
        }
    }
}
