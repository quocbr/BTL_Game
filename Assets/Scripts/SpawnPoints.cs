using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    [SerializeField] protected float spawnerRate = 1f;
    [SerializeField] protected List<Transform> points;
    [SerializeField] protected GameObject[] enemyPre;

    void Start()
    {
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnerRate);
            
            int randEnemy = Random.Range(0, enemyPre.Length);
            int randPoint = Random.Range(0, points.Count); 
            GameObject enemySpawner = enemyPre[randEnemy];
            Instantiate(enemySpawner, points[randPoint].position, Quaternion.identity);
         
         
        }
    }

    protected virtual Transform GetRandomPoint()
    {
        int rand = Random.Range(0,this.points.Count);
        return this.points[rand];
    }
    
    protected virtual Transform GetRandomEnemy()
    {
        int rand = Random.Range(0,this.enemyPre.Length);
        return this.points[rand];
    }
}
