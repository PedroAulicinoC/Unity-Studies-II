using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovimentoNavMesh : MonoBehaviour
{
    NavMeshAgent agente;
    [SerializeField] Transform alvo;
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        agente.SetDestination(alvo.position);
    }
}
