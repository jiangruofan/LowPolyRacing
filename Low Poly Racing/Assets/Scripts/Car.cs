using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public Transform centerofmass;
    public float motortorque = 1500f;
    public float maxsteer = 20f;

    public float steer { get; set; }
    public float throttle { get; set; }

    private Rigidbody _rigidbody;
    private Wheel[] wheels;
    // Start is called before the first frame update
    void Start()
    {
        wheels = GetComponentsInChildren<Wheel>();
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.centerOfMass = centerofmass.localPosition;
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var wheel in wheels)
        {
            wheel.steerangle = steer * maxsteer;
            wheel.torque = throttle * motortorque;
        }
        
    }
}
