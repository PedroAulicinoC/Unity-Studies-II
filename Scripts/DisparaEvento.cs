using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DisparaEvento : MonoBehaviour
{
    public static Action<int> quandoAndar;
    public Animator anim;
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Run"))
        {
            DispararEvento();
        }
    }

    void DispararEvento()
    {
        quandoAndar?.Invoke(1);
    }
}
