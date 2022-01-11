using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltrasonicSensor : Device
{
    [SerializeField] float sensorMaxDistance;

    void OnDrawGizmos() 
    {
        if(Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, sensorMaxDistance))
        {
            Gizmos.DrawLine(transform.position, hitInfo.point);
        }
        else
        {
            Gizmos.DrawLine(transform.position, (transform.position + transform.forward * sensorMaxDistance));
        }
    }

    protected override void SampledUpdate()
    {
        if(Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, sensorMaxDistance))
        {
            _dataStream = hitInfo.distance;
        }
        else
        {
            _dataStream = Mathf.Infinity;
        }
        //print("Ultrasonic Reading: " + _dataStream);
    }
}
