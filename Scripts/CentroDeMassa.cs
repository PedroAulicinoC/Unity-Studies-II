using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentroDeMassa : MonoBehaviour
{
    Rigidbody rg;
    [SerializeField] Transform centroDeMassa;
    void Start()
    {
        rg = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rg.centerOfMass = centroDeMassa.localPosition;
        rg.WakeUp();
    }
}
