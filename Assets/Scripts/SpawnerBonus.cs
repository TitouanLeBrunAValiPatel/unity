using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBonus : MonoBehaviour
{

    public GameObject bonus;
    // Start is called before the first frame update
    void Start()
    {
        bonus = GameObject.FindGameObjectWithTag("BonusSpeed");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnBonus(Vector3 position)
    {

        Instantiate(bonus, position, Quaternion.identity);

    }
}
