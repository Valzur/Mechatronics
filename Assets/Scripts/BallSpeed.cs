using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpeed : MonoBehaviour
{
    [SerializeField] Rigidbody rigidbody;
    void Update() 
    {
        print("Ball speed: " + rigidbody.velocity.magnitude);
    }

}
