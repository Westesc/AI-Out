using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SkryptyMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void Zamykanie()
    {
        Application.Quit();
        Debug.Log("Zamykanie...");
        GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
    }
    public void Zaczynamy()
    {
        SceneManager.LoadScene("Level1"); 
    }
    public void Wybierz()
    {
        SceneManager.LoadScene("ChoiceLevel");
    }
    public void Powrót()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void Wzów()
    {

    }
}
