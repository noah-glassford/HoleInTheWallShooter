using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public List<Transform> SpawnPoints;
    public float SpawnInterval = 3f;
    private float SpawnTimer = 0f;

    public float SpawnSpeedMultiplier; 
    

   IEnumerator T()
   {
    yield return new WaitForSeconds(SpawnInterval);

    if (SpawnInterval > 0.8f)
    {
    SpawnInterval -= 0.1f;
    StartCoroutine(T());
    }

   }

   private void Start() 
   {
        StartCoroutine(T());
   }

    // Update is called once per frame
    void Update()
    {
        SpawnTimer += Time.deltaTime;

        if (SpawnTimer >= SpawnInterval)
        {
            SpawnTimer = 0f; //Reset timer

            int SpawnIndex = Random.Range(0, SpawnPoints.Count);

            Instantiate(EnemyPrefab, SpawnPoints[SpawnIndex].position, Quaternion.identity);
        }
    }
}
