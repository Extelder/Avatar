using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPlaces;
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private Transform _player;
    [SerializeField] private GameObject _timeAddBonusPrefab;

    public int SpawnedCoins { get; private set; }

    private void Start()
    {
        _player.position = _spawnPlaces[Random.Range(0, _spawnPlaces.Length)].position;
        for (int i = 0; i < _spawnPlaces.Length; i++)
        {
            int rand = Random.Range(0, 4);

            if (rand <= 1)
            {
                Instantiate(_timeAddBonusPrefab, _spawnPlaces[i].position, Quaternion.identity);
                continue;
            }
            Instantiate(_coinPrefab, _spawnPlaces[i].position, Quaternion.identity);
            SpawnedCoins++;
        }
    }
}