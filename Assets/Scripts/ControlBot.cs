using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBot : MonoBehaviour
{
    public Transform jugador;
    public float velocidad = 2.0f;
    public float distanciaAtaque = 1.0f;
    public float rangoDeteccion = 5.0f;
    private bool persiguiendo = false;

    private void Update()
    {
        float distanciaAlJugador = Vector3.Distance(transform.position, jugador.position);

        if (distanciaAlJugador <= rangoDeteccion)
        {

            Vector3 direccion = jugador.position - transform.position;
            direccion.Normalize();

            transform.forward = direccion;

            transform.position += transform.forward * velocidad * Time.deltaTime;

            if (distanciaAlJugador < distanciaAtaque)
            {
                Debug.Log("Enemigo ha alcanzado al jugador");
            }
            persiguiendo = true;
        }
        else
        {
            persiguiendo = false;
        }
    }
}
