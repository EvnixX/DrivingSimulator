using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class informativeSignals : MonoBehaviour
{
    EventsCanvas eventsCanvas;

    private void Start()
    {
        eventsCanvas = FindObjectOfType<EventsCanvas>();
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (this.gameObject.tag == "SAmarilla")
        {
            eventsCanvas.imgAmarilla.SetActive(true);
            eventsCanvas.infoObj.SetActive(true);
            eventsCanvas.Pausegame();
            eventsCanvas.dialogosInformativos = 1;
            Destroy(this.gameObject);
        }
        if (this.gameObject.tag == "SAzul")
        {
            eventsCanvas.imgAzul.SetActive(true);
            eventsCanvas.infoObj.SetActive(true);
            eventsCanvas.Pausegame();
            eventsCanvas.dialogosInformativos = 2;
            Destroy(this.gameObject);
        }
        if (this.gameObject.tag == "SRoja")
        {
            eventsCanvas.imgRoja.SetActive(true);
            eventsCanvas.infoObj.SetActive(true);
            eventsCanvas.Pausegame();
            eventsCanvas.dialogosInformativos = 3;
            Destroy(this.gameObject);
        }


    }
}
