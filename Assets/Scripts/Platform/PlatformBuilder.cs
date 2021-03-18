using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBuilder : MonoBehaviour
{
    [SerializeField] private GameObject _stoneMesh;
    [SerializeField] private GameObject _basePlatform;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject _coin;
    [SerializeField] private GameObject _reorientedTrigger;

    private Transform _playerPosition;

    private void Start()
    {
        _playerPosition = GameObject.FindObjectOfType<Player>().transform;
        CreatePlatform();
    }

    private void CreatePlatform()
    {
        float stonePositionX = -2f;
        float stepOfCreationStone = 1.33f;
        int stonesCount = 4;
        float enemyPositionX = -2f;
        float coinPositionX = 0f;
        float leftReorientedTriggerPositionX = -3.3f;
        float RightReorientedTriggerPositionX = 3.3f;

        for (int i = 0; i < stonesCount; i++)
        {
            CreateStone(stonePositionX);
            stonePositionX += stepOfCreationStone;
        }

        CreateBasePlatform();               
        
        CreateEnemy(enemyPositionX);        
        
        CreateCoin(coinPositionX);
        
        CreateReorientedTridder(leftReorientedTriggerPositionX);
        CreateReorientedTridder(RightReorientedTriggerPositionX);
    }

    private void CreateStone(float positionX)
    {
        GameObject stone = Instantiate(_stoneMesh, gameObject.transform.position + new Vector3(positionX, -0.3f, 0), Quaternion.AngleAxis(Random.Range(0, 360), new Vector3(0, 1, 0)), gameObject.transform);
        stone.transform.localScale = new Vector3(Random.Range(75f, 85f), Random.Range(75f, 85f), Random.Range(75f, 85f));
    }

    private void CreateBasePlatform()
    {
        Instantiate(_basePlatform, gameObject.transform.position, Quaternion.identity, gameObject.transform);
    }

    private void CreateEnemy(float positionX)
    {
        if (_playerPosition.position.y > 10 && Randomise(30))
            Instantiate(_enemy, gameObject.transform.position + new Vector3(positionX, 1, 0), Quaternion.identity, gameObject.transform);   
    }

    private void CreateCoin(float positionX)
    {
        if (Randomise(40))
            Instantiate(_coin, gameObject.transform.position + new Vector3(positionX, 0.5f, 0), Quaternion.identity, gameObject.transform);
    }

    private void CreateReorientedTridder(float positionX)
    {
        Instantiate(_reorientedTrigger, gameObject.transform.position + new Vector3(positionX, 1, 0), Quaternion.identity, gameObject.transform);        
    }

    private bool Randomise(int chance)
    {
        int rand = Random.Range(0, 99);
        bool answer = false;

        if (rand <= chance + 1)
        {
            answer = true;
        }       

        return answer;
    }
}
