using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class CubeSpawner : MonoBehaviour
{

    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private Vector3 _spawnPosition;
    [SerializeField] private float _spawnTime;
    [SerializeField] private float _distance;
    [SerializeField] private float _speed;
    [SerializeField] private bool _randndomiseDirection;

    [SerializeField] GameObject speedText;
    [SerializeField] GameObject distanceText;
    [SerializeField] GameObject spawnTimeText;
    [SerializeField] GameObject randomToggle;

    void Awake()
    {
        _spawnPosition = transform.position;

        speedText.GetComponent<TMP_InputField>().text = "2";
        distanceText.GetComponent<TMP_InputField>().text = "2";
        spawnTimeText.GetComponent<TMP_InputField>().text = "2";

        StartCoroutine(SpawnCube());
    }

    private void Update()
    {
        _speed = float.Parse(speedText.GetComponent<TMP_InputField>().text);
        _distance = float.Parse(distanceText.GetComponent<TMP_InputField>().text);
        _spawnTime = float.Parse(spawnTimeText.GetComponent<TMP_InputField>().text);
        _randndomiseDirection = randomToggle.GetComponent<Toggle>().isOn;
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
