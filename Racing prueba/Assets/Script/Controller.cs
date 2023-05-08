using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public WheelCollider Rueda1;
    public WheelCollider Rueda2;
    public int Velocity = 150;

    private void Start()
    {
        
    }

    private void Update()
    {
        Rueda1.motorTorque = Velocity * Input.GetAxis("Vertical");
        Rueda2.motorTorque = Velocity * Input.GetAxis("Vertical");
    }

}
