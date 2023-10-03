using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class GenerateRocks : MonoBehaviour
{
    [SerializeField] private GameObject myRocks;

    public Vector2 mySpawnBoxRadius;
    public int myAmountOfRocks;

    private void Awake()
    {
        Vector2[] tempList = new Vector2[myAmountOfRocks];
        for (int i = 0; i < myAmountOfRocks; i++)
        {
            Vector2 randomSpawn = new Vector2(transform.position.x + Random.Range(-mySpawnBoxRadius.x, mySpawnBoxRadius.x), Random.Range(-mySpawnBoxRadius.y, mySpawnBoxRadius.y));
            tempList[i] = randomSpawn;
            
            for (int j = 0; j < i; j++)
            {
                if (Vector2.Distance(tempList[j], tempList[i]) <= 1.3f)
                {
                    randomSpawn = new Vector2(transform.position.x + Random.Range(-mySpawnBoxRadius.x, mySpawnBoxRadius.x), Random.Range(-mySpawnBoxRadius.y, mySpawnBoxRadius.y));
                    tempList[i] = randomSpawn;
                }
            }
            Instantiate(myRocks, randomSpawn, Quaternion.identity);
        }
    }
}
