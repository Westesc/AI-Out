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
    }
    void Update()
    {
        if (change)
        {
            material.color = startColor;
            change = false;
        }
        if (isCollider && !change)
        {
            material.color = endColor;
            change = true;
            isCollider = false;
        }
    }
}
