using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggers : MonoBehaviour
{
    public GameObject canva;
    public GameObject trigger;
    public float timer;

    private void Start()
    {
        canva.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canva.SetActive(true);
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                Destroy(trigger);
                canva.SetActive(false);
            }

        }
    }
}
