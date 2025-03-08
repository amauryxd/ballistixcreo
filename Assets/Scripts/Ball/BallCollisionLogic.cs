using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisionLogic : MonoBehaviour
{
    Rigidbody rb;
    public Vector3 velocity;
    public float ballSpeed;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.AddForce(-transform.forward * ballSpeed, ForceMode.VelocityChange);
    }

    void Update()
    {
        velocity = rb.velocity;
    }

    void OnCollisionEnter(Collision collision)
    {
        float speed = velocity.magnitude;
        Vector3 direction = Vector3.Reflect(velocity.normalized, collision.contacts[0].normal);
        rb.velocity = direction * speed;
    }

}
