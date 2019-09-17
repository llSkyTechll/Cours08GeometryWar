using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public float spawnRate = 1;
    private float timeLeftBeforeSpawn = 0;
    private SpawnPoint[] spawnPoints;
    public GameObject[] ennemiPrefab;
	// Use this for initialization
	void Start () {
        spawnPoints = FindObjectsOfType<SpawnPoint>();
        timeLeftBeforeSpawn = 1 / spawnRate;
	}
	
	// Update is called once per frame
	void Update () {
        UpdateSpawn();
	}

    private void UpdateSpawn()
    {
        timeLeftBeforeSpawn -= Time.deltaTime;
        int ennemiToSpawn;
        if (timeLeftBeforeSpawn < 0)
        {
            ennemiToSpawn = Random.Range(0, 2);
            SpawnEnnemi(ennemiToSpawn);
            timeLeftBeforeSpawn = 1 / spawnRate;
        }
    }

    private void SpawnEnnemi(int ennemiIndex)
    {
        int countSpawnPoint = spawnPoints.Length;
        int randomSpawnPointIndex = Random.Range(0, countSpawnPoint);
        SpawnPoint spawnPointRandomlySelected = spawnPoints[randomSpawnPointIndex];
        GameObject newEnnemi = Instantiate(ennemiPrefab[ennemiIndex], spawnPointRandomlySelected.GetPosition(), spawnPointRandomlySelected.transform.rotation);
    }
}
