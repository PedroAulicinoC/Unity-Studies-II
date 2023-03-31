using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Contador : MonoBehaviour
{
    [SerializeField] int contador = 0;
    public Text contadorUI;

    private void OnEnable()
    {
        DisparaEvento.quandoAndar += AtualizarContador;
    }

    private void OnDisable()
    {
        DisparaEvento.quandoAndar -= AtualizarContador;
    }

    void AtualizarContador(int num)
    {
        contador += num;
        contadorUI.text = contador.ToString();
    }
}
