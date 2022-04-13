using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject targetPrefab;
    [SerializeField]
    int spawnRatePerSecond;
    [SerializeField]
    Transform floor;

    float timeCnt=0;
    void Update()
    {
        timeCnt += Time.deltaTime;
        if (timeCnt > 1.0f) {
            SpawnTarget(spawnRatePerSecond);
            timeCnt = 0;
        }
    }
    void SpawnTarget(int n) {
        float range = floor.localScale.x * 5;
        for (int i = 0; i < n; i++) {
            Instantiate(targetPrefab, new Vector3(Random.Range(-range, range),Random.Range(0f,10f), Random.Range(-range, range)), Quaternion.identity);
        }
    }
}
