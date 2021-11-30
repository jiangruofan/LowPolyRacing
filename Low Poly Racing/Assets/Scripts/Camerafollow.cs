using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public Vector3 eulerrotation;
    public float damper;
    // Start is called before the first frame update
    void Start()
    {
        transform.eulerAngles = eulerrotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        transform.position = Vector3.Lerp(transform.position, target.position + offset, damper * Time.deltaTime);
    }
}
