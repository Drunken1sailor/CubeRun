using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
   
    void FixedUpdate()
    {
        Quaternion _rotationY = Quaternion.AngleAxis(_speed, Vector3.up);
        transform.rotation *= _rotationY;
    }
}
