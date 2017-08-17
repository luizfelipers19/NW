using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadMenuScript : MonoBehaviour
{

    public GameObject DeadUI;
    public gameMaster gm;



    // Use this for initialization
    void Start()
    {
        DeadUI.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        if (gm.isDead == true)
        {
            DeadUI.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            DeadUI.SetActive(false);
            Time.timeScale = 1;
        }

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}