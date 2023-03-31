using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    [SerializeField] Animator anim;
    Rigidbody rb;
    Transform tr;
    float inputVertical;
    float velocidade;
    [SerializeField] float velMovimento = 4;
    void Start()
    {
        tr = transform;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        LerInput();
        AtualizarAnim();
    }

    private void FixedUpdate()
    {
        AplicaMovimento();
    }

    void AplicaMovimento()
    {
        rb.velocity = tr.forward * velocidade * velMovimento;
    }

    void AtualizarAnim()
    {
        anim.SetFloat("Input", inputVertical);
        anim.SetFloat("Velocidade", velocidade);
    }

    void LerInput()
    {
        velocidade = Input.GetAxis("Vertical");
        inputVertical = Mathf.Abs(velocidade);
    }
}
