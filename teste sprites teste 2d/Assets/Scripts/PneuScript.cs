using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PneuScript : MonoBehaviour
{

    static bool isColliding;



    private void Start()
    {
        isColliding = false;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            isColliding = true;

            if (isColliding == true)
            {

                Destroy(gameObject);


            }

        }
    }
