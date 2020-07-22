using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _levelManager : MonoBehaviour
{
    public List<GameObject> spawners;
    public float waveForceCoefficient = 1;
    public const float increaseWaveForceCoefficient = 0.01f;
    public int waveAmountOfEnemy=10;
    public int maxWaveAmountOfEnemy=100;
    public _enemyAttributes enemyAttributes;
    public _playerAttributes playerAttributes;
    public float startEnemyHP;
    public float minEnemyDMG;
    public float maxEnemyDMG;
    public int countToSpawn;
    public GameObject enemy;
    List<GameObject> enemies;
    bool isStartingWave = true;
    bool isEndingWave = false;

    void Start()
    {
        enemies = new List<GameObject>();
        startEnemyHP = enemyAttributes.hp;
        minEnemyDMG = enemyAttributes.minDamage;
        maxEnemyDMG = enemyAttributes.maxDamage;
        isStartingWave = true;
        isEndingWave = false;
    }

   
    void Update()
    {
        
        if(isStartingWave)
        {
            startWave();
            isStartingWave = false;
           
        }



    }

    void startWave()
    {
        //calc force
        calculationEnemyWaveForce();
        SpawningEnemy();

    }
    void SpawningEnemy()
    {
        countToSpawn = waveAmountOfEnemy;

        while (countToSpawn != 0)
        {
            Vector3 spawnPosition;
            int index = randSpawn();
            Debug.Log(index);
            spawnPosition = spawners[index].transform.position;

            Instantiate(enemy, spawnPosition, Quaternion.identity);

            countToSpawn--;
        }
    }
    void calculationEnemyWaveForce()
    {
        waveForceCoefficient = waveForceCoefficient + increaseWaveForceCoefficient;

        waveAmountOfEnemy = waveAmountOfEnemy * (int)waveForceCoefficient;
        waveAmountOfEnemy = Mathf.Clamp(waveAmountOfEnemy, 0, maxWaveAmountOfEnemy);

        float tempHP = startEnemyHP;
        tempHP *= waveForceCoefficient;
        enemyAttributes.hp = (int)tempHP;

        float tempMinDMG = minEnemyDMG;
        minEnemyDMG *= waveForceCoefficient;
        enemyAttributes.minDamage = (int)tempMinDMG;

        float tempMaxDMG = maxEnemyDMG;
        tempMaxDMG *= waveForceCoefficient;
        enemyAttributes.maxDamage = (int)tempMaxDMG;
    }
    int randSpawn()
    {
     
        return UnityEngine.Random.Range(0, spawners.Count); //maybe -1
    }
}
