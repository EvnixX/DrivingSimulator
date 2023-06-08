using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrullaje : MonoBehaviour
{
    public float patrolVelocity;
    public float objectiveChange = 0.1f;

    public Transform[] puntosPatrulla;
    public Semaforo semaforo;

    private int puntoActual = 0;
    private bool enPatrullaje = true;
    private bool esperando = false;

    private void Update()
    {
        if (semaforo.rojo)
        {
            if (enPatrullaje && !esperando)
            {
                MoverAlPuntoSiguiente();
            }
            else if (!enPatrullaje && !esperando)
            {
                // Peatón ha completado su trayecto, espera antes de cruzar nuevamente
                esperando = true;
                StartCoroutine(EsperarAntesDeCruzar());
            }
        }
        else if (semaforo.verde)
        {
            enPatrullaje = true;
            esperando = false;
        }
    }

    private void MoverAlPuntoSiguiente()
    {
        Vector3 distancia = puntosPatrulla[puntoActual].position - transform.position;

        if (distancia.magnitude < objectiveChange)
        {
            puntoActual = ObtenerSiguienteObjetivo();
        }

        Vector3 velocidadVector = distancia.normalized;
        transform.position += velocidadVector * patrolVelocity * Time.deltaTime;
    }

    private int ObtenerSiguienteObjetivo()
    {
        puntoActual++;

        if (puntoActual >= puntosPatrulla.Length)
        {
            puntoActual = 0;
            enPatrullaje = false; // Peatón ha completado su trayecto
        }

        return puntoActual;
    }

    private IEnumerator EsperarAntesDeCruzar()
    {
        // Esperar un tiempo antes de poder cruzar nuevamente
        yield return new WaitForSeconds(5f); // Cambia el tiempo de espera según tus necesidades

        enPatrullaje = true;
        esperando = false;
    }
}