using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBlock : MonoBehaviour
{
    public GameObject obstacle; 

    public void SpawnBlock(Vector3 position)
    {
        Instantiate(obstacle, position, Quaternion.identity);
    }

}
