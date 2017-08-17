using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager    : MonoBehaviour {

    public GameObject dBox;
    public Text dText;

    public bool dialogActive;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(dialogActive && Input.GetKeyDown(KeyCode.R))
        {
            dBox.SetActive(false);
            dialogActive = false;
            Time.timeScale = 1;
        }
	}
    public void ShowBox(string dialogue)
    {
        
        dialogActive = true;
        dBox.SetActive(true);
        dText.text = dialogue;
        Time.timeScale = 0;
    }
    

}
