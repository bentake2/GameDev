using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{

    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform pathPreFab;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float timeBetweenEnemySpawns = 1f;
    [SerializeField] float spawnTimeVariances = 0f;
    [SerializeField] float minimumSpawnTime = 0.2f;

    public Transform GetStartingWayPoint()
    {
        return pathPreFab.GetChild(0);
    }
    
    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach (Transform child in pathPreFab)
        {
            waypoints.Add(child);
        }
            return waypoints;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
    }

    public float getRandomSpawnTime()
    {
        float spawnTime = Random.Range(timeBetweenEnemySpawns - spawnTimeVariances,
                                        timeBetweenEnemySpawns + spawnTimeVariances);
        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
    }
}
