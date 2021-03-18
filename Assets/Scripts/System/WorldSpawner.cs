using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSpawner : MonoBehaviour
{
    [SerializeField] GameObject _platform;
    [SerializeField] GameObject _wallStone;
    [SerializeField] private Transform _player;
    [SerializeField] private float _heightSpawn;

    private float _nextSpawnPlatformLevel;
    private float _lastSpawnPlatformLevel;
    private float _spawnPlatformFrequency;

    private float _nextSpawnWallStoneLevel;
    private float _lastSpawnWallStoneLevel;
    private float _spawnWallStoneFrequency;

    private void Start()
    {
        _spawnPlatformFrequency = 5f;
        _lastSpawnPlatformLevel = _heightSpawn;

        _spawnWallStoneFrequency = 2f;
        _lastSpawnWallStoneLevel = _heightSpawn;
    }

    private void Update()
    {
        CreatePlatform();
        CreateWallStones(-10.5f, 10.5f);        
    }

    private void CreatePlatform()
    {        
        _nextSpawnPlatformLevel = _player.position.y + _heightSpawn;
        Vector3 createAddress = new Vector3(Random.Range(-6.5f,6.5f),_nextSpawnPlatformLevel,0);

        if (_nextSpawnPlatformLevel >= _lastSpawnPlatformLevel + _spawnPlatformFrequency)
        {            
            Instantiate(_platform, createAddress, Quaternion.identity);
            _lastSpawnPlatformLevel = _nextSpawnPlatformLevel;
        }
    }

    private void CreateWallStones(float leftStonePositionX, float rightStonePositionX)
    {
        _nextSpawnWallStoneLevel = _player.position.y + _heightSpawn;
        Vector3 createAddressLeftStone = new Vector3(leftStonePositionX, _nextSpawnWallStoneLevel, 0);
        Vector3 createAddressRightStone = new Vector3(rightStonePositionX, _nextSpawnWallStoneLevel, 0);

        if (_nextSpawnWallStoneLevel >= _lastSpawnWallStoneLevel + _spawnWallStoneFrequency)
        {
            CreateStone(createAddressLeftStone);
            CreateStone(createAddressRightStone);
            _lastSpawnWallStoneLevel = _nextSpawnWallStoneLevel;
        }
    }

    private void CreateStone(Vector3 createAddress)
    {
        Instantiate(_wallStone, createAddress, Quaternion.AngleAxis(Random.Range(0f, 360f), new Vector3(0, 1, 0)));
    }
}
