using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    EventsCanvas eventsCanvas;
    Semaforo semaforo;

    private void Start()
    {
        eventsCanvas = FindObjectOfType<EventsCanvas>();
        semaforo = FindObjectOfType<Semaforo>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Autos" && semaforo.rojo == true)
        {
            eventsCanvas.Pausegame();
            eventsCanvas.estadodialogos = 1;
        }

        if (this.gameObject.tag == "Final")
        {
            eventsCanvas.Pausegame();
            eventsCanvas.estadodialogos = 2;
        }
        
    }
}
