﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {


    public Transform enemyPrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    public Text waveCountdownText;

    private int waveIndex = 0;

    private void Update()
    {
        if(countdown <= 0f){

            StartCoroutine(spawnWave());
            countdown = timeBetweenWaves;

        }

        countdown -= Time.deltaTime;
        waveCountdownText.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator spawnWave(){

        waveIndex++;

        for (int i = 0; i < waveIndex; i++){
            spawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }



    }

    void spawnEnemy(){

        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

    }
}
