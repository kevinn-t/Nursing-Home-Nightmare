using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupSpawn : MonoBehaviour
{
    public GameObject enemy;
    Vector3 spawnPoint;
    int xOffset;
    int zOffset;
    int randRotation;

    // place a random amount of babies in random positions around a set spawning space
    void Awake()
    {  
        for (int i = 0;i<Random.Range(2,6);i++)
        {
            xOffset = Random.Range(-10,11);
            zOffset = Random.Range(-10,11);
            randRotation = Random.Range(0,360);
            spawnPoint = GetComponent<Transform>().position + new Vector3(xOffset, 0, zOffset);
            Instantiate(enemy, spawnPoint, Quaternion.Euler(0,randRotation,0));
        }
    }
}
