using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadBossSwitch : MonoBehaviour {

    public int bossId;
    public GameObject alive;
    public GameObject dead;

    public bool checkEachFrame;

	// Use this for initialization
	void Start () {
        if (BossDeathTracker.CheckDead(bossId))
        {
            alive.SetActive(false);
            dead.SetActive(true);
        }
        else
        {
            alive.SetActive(true);
            dead.SetActive(false);
        }
        if(!checkEachFrame)
        {
            Destroy(this);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (BossDeathTracker.CheckDead(bossId))
        {
            alive.SetActive(false);
            dead.SetActive(true);
        }
        else
        {
            alive.SetActive(true);
            dead.SetActive(false);
        }
    }
}
