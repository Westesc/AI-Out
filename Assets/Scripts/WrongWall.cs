using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrong : MonoBehaviour
{
    public GameObject message;
    public GameObject wall1;
    public GameObject wall2;
    public float wall1DesirePositon;
    public float wall2DesirePositon;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (wall1.transform.localPosition.z == wall1DesirePositon && wall2.transform.localPosition.z != wall2DesirePositon)
        {
            message.SetActive(true);
        }
    }
}