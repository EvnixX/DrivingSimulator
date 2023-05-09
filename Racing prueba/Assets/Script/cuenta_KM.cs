using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cuenta_KM : MonoBehaviour
{
    public Rigidbody rigid;
    public Image imagen;

    private void Update()
    {
        float speed = rigid.velocity.magnitude;
        imagen.transform.eulerAngles = new Vector3(0,0,speed * -6 + 150);
    }
}
