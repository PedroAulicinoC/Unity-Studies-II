using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingObjeto : MonoBehaviour
{
    [SerializeField] float tempoDesativar = 2f;
    void OnEnable()
    {
        Invoke("Desativa", tempoDesativar);
    }

    void Desativa()
    {
        Pooling.objetoDesativou?.Invoke(gameObject);
    }
}
