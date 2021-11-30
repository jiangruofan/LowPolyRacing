using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum ControlType { HumanInput, AI}
    public ControlType controltype = ControlType.HumanInput;

    public float BestLapTime { get; private set; } = Mathf.Infinity;

    public float LastLaptime { get; private set; } = 0;
    public float CurrentLapTime { get; private set; } = 0;
    public int CurrentLap { get; private set; } = 0;

    private float lapTimer;
    private int lastCheckpointPassed = 0;

    private Transform checkpointsParent;
    private int checkpointCount;
    private int checkpointLayer;
    private Car car;
    
    // Start is called before the first frame update
    void Awake()
    {
        checkpointsParent = GameObject.Find("Checkpoints").transform;
        checkpointCount = checkpointsParent.childCount;
        checkpointLayer = LayerMask.NameToLayer("Checkpoint");
        car = GetComponent<Car>();
        
    }

    void StartLap()
    {
        Debug.Log("StartLap!");
        CurrentLap++;
        lastCheckpointPassed = 1;
        lapTimer = Time.time;
    }

    void EndLap()
    {
        LastLaptime = Time.time - lapTimer;
        BestLapTime = Mathf.Min(LastLaptime, BestLapTime);
        Debug.Log("EndLap - LapTime was" + LastLaptime + " seconds");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != checkpointLayer)
        {
            return;
        }

        if(other.gameObject.name == "1")
        {
            if (lastCheckpointPassed == checkpointCount)
            {
                EndLap();
            }
            if (CurrentLap == 0 || lastCheckpointPassed == checkpointCount)
            {
                StartLap();
            }
        }

        if(other.gameObject.name == (lastCheckpointPassed + 1).ToString())
        {
            lastCheckpointPassed++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        CurrentLapTime = lapTimer > 0 ? Time.time - lapTimer : 0;

        if (controltype == ControlType.HumanInput)
        {
            car.steer = GameManager.Instance.InputController.SteerInput;
            car.throttle = GameManager.Instance.InputController.ThrottleInput;
        }
        
    }
}
