using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int spawnAfterSec;
    public GameObject[] enemiesToSpawn;
    private int enemyType = 0;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnNow", 5, spawnAfterSec);
        
    }

    // Update is called once per frame
    Vector3 GetRandomPosition()
    {
        int randomCorner = Random.Range(1, 5);
        float _x, _y, _z;
        if (randomCorner==1)
        {
            _z = -70f;
            _y = -1.607807f;
            _x = Random.Range(-100f, 90f);
        }
        else if (randomCorner == 2)
        {
            _z = 66f;
            _y = -1.607807f;
            _x = Random.Range(-100f, 90f);
        }
        else if (randomCorner == 3)
        {
            _x = -70f;
            _y = -1.607807f;
            _z = Random.Range(-100f, 90f);
        }
        else
        {
            _x = 66f;
            _y = -1.607807f;
            _z = Random.Range(-100f, 90f);
        }

 
        Vector3 newPosition = new Vector3(_x,_y,_z);
        return newPosition;
    }


    void SpawnNow()
    {
        Instantiate(enemiesToSpawn[enemyType], GetRandomPosition(), Quaternion.identity);
        if (enemyType == 0)
        {
            enemyType = 1;
        }
        else
        {
            enemyType = 0; ;
        }
        
    }


}
