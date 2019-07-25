using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    //Variaveis para ajuste
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private float velocidadeDePulo = 1.0f;
    [SerializeField] private float alturaDoPulo = 3.0f;
    [SerializeField] private float gravidade = 3.0f;
    [SerializeField] private float limiteVelocidadeQueda = 15.0f;


    //Variaveis de uso interno
    private CharacterController controller;
    private Vector3 movementDirection;
    private Boolean isJumping;
    private int tempoPulando;    

    //Direcoes de movimento
    private Vector3 forward;
    private Vector3 right;
    private Vector3 left;
    private Vector3 back;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent <CharacterController> ();

        movementDirection = new Vector3 (transform.forward.x, transform.forward.y, transform.forward.z);

        forward = new Vector3 (transform.forward.x, transform.forward.y, transform.forward.z);
        right = new Vector3 (transform.right.x, transform.right.y, transform.right.z);
        left = new Vector3 (-transform.right.x, -transform.right.y, -transform.right.z);
        back = new Vector3 (-transform.forward.x, -transform.forward.y, -transform.forward.z);

        tempoPulando = 1;
    }

    private void decideDirecaoMovimento () {
        float vertical = Input.GetAxis ("Vertical");
        float horizontal = Input.GetAxis ("Horizontal");
        Vector3 desiredMovement = new Vector3 (horizontal, 0.0f, vertical);

        float distanciaFrente = Vector3.Distance (desiredMovement, forward);
        float distanciaDireita = Vector3.Distance (desiredMovement, right);
        float distanciaEsquerda = Vector3.Distance (desiredMovement, left);
        float distanciaTras = Vector3.Distance (desiredMovement, back);

        float distanciaMinima = Math.Min(Math.Min(Math.Min(distanciaFrente, distanciaDireita), distanciaEsquerda), distanciaTras);

        if (distanciaMinima == distanciaTras) {
            this.movementDirection = this.back;
        } else if (distanciaMinima == distanciaDireita) {
            this.movementDirection = this.right;
        } else if (distanciaMinima == distanciaEsquerda) {
            this.movementDirection = this.left;
        } else {
            this.movementDirection = this.forward;
        }
    }

    private bool houveMovimento () {
        if (!controller.isGrounded) {
            return false;
        }

        float vertical = Input.GetAxis ("Vertical");
        float horizontal = Input.GetAxis ("Horizontal");

        if (vertical != 0 || horizontal != 0) {
            return true;
        }
        else {
            return false;
        }
    }

    private void verificaPulo () {
        if (controller.isGrounded && Input.GetButtonUp("Jump")) {
            isJumping =true;
        } else if (transform.position.y >= this.alturaDoPulo) {
            isJumping = false;
        }

        if (!controller.isGrounded) {
            tempoPulando += 1;
        } else {
            tempoPulando = 1;
        }
    }

    private void pula () {
        Vector3 movimentoPulo = new Vector3 (0.0f, this.velocidadeDePulo * Time.deltaTime, 0.0f);

        controller.Move (movimentoPulo);
    }

    private void caiComAGravidade () {
        float velocidadeDeQueda = gravidade * tempoPulando;
        if (velocidadeDeQueda > this.limiteVelocidadeQueda) {
            velocidadeDeQueda = limiteVelocidadeQueda;
        }


        Vector3 movimentoQueda = new Vector3 (0.0f, -velocidadeDeQueda * Time.deltaTime, 0.0f);

        controller.Move (movimentoQueda);
    }

    // Update is called once per frame
    void Update()
    {
        caiComAGravidade ();

        if (houveMovimento ()) {
            decideDirecaoMovimento ();
        }

        verificaPulo ();

        if (isJumping) {
            pula ();
        }

        controller.Move (this.movementDirection * this.speed * Time.deltaTime);
    }
}
