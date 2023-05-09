using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pratullaje : MonoBehaviour
{
    public float patrolVelocity;
    public float objetiveChange = 0.1f;

    public Transform[] PuntosPatrullla;

    int puntoActual = 0;

    private void Update()
    {
        if (MoviendoAlTarget())
        {
            puntoActual = ObtenerSiguienteObjetivo();
        }
    }

    public bool MoviendoAlTarget() 
    {
        Vector3 distancia = PuntosPatrullla[puntoActual].position - transform.position;

        if (distancia.magnitude < objetiveChange)
        {
            return true;
        }

        Vector3 velocidadVector = distancia.normalized;
        transform.position += velocidadVector * patrolVelocity * Time.deltaTime;

        return false;
    }

    public int ObtenerSiguienteObjetivo()
    {
        puntoActual++;

        if (puntoActual >= PuntosPatrullla.Length)
        {
            puntoActual = 0;
        }

        return puntoActual;
    }
}
