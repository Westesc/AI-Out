using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WrongObject : MonoBehaviour
{
    public bool isCollider  = false;
    void Update()
    {
        if (isCollider)
        {
             Invoke("ExampleMethod", 2.0f);
        }
    }
    void ExampleMethod()
    {
        SceneManager.LoadScene("LoseScene");
    }
}
