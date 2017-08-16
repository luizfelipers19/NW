using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCharacter2D : MonoBehaviour
{
    //variaveis
    public int speed; //velocidade para andar (Definida na própria Unity)
    public float jumpForce;  //Força adicionada ao personagem no eixo Y, para pulo do personagem
    bool isGrounded; //booleana que marca se o personagem está no chão ou não
    float shootTimer = .2f; //variável para tiros, ainda não utilizada
    public bool isDead; //booleana que marca a situação do jogador (morto ou vivo)

    //stats
    public int curHealth; //variável referente à vida atual do jogador
    public int maxHealth = 100; //variável referente à vida Máxima do jogaodr 
    

        //------

    //componentes  - decarados para serem referenciados na Unity em outros coponentes
    public AudioClip[] audioclip;
    public Rigidbody2D rig;
    private SpriteRenderer myRenderer;
    public Animator anim;
    private gameMaster gm;


    // Use this for initialization
    void Start()
    {
        myRenderer = GetComponent<SpriteRenderer>();//Associa o Sprite Renderer do objeto á variavel myRenderer, no comeco do jogo	
        isGrounded = true;
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<gameMaster>();
        isDead = false;

        curHealth = maxHealth;//Jogador começa o jogo com vida maxima 
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

        if(curHealth > maxHealth) //Caso a vida atual seja maior que a vida Maxima, a vida atual recebe o valor menor da vida max.
        {
            curHealth = maxHealth;
        }
        if (curHealth <= 0)
        {
            Die();

        }
    }
    



    //funções criadas --Olhar dentro de cada uma

    void Movement()//função que controla os movimentos do personagem
    {          
        if(Input.GetMouseButtonDown(0))//Quando o botão esquerdo do mouse for pressionado, a animação de Tiro será acionada
        {
            anim.SetBool("isShooting", true);   
        }
        
        //Caso a tecla pressionada for a barra de espaço, o personagem pula
        if (Input.GetKeyDown(KeyCode.Space))//Caso o Espaço for pressionado, o jogador pula
        {
            if (isGrounded == true)// só pula se o jogador estiver encostado em algo, para evitar pulo duplo
            {


                rig.AddForce(Vector2.up * jumpForce);//Adiciona uma força ao RigidBody. Vector 2 indica um vetor de duas direçoes. 
                anim.SetBool("isShooting", false);                                     //Para calcular o pulo, usa Up * força
                isGrounded = false;//tira o jogador do chão
            }
        }

        else if (Input.GetKey(KeyCode.D))//caso a tecla for a letra D, o jogador anda pra direita
        {
            anim.SetBool("isWalking", true);//ativa a booleana isWalking, para funcionar com as condições do Animator
            anim.SetBool("isShooting", false);
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));//calculo do movimento para direita
            myRenderer.flipX = false;// falso, pois o sprite do personagem é para direita, então nao precisa virar
        }

        else if (Input.GetKey(KeyCode.A))//caso a tecla for a letra A, o jogador anda pra esquerda
        {
            anim.SetBool("isWalking", true);//liga a booleana isWalking
            anim.SetBool("isShooting", false);
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));//calcula o movimento para esquerda, pois a velocidade é negativa
            myRenderer.flipX = true;//gira o sprite, pois o sprite original é virado para a direita
        }

        else
        {
            anim.SetBool("isWalking", false);
        }
    }

    void OnCollisionEnter2D(Collision2D col)//função que processa toques e colisões entre os objetos
        {
            if (col.gameObject.tag == "Ground" ||col.gameObject.tag == "Plank" || col.gameObject.tag == "Column")
            {
                isGrounded = true;      //Caso a tag do objetos colisor seja alguma dessas, o player poderá andar com animação feita sobre eles
            anim.SetBool("isGrounded", true);
            }
        }

        private void OnTriggerEnter2D(Collider2D col) //função dos Colliders2D que processa passagem em um Trigger
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
            }//Momento que pega o segundo Pneu
        }//Comandos para quando o jogador recolhe (colide) um pneu

      else if (col.CompareTag("Truck"))//Quando o Jogador encosta no Jeep
        {   
            if (gm.pneuPoints == 1)
            {
                gm.goalText.text = "Ache o segundo pneu antes de voltar para o Jeep";
                gm.instText.text = "Ainda falta buscar uma roda. Vá atrás dela!";
            }//falta um
            else if (gm.pneuPoints == 2)
            {
                gm.statusText.text = "Missao cumprida";
                gm.goalText.text = "Boa mlk";
                gm.instText.text = "Você joga bem demais!";
                gm.missionComplete = true;
            }//Missão cumprida
            
            
            
        }

        else if (col.CompareTag("Trigger1"))
        {
            gm.instText.text = "Use 'A' ou 'D' para movimentar seus personagens.";
            gm.goalText.text = "Encontre o pneu perdido";
        }//Quando passa pelo primeiro trigger da UI


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
        }//Quando passa pelo segundo trigger da UI

        else if (col.CompareTag("Trigger3"))
        {
            gm.instText.text = "Só vai mano, confia! Pula pra lá!";
        }//Quando passa pelo terceiro trigger da UI

        else if (col.CompareTag("Trigger4"))
        {
            gm.instText.text = "Boa carai, tamo chegando!";
        }//Quando passa pelo quarto trigger da UI

        else if (col.CompareTag("Sea"))
        {
            gm.statusText.text = "Se fodeu";
            Die();
        }// Quando encosta no mar (morre)

        if (gm.missionComplete == true)
        {
            
        }// Quando o jogador recolheu os 2 pneus e voltou para o Jeep


    }

    void Die()
    {
        gm.statusText.text = "Se fodeu";
        //Restart
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    } //função declarada que Mata o personagem.

       
        
}

    

