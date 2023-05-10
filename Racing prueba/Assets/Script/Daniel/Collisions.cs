using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    EventsCanvas eventsCanvas;

    private void Start()
    {
        eventsCanvas = FindObjectOfType<EventsCanvas>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Autos")
        {
            eventsCanvas.Pausegame();
            eventsCanvas.estadodialogos++;
        }

        if (other.gameObject.tag == "llanta1" + "llanta2")
        {

        }
    }
}
