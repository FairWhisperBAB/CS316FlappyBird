using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{
    public GameObject columnPrefab;
    public int columnPoolSize = 5;
    public float spawnRate = 3f;
    public float columnMin = -2f;
    public float columnMax = 2f;

    private GameObject[] columns;
    private int currentColumn = 0;

    private Vector2 objectPoolPosition = new Vector2(-15, -25);
    private float spawnXPosition = 10f;

    private float timeSinceLastSpawned;

    // Start is called before the first frame update
    void Start()
    {
        timeSinceLastSpawned = 0f;

        //creates the columns collection
        columns = new GameObject[columnPoolSize];
        //puts prefabs into the array
        for (int i = 0; i < columnPoolSize; i++)
        {
            columns[i] = (GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

        //spawns columns as long as the game isnt over
        if (GameManager.instance.isGameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0f;

            //set random y position
            float spawnYPosition = Random.Range(columnMin, columnMax);
            //then set the curent column to that postion
            columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);

            //increases the index in array
            currentColumn++;
            //loops the array
            if (currentColumn >= columnPoolSize)
            {
                currentColumn = 0;
            }
        }
    }
}
