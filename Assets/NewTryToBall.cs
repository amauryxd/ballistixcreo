using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTryToBall : MonoBehaviour
{
    public float speed = 10f;
    private Vector3 direction;

    void Start()
    {
        // Inicializa la dirección del objeto
        direction = Vector3.forward.normalized; // Movimiento diagonal como ejemplo
    }

    void Update()
    {
        // Mueve el objeto en la dirección actual
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Obtiene la normal de la superficie con la que ha colisionado
        Vector3 normal = collision.contacts[0].normal;

        // Calcula la dirección de reflexión
        Vector3 newDirection = Vector3.Reflect(direction, normal);

        // Calcula los ángulos de incidencia y reflexión
        float angleOfIncidence = Vector3.Angle(-direction, normal);
        float angleOfReflection = Vector3.Angle(newDirection, normal);

        // Imprime los ángulos en la consola
        Debug.Log("Ángulo de Incidencia: " + angleOfIncidence);
        Debug.Log("Ángulo de Reflexión: " + angleOfReflection);

        // Actualiza la dirección del objeto
        direction = -newDirection;
    }
}
