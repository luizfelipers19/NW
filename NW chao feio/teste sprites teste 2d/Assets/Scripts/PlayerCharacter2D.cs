using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCharacter2D : MonoBehaviour
{

    public int speed;
    private SpriteRenderer myRenderer;
    public Animator anim;
    public float jumpForce;
    public Rigidbody2D rig;
    bool isGrounded;
    float shootTimer = .2f;
    private gameMaster gm;
    public AudioClip[] audioclip;
    
    

    // Use this for initialization
    void Start()
    {
        myRenderer = GetComponent<SpriteRenderer>();//Associa o Sprite Renderer do objeto á variavel myRenderer, no comeco do jogo	
        isGrounded = true;
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<gameMaster>();
        gm.isDead = false;

    }
    // Update is called once per frame
    void Update()
    {
        Movement();
        if (isGrounded == true)
        {
            anim.SetBool("isGrounded", true);
        }
        else
        {
            anim.SetBool("isGrounded", false);
        }
        if (rig.velocity.y < 0) {
            rig.velocity += Vector2.up * Physics2D.gravity.y * 3 * Time.deltaTime;
        }
    }

    void Movement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("isShooting", true);
        }

        //Caso a tecla pressionada for a barra de espaço, o personagem pula
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded == true)
            {


                rig.AddForce(Vector2.up * jumpForce);//Adiciona uma força ao RigidBody. Vector 2 indica um vetor de duas direçoes. 
                anim.SetBool("isShooting", false);                                     //Para calcular o pulo, usa Up * força
                isGrounded = false;
            }
        }

        else if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isWalking", true);
            anim.SetBool("isShooting", false);
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            myRenderer.flipX = false;
        }

        else if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("isWalking", true);
            anim.SetBool("isShooting", false);
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
            myRenderer.flipX = true;
        }

        else
        {
            anim.SetBool("isWalking", false);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground" || col.gameObject.tag == "Plank" || col.gameObject.tag == "Column")
        {
            isGrounded = true;
            anim.SetBool("isGrounded", true);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Pneu") || col.CompareTag("Pneu2"))
        {
            Destroy(col.gameObject);
            gm.pneuPoints += 1;

            if (gm.pneuPoints == 1)
            {
                gm.goalText.text = "Ache o segundo Pneu";
                gm.instText.text = "Muito bem, agora ache um caminho que leve ao segundo pneu";
            }

            if (gm.pneuPoints == 2)
            {
                gm.goalText.text = "Volte para o Jeep";
                gm.instText.text = "Agora acha um caminho de volta";
            }
        }

        else if (col.CompareTag("Truck"))
        {
            if (gm.pneuPoints == 1)//Quando pegou apenas um dos pneus e ja voltou par ao caminhão
            {
                gm.goalText.text = "Ache o segundo pneu antes de voltar para o Jeep";
                gm.instText.text = "Ainda falta buscar uma roda. Vá atrás dela!";
            }
            else if (gm.pneuPoints == 2)//Quando pegou os dois pneus
            {
                gm.statusText.text = "Missao cumprida";
                gm.goalText.text = "Boa mlk";
                gm.instText.text = "Você joga bem demais!";
                Time.timeScale = 0;
            }



        }

        else if (col.CompareTag("Trigger1"))
        {
            gm.instText.text = "Use 'A' ou 'D' para movimentar seus personagens.";
            gm.goalText.text = "Encontre o pneu perdido";
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
            }
        }

        else if (col.CompareTag("Trigger3"))
        {
            gm.instText.text = "Só vai mano, confia! Pula pra lá!";
        }

        else if (col.CompareTag("Trigger4"))
        {
            gm.instText.text = "Boa carai, tamo chegando!";
        }

        else if (col.CompareTag("Sea"))
        {
           
            Die();
        }

    }
         void Die()
        {
        gm.isDead = true; //toggla a variavel como true para que a DeadUI seja acionada
            
            
           
        } //função declarada que Mata o personagem.


    }

   
        


    

