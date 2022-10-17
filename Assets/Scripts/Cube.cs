using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private Rigidbody _rigidbody;

    public float _distance;
    public float _speed;
    public bool _randndomiseDirection;

    private Vector3 targetPoint;
    private Quaternion rotationZ;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

        //Adjusting final destination
        targetPoint = transform.position;

        if (_randndomiseDirection)
        {
            //Randomizing Z Axis
            if (Random.value < 0.25f)
            {
                targetPoint.z += _distance;
                targetPoint.x += Random.Range(-_distance, _distance);
            } else if (Random.value < 0.5f)
            {
                targetPoint.z -= _distance;
                targetPoint.x += Random.Range(-_distance, _distance);
            } else if (Random.value < 0.75f)
            {
                targetPoint.x -= _distance;
                targetPoint.z += Random.Range(-_distance, _distance);
            } else
            {
                targetPoint.x -= _distance;
                targetPoint.z += Random.Range(-_distance, _distance);
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
