using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public float velocityAct;
    public int velocityMax = 2000;

    private void Start()
    {
        
    }

    private void Update()
    {
        velocityAct = (2 * Mathf.PI * Rueda1.radius) * Rueda1.rpm * 60 / 600;
        Llantas1.localEulerAngles = new Vector3(0, Rueda3.steerAngle, 0);
        Llantas2.localEulerAngles = new Vector3(0, Rueda4.steerAngle, 0);
    }

    private void FixedUpdate()
    {
        if(velocityAct < velocityMax)
        {
            Rueda1.motorTorque = Velocity * Input.GetAxis("Vertical");
            Rueda2.motorTorque = Velocity * Input.GetAxis("Vertical");
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
        }
        else
        {
            Rueda1.brakeTorque = 0;
            Rueda2.brakeTorque = 0;
        }
    }
}
