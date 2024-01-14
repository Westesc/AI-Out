using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScrpit : MonoBehaviour
{
    public bool isCollider = false;
    private bool change = false;
    private Material material;
    public Color endColor;
    public Color startColor;
    public float smoothTime = 2.0f;
    private Vector3 targetPosition;
    private Vector3 initialPosition;
    public float newX = -56f;
    // Update is called once per frame
    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();

        if (renderer != null)
        {
            material = renderer.material;
        }
        else
        {
            Debug.LogError("Renderer component not found on GameObject!");
        }
        startColor = material.color;
        targetPosition = transform.position;
        initialPosition = transform.position;
    }
    void Update()
    {
        if (change)
        {
            material.color = startColor;
            change = false;
            //if (initialPosition != targetPosition)
            //{
               // transform.position = Vector3.Lerp(transform.position, initialPosition, smoothTime * Time.deltaTime);
           // }
        }

        if (isCollider && !change)
        {
            material.color = endColor;

            targetPosition = new Vector3(newX, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothTime * Time.deltaTime);

            change = true;
            isCollider = false;
        }
    }
}
