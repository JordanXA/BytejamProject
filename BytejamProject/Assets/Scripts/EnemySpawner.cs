using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System;


public class EnemySpawner : MonoBehaviour
{
    public TextAsset waveFile;
    public GameObject[] enemyPrefabs;
    public List<List<int>> waves;

    public Transform spawnPoint;

    public float timeBetweenWaves = 10f;
    public float timeBetweenEnemies = .5f;
    private float countdown = 2f;

    
    private int waveIndex = 0;
    
    void Start() {
        waves = new List<List<int>>();
        XmlDocument waveXml = new XmlDocument();
        waveXml.LoadXml(waveFile.text);
        //TODO: ADD ERROR (TRY/CATCH) CHECKING!!
        foreach(XmlNode waveNode in waveXml.DocumentElement.ChildNodes) {
            List<int> enemyList = new List<int>();
            foreach(XmlNode enemyNode in waveNode.ChildNodes) {
                enemyList.Add(int.Parse(enemyNode.InnerText));
            }
            waves.Add(enemyList);
        }
    }

    void Update()
    {
        if (countdown < 0f)
        {
            StartCoroutine(SpawnWave(waveIndex));
            //float waveLength = timeBetweenEnemies * waves[waveIndex].Count;
            countdown = timeBetweenWaves;
            waveIndex++;
        }
        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave(int waveIndex)
    {
        List<int> wave = waves[waveIndex];
        foreach (int i in wave) {
            SpawnEnemy(i);
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy(int enemyIndexs)
    {
        GameObject enemyPrefab = enemyPrefabs[enemyIndexs];
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
