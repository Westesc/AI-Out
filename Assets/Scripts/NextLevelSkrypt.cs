using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelSkrypt : MonoBehaviour
{

    public void Zamykanie()
    {
        Application.Quit();
        Debug.Log("Zamykanie...");
        GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
    }
    public void Next()
    {
        
        SceneManager.LoadScene(PlayerPrefs.GetInt("lastLevel")+1);
    }
    public void Repeate()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("lastLevel"));
    }
}
