using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{

    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private Vector3 _spawnPosition;
    [SerializeField] private float _spawnTime;
    [SerializeField] private float _distance;
    [SerializeField] private float _speed;
    [SerializeField] private bool _randndomiseDirection;


    void Awake()
    {
        _spawnPosition = transform.position;
        StartCoroutine(SpawnCube());
    }

    IEnumerator SpawnCube()
    {
        while (true)
        {
            _cubePrefab.GetComponent<Cube>()._distance = _distance;
            _cubePrefab.GetComponent<Cube>()._speed = _speed;
            _cubePrefab.GetComponent<Cube>()._randndomiseDirection = _randndomiseDirection;

            Instantiate(_cubePrefab, _spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(_spawnTime);
        }
    }
}
