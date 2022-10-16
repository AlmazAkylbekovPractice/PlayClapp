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

        LoadCubeProperties();

        StartCoroutine(SpawnCube());
    }

    private void LoadCubeProperties()
    {
        Cube._distance = _distance;
        Cube._speed = _speed;
        Cube._randndomiseDirection = _randndomiseDirection;
    }


    IEnumerator SpawnCube()
    {
        while (true)
        {
            Instantiate(_cubePrefab, _spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(_spawnTime);
        }
    }
}
