using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pratullaje : MonoBehaviour
{
    public float patrolVelocity;
    public float objetiveChange = 0.1f;

    public Transform[] PuntosPatrullla;
    public Semaforo semaforo;

    int puntoActual = 0;

    public bool entroZona = false;

    private void Start()
    {
        entroZona = false;
    }

    private void Update()
    {
        
            if (semaforo.rojo == true)
            {
                if (MoviendoAlTarget())
                {
                    puntoActual = ObtenerSiguienteObjetivo();
                }
            }
        if (entroZona == true && !semaforo.rojo)
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("peaton"))
        {
           entroZona = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("peaton"))
        {
            entroZona = false;
            Debug.Log("asfaf");
        }
    }
}
