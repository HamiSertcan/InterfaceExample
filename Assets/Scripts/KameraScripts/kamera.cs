using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamera: MonoBehaviour
{
    float cam_rot;
    //public float speedH = 2.0f;
    public float cam_rot_speed = 2.0f;
    public float min_rot,max_rot;

    //private float yaw = 0.0f;
    private float pitch = 0.0f;

    void Update()
    {
        //yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= cam_rot_speed * Input.GetAxis("Mouse Y");
        cam_rot = transform.localRotation.eulerAngles.x;

        // kamera rotasyonunu -10 derece ile 5 derece arasında değişebiliyor
        if (pitch >= min_rot && pitch <= max_rot)
        {
            transform.localEulerAngles = new Vector3(pitch, 0f, 0.0f);
        }
        if(pitch < min_rot)
        {
            transform.localEulerAngles = new Vector3(min_rot, 0f, 0.0f);
        }
        if (pitch > max_rot)
        {
            transform.localEulerAngles = new Vector3(max_rot, 0f, 0.0f);
        }

    }
}