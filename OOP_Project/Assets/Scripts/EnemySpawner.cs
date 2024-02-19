using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject _enemyToSpawn;
    public float _spawnCD = 1;
    public Vector2 _spawnAreaSize;

    private float _timeSinceLastSpawn;

	private void Update () {
        _timeSinceLastSpawn += Time.deltaTime;
        if (_timeSinceLastSpawn >= _spawnCD)
            SpawnEnemy(_enemyToSpawn);
    }

    private void SpawnEnemy(GameObject enemyGO)
    {
        Vector3 spawnPos = transform.position + new Vector3(Random.Range(-_spawnAreaSize.x, _spawnAreaSize.x), Random.Range(-_spawnAreaSize.y, _spawnAreaSize.y), 0);
        Instantiate(enemyGO, spawnPos, Quaternion.identity);
        _timeSinceLastSpawn = 0;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(transform.position, _spawnAreaSize*2);
    }
}
