using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento_BlendTree : MonoBehaviour
{
    [SerializeField] Animator anim;
    float inputHorizontal;
    float inputVertical;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        LerInput();
        AplicaAnim();
    }

    void LerInput()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
        inputVertical = Input.GetAxis("Vertical");
    }

    void AplicaAnim()
    {
        anim.SetFloat("InputX", inputHorizontal);
        anim.SetFloat("InputY", inputVertical);
    }
}
