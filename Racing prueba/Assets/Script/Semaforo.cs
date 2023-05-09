using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Semaforo : MonoBehaviour
{
    public GameObject luz;

    public Transform posVer, posRoj, posAma;
    private bool rojo, verde, amarilloRoja,amarilloVerda;
    public float numVerde,numRojo,numAmarillo;

    // Start is called before the first frame update
    void Start()
    {
        verde = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (rojo ==true)
        {
            luz.transform.position = posRoj.position;
            luz.GetComponent<Light>().color = Color.red;
            StartCoroutine(LuzRojo());
            amarilloVerda = false;
        }

        if (verde == true)
        {
            luz.transform.position = posVer.position;
            luz.GetComponent<Light>().color = Color.green;
            StartCoroutine(LuzVerde());
            amarilloRoja = false;
        }

        if (amarilloRoja == true) 
        {
            luz.transform.position = posAma.position;
            luz.GetComponent<Light>().color = Color.yellow;
            StartCoroutine(LuzAmarilloRojo());
            rojo = false;
        }

        if (amarilloVerda == true)
        {
            luz.transform.position = posAma.position;
            luz.GetComponent<Light>().color = Color.yellow;
            StartCoroutine(LuzAmarrilloVerde());
            verde = false;
        }
    }

    IEnumerator LuzVerde()
    {
        yield return new WaitForSeconds(numVerde);
        amarilloVerda = true;
    }
    IEnumerator LuzAmarrilloVerde()
    {
        yield return new WaitForSeconds(numAmarillo);
        rojo = true;
    }
    IEnumerator LuzAmarilloRojo()
    {
        yield return new WaitForSeconds(numAmarillo);
        verde = true;
    }
    IEnumerator LuzRojo()
    {
        yield return new WaitForSeconds(numRojo);
        amarilloRoja = true;
    }
}
