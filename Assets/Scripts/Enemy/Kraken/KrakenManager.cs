using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrakenManager : MonoBehaviour {

    public static int health;

    [SerializeField]
    private int startHealth;

    [SerializeField]
    private KrakenSpawner spawner;

	// Use this for initialization
	void Start () {
        health = startHealth;
        spawner.StartSpawning();
	}
	
	// Update is called once per frame
	void Update () {
		
        if (health <= 0) {
            Debug.Log("STOP");
            spawner.StopSpawning();
        }

	}
}
