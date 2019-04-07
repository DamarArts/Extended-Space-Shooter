using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private Rigidbody bolt;
    public float speed;

    void Start()
    {
        bolt = GetComponent<Rigidbody>();

        bolt.velocity = transform.forward * speed;
    }
}
