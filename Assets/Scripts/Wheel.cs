using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Wheel : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float CurrentLoad
    {
        get{return _currentLoad;}
    }

    float _currentLoad;
}
