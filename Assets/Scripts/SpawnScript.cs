using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

    // Variable to store the enemy prefab
    public GameObject enemy;

    // Variable to know how fast we should create new enemies
    public float spawnTime;
    public int waitTime;

    //private float startTime;

    void Start() {
        // Call the 'addEnemy' function in 0 second
        // Then every 'spawnTime' seconds
        InvokeRepeating("addEnemy", 0, spawnTime);
    }

    // New function to spawn an enemy
    private void addEnemy() {

        //var renderer = GetComponent<Renderer>();

        Vector2 spawnPoint = new Vector2(transform.position.x, transform.position.y);

        Instantiate(enemy, spawnPoint, Quaternion.identity);
    }
}
