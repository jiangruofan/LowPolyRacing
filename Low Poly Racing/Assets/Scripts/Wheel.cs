using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    public bool steer;
    public bool invertsteer;
    public bool power;

    public float steerangle { get; set; }
    public float torque { get; set; }

    private WheelCollider wheelcollider;
    private Transform wheeltransform;
    void Start()
    {
        wheelcollider = GetComponentInChildren<WheelCollider>();
        wheeltransform = GetComponentInChildren<MeshRenderer>().GetComponent<Transform>();
        
    }

    void Update()
    {
        wheelcollider.GetWorldPose(out Vector3 pos, out Quaternion rot);
        wheeltransform.position = pos;
        wheeltransform.rotation = rot;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (steer)
        {
            wheelcollider.steerAngle = steerangle * (invertsteer ? -1 : 1);
        }
        if (power)
        {
            wheelcollider.motorTorque = torque;
        }
    }
}
