using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbital : MonoBehaviour
{
    Transform tr;
    [SerializeField] Transform trAlvo;
    [SerializeField] Vector3 distancia = new Vector3(0, 2, -5);
    [SerializeField] float altura;
    [SerializeField] float alturaMin = 0.15f;
    [SerializeField] float alturaMax = 8;
    [SerializeField] AnimationCurve progressaoDaDistancia;
    [SerializeField] Vector3 enquadramento;
    [SerializeField] Vector3 sensibilidadeInput = new Vector3(1, 1, 1);
    Vector3 posAtual;
    Vector3 posAlvoAtual;
    Vector2 inputMouse;
    float inputScroll;
    float rotacaoAtual;
    void Start()
    {
        tr = transform;
    }

    
    void LateUpdate()
    {
        LeInput();
        AplicaInput();

        Posiciona();
        Rotaciona();
        Direciona();
    }

    void LeInput()
    {
        inputMouse.x = Input.GetAxis("Camera X");
        inputMouse.y = Input.GetAxis("Camera Y");
        inputScroll = Input.GetAxis("Mouse ScrollWheel");
    }

    void AplicaInput()
    {
        rotacaoAtual += inputMouse.x * sensibilidadeInput.x;
        altura += inputMouse.y * sensibilidadeInput.y;
        altura = Mathf.Clamp(altura, alturaMin, alturaMax);
    }

    void Posiciona()
    {
        posAtual = trAlvo.position;
        posAtual -= Vector3.forward * distancia.z * 
            progressaoDaDistancia.Evaluate((altura-alturaMin)/alturaMax);
        posAtual += Vector3.right * distancia.x;
        posAtual += Vector3.up * distancia.y * altura;

        tr.position = posAtual;
    }

    void Rotaciona()
    {
        tr.RotateAround(trAlvo.position, Vector3.up, rotacaoAtual);
    }

    void Direciona()
    {
        posAlvoAtual = trAlvo.position;
        posAlvoAtual += tr.forward * enquadramento.z;
        posAlvoAtual += tr.right * enquadramento.x;
        posAlvoAtual += Vector3.up * enquadramento.y;

        tr.LookAt(posAlvoAtual, Vector3.up);
    }
}
