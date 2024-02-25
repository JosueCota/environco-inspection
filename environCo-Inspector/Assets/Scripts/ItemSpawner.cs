using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] item;

    [SerializeField]
    float minX;
    [SerializeField]
    float maxX;
    [SerializeField]
    float minY;
    [SerializeField]
    float maxY;

    [SerializeField]
    int spawnAmount;
    

    // Update is called once per frame
    void Awake()
    {
        SpawnItem();
    }

    private void SpawnItem()
    {
        for (int i = 0; i< spawnAmount; i++)
        {
            var  xRange = Random.Range(minX, maxX);
            var yRange = Random.Range(minY, maxY);

            var position = new Vector3(xRange, yRange, 0 );
            // Sets random oject from item array at random positon
            GameObject gameObject = Instantiate(item[Random.Range(0, item.Length)], position, Quaternion.identity);
        }
    }
}
