using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SideMenu : MonoBehaviour
{
    public GameObject sideMenu;
    public GameObject timer;

    // Start is called before the first frame update
    void Start()
    {
        sideMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            sideMenu.SetActive(!sideMenu.activeSelf);
            timer.GetComponent<OdliczanieCzasu>().isPaused = !timer.GetComponent<OdliczanieCzasu>().isPaused;
            Debug.Log("true");
        }
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void Resume()
    {
        sideMenu.SetActive(!sideMenu.activeSelf);
        timer.GetComponent<OdliczanieCzasu>().isPaused = !timer.GetComponent<OdliczanieCzasu>().isPaused;
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
