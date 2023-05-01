using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnPoints : MonoBehaviour
{
    [SerializeField] protected GameObject Camera;
    [SerializeField] protected float spawnerRate = 1.5f;
    [SerializeField] protected int numberEnemy = 3;
    [SerializeField] protected List<Transform> points;
    [SerializeField] protected GameObject[] enemyPre;

    void Start()
    {
        Camera = GameObject.FindWithTag("MainCamera");
        StartCoroutine(Spawner());
    }

    private void Update()
    {
        if (Camera == null) return;
        this.transform.position = new Vector3(Camera.transform.position.x, Camera.transform.position.y, 0);
    }

    IEnumerator Spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnerRate);

            int Enemy = Random.Range(1, this.numberEnemy + 1);
            for (int i = 0; i < Enemy; i++)
            {
                int randEnemy = Random.Range(0, enemyPre.Length);
                int randPoint = Random.Range(0, points.Count);
                GameObject enemySpawner = enemyPre[randEnemy];
                Instantiate(enemySpawner, points[randPoint].position, Quaternion.identity);
            }
        }
    }

    protected virtual Transform GetRandomPoint()
    {
        int rand = Random.Range(0, this.points.Count);
        return this.points[rand];
    }

    protected virtual Transform GetRandomEnemy()
    {
        int rand = Random.Range(0, this.enemyPre.Length);
        return this.points[rand];
    }
}