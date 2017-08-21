using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerScript : MonoBehaviour
{
    public GameObject Trigger;
    public gameMaster gm;
    public Collider2D col;
    public GameObject Neguinho;
    public SpriteRenderer sr;
    public GameObject textoPonto;

    // Use this for initialization
    void Start()
    {
        textoPonto = GameObject.FindGameObjectWithTag("PointsText");
        textoPonto.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D col)
    {
       

            if (col.CompareTag("Pneu") || col.CompareTag("Pneu2"))
            {   gm.pneuPoints += 1;
                Destroy(col.gameObject);
                
                 if (gm.pneuPoints == 1)
            {
                gm.goalText.text = "Ache o segundo Pneu";
                gm.instText.text = "Muito bem, continue a explorar";
            }

            else if (gm.pneuPoints == 2)
            {
                gm.goalText.text = "Volte para o Jeep";
                gm.instText.text = "Agora ache um caminho de volta";
            }
            }

           
            //pneu
            else if (col.CompareTag("Truck"))
            {

            
                if (gm.pneuPoints == 1)//Quando pegou apenas um dos pneus e ja voltou par ao caminhão
                {
                    gm.goalText.text = "Ache o segundo pneu antes de voltar para o Jeep";
                    gm.instText.text = "Ainda falta buscar uma roda. Vá atrás dela!";
                }
                else if (gm.pneuPoints == 2)//Quando pegou os dois pneus
                {
                    gm.statusText.text = "";
                    gm.goalText.text = "";
                    gm.instText.text = "";
                    Time.timeScale = 0;
                gm.isComplete = true; 

                }



            }

            else if (col.CompareTag("TriggerEnd"))
            {
                gm.instText.text = "";
                gm.goalText.text = "Procure pelos pneus ";

            textoPonto.SetActive(true);
            }


            else if (col.CompareTag("Trigger1"))
            {
                gm.instText.text = "Aperte 'P' para interagir com objetos destacados";

            }



            else if (col.CompareTag("Trigger2"))
            {
                if (gm.pneuPoints == 1)
                {
                    gm.instText.text = "Você deveria olhar mais para cima!";
                }
                else if (gm.pneuPoints == 2)
                {
                    gm.instText.text = "Quase lá";
                }

                else
                {
                    gm.instText.text = "Aperte 'Barra de Espaco' para pular";
                sr.flipX = true;
                }
            }

            else if (col.CompareTag("Trigger3"))
            {
                gm.instText.text = "Optou pelo caminho mais seguro. Jogador sensato.";
            }

            else if (col.CompareTag("Trigger4"))
            {
                gm.instText.text = "Pule o mais longe que puder";
            }

        else if (col.CompareTag("Trigger5"))
        {
            gm.instText.text = "Busque o pneu";
        }
        else if (col.CompareTag("Trigger6"))
        {
            gm.instText.text = "Concentre-se" +
                "";
        }
    }
    
}




