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
            eventsCanvas.imgGeneral.SetActive(true);
            eventsCanvas.advObj.SetActive(true);
            eventsCanvas.Pausegame();
            eventsCanvas.dialogosAdvertencias = 1;
        }

        if (this.gameObject.tag == "Final")
        {
            eventsCanvas.imgGeneral.SetActive(true);
            eventsCanvas.advObj.SetActive(true);
            eventsCanvas.Creditos();
            eventsCanvas.dialogosAdvertencias = 2;
        }
        if (this.gameObject.tag == "Tutorial")
        {
            eventsCanvas.imgGeneral.SetActive(true);
            eventsCanvas.advObj.SetActive(true);
            eventsCanvas.Pausegame();
            eventsCanvas.dialogosAdvertencias = 3;
        }

    }
    
}
