using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBlock : MonoBehaviour
{

    public GameObject obstacle; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnBlock()
    {
        int spawnerPointX = Random.Range(-9, 9);
        int spawnerPointZ = Random.Range(50, 200);

        Vector3 spawnPosition = new Vector3(spawnerPointX, 0, spawnerPointZ);

        Instantiate(obstacle, spawnPosition, Quaternion.identity);

    }
}
