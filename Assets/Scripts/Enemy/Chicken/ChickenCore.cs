using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenCore : MonoBehaviour {

    private BigChicken connected;
    public int Health;
    public GameObject LittleChicken;
    private Transform[] spawnPoints;
    public float PhasePeriod;

    private float timer;
    private int chicksCollected = 0;

    public static bool collecting;

    public void Connect(BigChicken chicken)
    {
        connected = chicken;
        spawnPoints = connected.GetComponentsInChildren<Transform>();
    }

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(timer > 0)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                collecting = true;
            }
        }
        else if(chicksCollected >= Health)
        {
            connected.ReactivateChicken(Health);
            gameObject.SetActive(false);
        }
	}

    public void ActivateCore()
    {
        SpawnChickens();

        transform.position = connected.eye.transform.position;
        transform.forward = connected.eye.transform.forward;

        chicksCollected = 0;
        collecting = false;
        timer = PhasePeriod;

        gameObject.SetActive(true);
    }

    private void SpawnChickens()
    {
        for (int i = 0; i < Health; i++)
        {
            GameObject chick = ObjectPool.GetObj(LittleChicken);
            chick.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
            chick.transform.forward = connected.transform.forward;

            TinyChicken chickScript = chick.GetComponent<TinyChicken>();
            chickScript.core = this;
            chickScript.active = true;

            chick.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(collecting)
        {
            TinyChicken chickScript = other.GetComponent<TinyChicken>();
            if (chickScript != null)
            {
                chickScript.active = false;
                chickScript.gameObject.SetActive(false);
                chicksCollected++;
            }
        }
    }
}
