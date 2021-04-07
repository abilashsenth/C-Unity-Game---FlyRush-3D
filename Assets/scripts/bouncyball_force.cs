using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bouncyball_force : MonoBehaviour
{

    Rigidbody rb;
    public float thrust = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.forward * thrust);
    }
}
