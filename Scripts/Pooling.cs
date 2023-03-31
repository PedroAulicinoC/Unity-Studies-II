using System;
using System.Collections.Generic;
using UnityEngine;

public class Pooling : MonoBehaviour
{
    public static Action<GameObject> objetoDesativou;

    [SerializeField] GameObject prefab;
    [SerializeField] Transform origem;
    //[SerializeField] int limitedeObjetos = 10;
    Stack<GameObject> pilhaobjetosDesativados = new Stack<GameObject>();
    GameObject objetoAtual;
    //ParticleSystem particula;

    private void OnEnable()
    {
        objetoDesativou += ObjetoFoiDesativado;
    }

    private void OnDisable()
    {
        objetoDesativou -= ObjetoFoiDesativado;
    }

    void Start()
    {
        //for (int i = 0; i < limitedeObjetos; i++)
        //{
            //objetoAtual = Instantiate(prefab, origem.position, origem.rotation);
            //pilhaobjetosDesativados.Push(objetoAtual);
            //objetoAtual.SetActive(false);
        //}
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            AtiraParticula();
        }
    }

    void AtiraParticula()
    {
        if (pilhaobjetosDesativados.Count > 0)
        {
            objetoAtual = pilhaobjetosDesativados.Pop();
            objetoAtual.transform.SetPositionAndRotation(origem.position, origem.rotation);
            objetoAtual.SetActive(true);
        }
        else
        {
            objetoAtual = Instantiate(prefab, origem.position, origem.rotation);
        }
        //particula.Emit(5);
    }

    void ObjetoFoiDesativado(GameObject objetoParaDesativar)
    {
        pilhaobjetosDesativados.Push(objetoParaDesativar);
        objetoParaDesativar.SetActive(false);
    }
}
