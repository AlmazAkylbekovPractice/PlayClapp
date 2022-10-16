using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private Rigidbody _rigidbody;

    public static float _distance;
    public static float _speed;
    public static bool _randndomiseDirection;

    private Vector3 targetPoint;
    private Quaternion rotationZ;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Debug.Log(_distance);
        //Adjusting final destination
        targetPoint = transform.position;

        if (_randndomiseDirection)
        {
            //Randomizing Z Axis
            if (Random.value < 0.5f)
            {
                targetPoint.z += _distance;
                targetPoint.x += Random.Range(-_distance, _distance);
            } else
            {
                targetPoint.z -= _distance;
                targetPoint.x += Random.Range(-_distance, _distance);
            }
        }
        else
        {
            targetPoint.z += _distance;
        }
    }

    private void Update()
    {
        var dir = (targetPoint - transform.position).normalized * _speed;
        _rigidbody.velocity = dir;

        if (transform.position.magnitude > _distance)
            Destroy(gameObject);
    }
}
