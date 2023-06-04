using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float fuerzaMotor = 1000f;        
    public float fuerzaFreno = 2000f;        
    public float anguloMaxLlantas = 30f;    

    //aqui van los wheelcolliders
    public WheelCollider[] llantasdelanteras;     
    public WheelCollider[] llantasTraseras;
    
    public Transform terceraPersonaCam;         
    public Transform primeraPersonaCam;     

    private Rigidbody rb;
    private float horizontalInput;          
    private float verticalInput;            
    private bool frenando;                 
    private bool primeraPersona;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        frenando = Input.GetKey(KeyCode.Space);

        //cambia de primera a tercera persona la cam
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            primeraPersona = !primeraPersona;
            primeraPersonaCam.gameObject.SetActive(primeraPersona);
            terceraPersonaCam.gameObject.SetActive(!primeraPersona);
        }
    }

    private void FixedUpdate()
    {
        Motor();
        RotacionLlantas();
    }

    private void Motor()
    {
        // Aqui le damos fuerza a las llantas pa que giren
        float force = verticalInput * fuerzaMotor;
        for (int i = 0; i < llantasTraseras.Length; i++)
        {
            llantasTraseras[i].motorTorque = force;
        }

        // aqui pa frenar
        if (frenando)
        {
            for (int i = 0; i < llantasdelanteras.Length; i++)
            {
                llantasdelanteras[i].brakeTorque = fuerzaFreno;
            }
            for (int i = 0; i < llantasTraseras.Length; i++)
            {
                llantasTraseras[i].brakeTorque = fuerzaFreno;
            }
        }
        else
        {
            for (int i = 0; i < llantasdelanteras.Length; i++)
            {
                llantasdelanteras[i].brakeTorque = 0f;
            }
            for (int i = 0; i < llantasTraseras.Length; i++)
            {
                llantasTraseras[i].brakeTorque = 0f;
            }
        }
    }

    private void RotacionLlantas()
    {
        // se calcula cuanto gira la llanta
        float steeringAngle = anguloMaxLlantas * horizontalInput;

        // y aqui giran las llantas de alante
        for (int i = 0; i < llantasdelanteras.Length; i++)
        {
            llantasdelanteras[i].steerAngle = steeringAngle;
        }
    }
}