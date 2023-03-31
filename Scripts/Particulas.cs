using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particulas : MonoBehaviour
{
    [SerializeField] ParticleSystem particula;

    private void OnEnable()
    {
        DisparaEvento.quandoAndar += EfeitoAndar;
    }

    private void OnDisable()
    {
        DisparaEvento.quandoAndar -= EfeitoAndar;
    }

    private void EfeitoAndar(int num)
    {
        particula.Emit(num);
    }
}
