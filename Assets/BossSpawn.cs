using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    public GameObject[] BossSpawnPrefab;

    int rand;
    int chanceToSpawn;

    int bossSpawnNumber;


    private void Start()
    {
        rand = Random.Range(0, BossSpawnPrefab.Length);
        chanceToSpawn = Random.Range(0, 1000);
        bossSpawnNumber = Random.Range(0, 1000);
        Debug.Log(bossSpawnNumber);
        Debug.Log(chanceToSpawn);

        if(bossSpawnNumber == chanceToSpawn)
        {
            Instantiate(BossSpawnPrefab[rand]);
        }
    }
}
