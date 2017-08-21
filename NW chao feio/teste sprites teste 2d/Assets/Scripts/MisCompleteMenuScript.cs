using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MisCompleteMenuScript : MonoBehaviour {

    public GameObject MCompleteUI;
    public gameMaster gm;

    // Use this for initialization
    void Start () {
        MCompleteUI.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

        if (gm.isComplete == true)
        {
            MCompleteUI.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
           MCompleteUI.SetActive(false);
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
