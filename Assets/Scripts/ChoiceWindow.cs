using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoiceWindow : MonoBehaviour
{
    // Start is called before the first frame update
    public void Zamykanie()
    {
        Application.Quit();
        Debug.Log("Zamykanie...");
        GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
    }
    public void ChoisedLevel(int level)
    {
        string levelName = "Level" + level;
        SceneManager.LoadScene(levelName);
    }
   
}
