using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameMaster : MonoBehaviour {

    public bool isComplete = false;
    public bool isDead = false;

    public int pneuPoints = 0;
    public Text interacaoSinalText;
    public Text pointsText;
    public Text instText;
    public Text goalText;
    public Text statusText;

    private void Update()
    {   
       

        pointsText.text = ("Pneus coletados:" + pneuPoints);
        instText.text = (instText.text);
        goalText.text = (goalText.text);
        statusText.text = (statusText.text);
        interacaoSinalText.text = (interacaoSinalText.text);
    }
}
