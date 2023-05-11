using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Semaforo : MonoBehaviour
{
    public GameObject luz, trigger;
    public Animator caminaJ, camina—, caminaV;
    public Transform posVer, posRoj, posAma;
    public bool rojo, verde, amarilloRoja,amarilloVerda;
    public float numVerde,numRojo,numAmarillo;

    // Start is called before the first frame update
    void Start()
    {
        trigger.SetActive(false);
        caminaJ = GetComponent<Animator>();
        caminaV = GetComponent<Animator>();
        camina— = GetComponent<Animator>();
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
            caminaJ.SetBool("Camina1", true);
            caminaV.SetBool("Camina2", true);
            camina—.SetBool("Camina3", true);
            trigger.SetActive(true);
            
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
            trigger.SetActive(false);
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
