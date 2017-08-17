using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntHolder : MonoBehaviour {

    private ShowInstruction si;
    public string instrucao;

	// Use this for initialization
	void Start () {
        si = FindObjectOfType<ShowInstruction>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
                       
                si.ShowIntAction(instrucao);

            }
        }
    }

