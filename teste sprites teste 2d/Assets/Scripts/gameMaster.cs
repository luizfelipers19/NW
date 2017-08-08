using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameMaster : MonoBehaviour {

   
    public int pneuPoints = 0;
    public Text pointsText;
    public Text instText;
    public Text goalText;

    private void Update()
    {
        pointsText.text = ("Pneus: " + pneuPoints);
        instText.text = (instText.text);
        goalText.text = (goalText.text);
    }
}
