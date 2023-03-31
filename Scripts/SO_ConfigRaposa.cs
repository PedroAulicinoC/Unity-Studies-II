using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Config Raposa", menuName = "Raposa/Config")]
public class SO_ConfigRaposa : ScriptableObject
{
    public float velMovimento;
    public float velRotacao;

    private void OnValidate()
    {
        if (velMovimento < 0)
            velMovimento = 0;

        if (velRotacao < 0)
            velRotacao = 0;
    }
}
