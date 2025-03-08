using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisioni : MonoBehaviour
{
    public float speed = 10f;
    private Vector3 direction;
    void OnEnable()
    {
        direction = Vector3.forward;
    }
    void Update()
    {
        MoveBall();
    }
    void OnCollisionEnter(Collision collision)
    {
        Vector3 normal = collision.contacts[0].normal;

        direction = Vector3.Reflect(direction, normal).normalized;
    }
    void MoveBall(){
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
