using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoRelativo : MonoBehaviour
{
    Transform tr;
    Rigidbody rb;
    [SerializeField] Transform trCamera;
    [SerializeField] SO_ConfigRaposa config;
    Vector2 inputMovimento;
    Vector3 direcaoAtual;
    Vector3 velAtual;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        tr = transform;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        LeInput();
        DefineDirecao();
        AtualizarAnimacao();
    }

    void LeInput()
    {
        inputMovimento.x = Input.GetAxis("Horizontal");
        inputMovimento.y = Input.GetAxis("Vertical");
    }

    void DefineDirecao()
    {
        if(inputMovimento.magnitude > 0.1f)
        {
            direcaoAtual = trCamera.forward * inputMovimento.y;
            direcaoAtual += trCamera.right * inputMovimento.x;
            direcaoAtual.Normalize();
        }
        
        direcaoAtual = Vector3.ProjectOnPlane(direcaoAtual, Vector3.up);
        tr.forward = Vector3.Slerp
            (Vector3.ProjectOnPlane(tr.forward, Vector3.up),
            direcaoAtual,
            Time.deltaTime * config.velRotacao);
    }

    void AtualizarAnimacao()
    {
        anim.SetFloat("Input", inputMovimento.magnitude);
        anim.SetFloat("Velocidade", rb.velocity.magnitude);
    }

    private void FixedUpdate()
    {
        AplicaMovimento();
    }

    void AplicaMovimento()
    {
        velAtual = direcaoAtual * config.velMovimento * inputMovimento.magnitude;
        velAtual.y = rb.velocity.y;
        rb.velocity = velAtual;
    }
}
