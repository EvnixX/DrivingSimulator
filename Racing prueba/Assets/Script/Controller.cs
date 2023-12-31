using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class Controller : MonoBehaviour
{
    public int Frenar = 500;
    public WheelCollider Rueda1;
    public WheelCollider Rueda2;
    public WheelCollider Rueda3;
    public WheelCollider Rueda4;
    public Transform Llantas1;
    public Transform Llantas2;
    public int Velocity = 150;

    public Animator animator_llanta1;
    public Animator animator_llanta2;
    public Animator animator_llanta3;
    public Animator animator_llanta4;
    public float velocityAct;
    public int velocityMax = 2000;


    public AudioSource audioSource;



    public Camera tercera_Persona;
    public Camera Primera_Persona;








    private void Start()
    {
        
    }

    private void Update()
    {
        velocityAct = (2 * Mathf.PI * Rueda1.radius) * Rueda1.rpm * 60 / 600;
        Llantas1.localEulerAngles = new Vector3(0, Rueda3.steerAngle, 0);
        Llantas2.localEulerAngles = new Vector3(0, Rueda4.steerAngle, 0);

        
        if (Input.GetButtonDown("Fire1"))
        {
            if (Primera_Persona.enabled)
            {
                Primera_Persona.enabled = false;
                tercera_Persona.enabled = true;
            }
            
            else if (tercera_Persona.enabled)
            {
                Primera_Persona.enabled = true;
                tercera_Persona.enabled = false;
            }

        }

    }

    [Obsolete]
    private void FixedUpdate()
    {

      
        if(velocityAct < velocityMax)
        {
            Rueda1.motorTorque = Velocity * Input.GetAxis("Vertical");
            Rueda2.motorTorque = Velocity * Input.GetAxis("Vertical");

            animator_llanta1.SetBool("Run", true);
            animator_llanta2.SetBool("Run", true);
            animator_llanta3.SetBool("Run", true);
            animator_llanta4.SetBool("Run", true);
        }

        else
        {
            Rueda1.motorTorque = 0;
            Rueda2.motorTorque = 0;

        }

        Rueda3.steerAngle = -40 * Input.GetAxis("Horizontal");
        Rueda4.steerAngle = -40 * Input.GetAxis("Horizontal");

        if(Input.GetAxis("Vertical") == 0)
        {
            Rueda1.brakeTorque = Frenar;
            Rueda2.brakeTorque = Frenar;
            audioSource.volume -= 0.0090f;
            animator_llanta1.SetBool("Run", false);
            animator_llanta2.SetBool("Run", false);
            animator_llanta3.SetBool("Run", false);
            animator_llanta4.SetBool("Run", false);
        }
        else
        {
            Rueda1.brakeTorque = 0;
            Rueda2.brakeTorque = 0;
        }

        if(velocityAct > 0)
        {
            audioSource.volume += 0.0010f;
        }


    }     
    
}
