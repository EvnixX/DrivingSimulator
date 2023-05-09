using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Camera_Auto : MonoBehaviour
{
    public Transform PlayerTransform;
    private Vector3 _cameraOffset;
    [Range(0, 1)]  
    public float smoothFactor;

    [Range(0, 1)]
    public float lerpVlue;
    public float Sensibilidad;

    public bool LoockPlayer;

    private void Start()
    {
        _cameraOffset = transform.localPosition - PlayerTransform.position;
    }

     void LateUpdate()
    {
        Vector3 newpos = PlayerTransform.position + _cameraOffset;
        transform.position = Vector3.Lerp(transform.position, PlayerTransform.position + _cameraOffset, lerpVlue);
        _cameraOffset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * Sensibilidad, Vector3.up) * _cameraOffset;
        transform.position = Vector3.Slerp(transform.position,newpos, smoothFactor);

        if(LoockPlayer)
        {
            transform.LookAt(PlayerTransform);
        }
    }
}
