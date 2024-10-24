using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    // Reference to fruit
    public GameObject fruit;
    public int xBoundries = 23;
    public int zBoundries = 23;
    private Vector3 pos = new Vector3(0,0.5f,0);

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnFruits");
    }

    IEnumerator SpawnFruits()
    {
        while(true)
        {
            pos.x = Random.RandomRange(-xBoundries, xBoundries);
            pos.z = Random.RandomRange(-zBoundries, zBoundries);

            Instantiate(fruit, pos, Quaternion.identity);

            yield return new WaitForSeconds(8);
        }
        
    }

}
