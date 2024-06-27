using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    int currentText = 0;
    // Start is called before the first frame update
    void Start()
    {
        transform.transform.GetChild(0).gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space)) {
            transform.transform.GetChild(currentText).gameObject.SetActive(false);
            if (currentText < transform.transform.childCount -1)
            {
                currentText++;
                transform.transform.GetChild(currentText).gameObject.SetActive(true);
            }
            else
            {
                transform.gameObject.SetActive(false);
            }
        }
        if (Input.GetKeyUp(KeyCode.Return))
        {
            transform.gameObject.SetActive(false);
        }
    }
}
