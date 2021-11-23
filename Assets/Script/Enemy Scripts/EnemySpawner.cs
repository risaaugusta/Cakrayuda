using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public float min_Y = -1.07f, max_Y = 4.3f;
    public GameObject enemyPrefab;
    public GameObject landPrefab;
    public GameObject enemyPlanePrefab;
    public float timer = 2f; 

    // Start is called before the first frame update
    void Start(){
        Invoke("SpawnEnemies", timer);
        Invoke("SpawnLand", timer);
    }

    void SpawnEnemies(){
        float pos_Y = Random.Range(min_Y, max_Y);
        Vector3 temp = transform.position;
        temp.y = pos_Y;

        if(Random.Range(0,2) > 0){
            Instantiate(enemyPrefab, temp, Quaternion.Euler(0f,0f,0f));
        } else {
            Instantiate(enemyPlanePrefab, temp, Quaternion.Euler(0f,0f,0f));
        }

        Invoke("SpawnEnemies", timer);
    }

    void SpawnLand(){
        float pos_Y = Random.Range(-5f,-3.28f);
        Vector2 temp = transform.position;
        temp.y = pos_Y;

        if(Random.Range(0,2) > 0){
            Instantiate(landPrefab, temp, Quaternion.Euler(0f,0f,0f));
        }

        Invoke("SpawnLand", timer);
    }
}
