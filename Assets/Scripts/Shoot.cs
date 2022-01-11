using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] Rigidbody ballPrefab;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float Voltage;
    [SerializeField] Motor[] motors;
    #region Testing
    [SerializeField] bool shoot;

    void OnValidate()
    {
        if(shoot)
        {
            shoot = false;
            Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);
        }
    }
    #endregion

    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Space))
            Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);

        foreach (var motor in motors)
        {
            motor.ConnectMotor().DigitalWrite(0f);
            motor.DigitalWrite(Voltage);
        }
    }
}
