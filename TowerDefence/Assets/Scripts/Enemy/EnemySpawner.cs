using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private bool _isActive;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private float _interval;

    private void Start()
    {
        if (_isActive)
            StartSpawn();
    }

    public void StopSpawn()
    {
        _isActive = false;
        StopCoroutine(SpawnEnemyCoroutine());
    }

    public void StartSpawn()
    {
        StartCoroutine(SpawnEnemyCoroutine());
        _isActive = true;
    }

    IEnumerator SpawnEnemyCoroutine()
    {
        while(_isActive)
        {
            Instantiate(_enemy, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(_interval);
        }
    }
}
