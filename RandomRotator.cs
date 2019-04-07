using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    public float tumble;
    private Rigidbody astroid;

    private void Start()
    {
        astroid = GetComponent<Rigidbody>();

        astroid.angularVelocity = Random.insideUnitSphere * tumble;
    }
}
