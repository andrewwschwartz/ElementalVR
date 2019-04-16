using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class enemySpawner : MonoBehaviour {

    // Use this for initialization
    public int numberOfEnemies;
    public Transform[] spawnLocations;
    public GameObject[] spawningEnemyObjects;
    public GameObject[] spawningEnemyObjectsClone;
    public Transform endPosition;
    public Transform startPosition;


    void destroyObjects () {
		
	}

    // Update is called once per frame
    void Update()
    {

        if (this.gameObject.transform.position == endPosition.position && GameObject.FindGameObjectWithTag("Enemy") == null)
        {
            print("Respawn!!!!!!!!!");
            spawnObjects();
            this.gameObject.transform.position = startPosition.position;
        }
    }
    void spawnObjects () {

        destroyEnemies();
        spawnThisEnemy();
	}

    void spawnThisEnemy()
    {
        for (int i=0; i< numberOfEnemies; i++)
        {
            print("SPAWNNN");
            if (spawningEnemyObjects[i] != null)
            {
                spawningEnemyObjectsClone[i] = Instantiate(spawningEnemyObjects[i], spawnLocations[i].transform.position, spawnLocations[i].transform.rotation) as GameObject;
                spawningEnemyObjectsClone[i].GetComponent<Movement>().waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
                spawningEnemyObjectsClone[i].GetComponent<Enemy>().player = Player.FindObjectOfType<Player>();
                spawningEnemyObjectsClone[i].GetComponent<Enemy>().headTarget = GameObject.FindGameObjectWithTag("Target");

            }
        }
    }
    void destroyEnemies()
    {
        for (int i=0; i < numberOfEnemies; i++)
        {
            print("Destroy!!");
            Destroy(spawningEnemyObjectsClone[i]);
        }
    }

}
