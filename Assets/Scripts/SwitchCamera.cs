using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    int indexOfActiveCamera = 0;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<Camera>().enabled = false;
            transform.GetChild(i).GetComponent<AudioListener>().enabled = false;
        }
        transform.GetChild(indexOfActiveCamera).GetComponent<Camera>().enabled = true;
        transform.GetChild(indexOfActiveCamera).GetComponent<AudioListener>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) 
        {
            Debug.Log("zmieniam na kamere ni¿ej");
            transform.GetChild(indexOfActiveCamera).GetComponent<Camera>().enabled = false;
            transform.GetChild(indexOfActiveCamera).GetComponent<AudioListener>().enabled = false;
            indexOfActiveCamera--;
            if (indexOfActiveCamera < 0)
                indexOfActiveCamera = transform.childCount-1;
            transform.GetChild(indexOfActiveCamera).GetComponent<Camera>().enabled = true;
            transform.GetChild(indexOfActiveCamera).GetComponent<AudioListener>().enabled = true;
        } else if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("zmieniam na kamere wy¿ej");
            transform.GetChild(indexOfActiveCamera).GetComponent<Camera>().enabled = false;
            transform.GetChild(indexOfActiveCamera).GetComponent<AudioListener>().enabled = false;
            indexOfActiveCamera++;
            indexOfActiveCamera %= transform.childCount;
            transform.GetChild(indexOfActiveCamera).GetComponent<Camera>().enabled = true;
            transform.GetChild(indexOfActiveCamera).GetComponent<AudioListener>().enabled = true;
        }
    }
    public void ChangeCamera(int index)
    {
        transform.GetChild(indexOfActiveCamera).GetComponent<Camera>().enabled = false;
        transform.GetChild(indexOfActiveCamera).GetComponent<AudioListener>().enabled = false;
        indexOfActiveCamera = index;
        transform.GetChild(index).GetComponent<Camera>().enabled = true;
        transform.GetChild(index).GetComponent<AudioListener>().enabled = true;
    }
}
