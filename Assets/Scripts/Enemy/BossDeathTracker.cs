using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeathTracker : MonoBehaviour {
    static List<int> deadBosses;

    public int bossId;

    static BossDeathTracker()
    {
        deadBosses = new List<int>();
    }


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MarkDead()
    {
        if (!deadBosses.Contains(bossId))
        {
            deadBosses.Add(bossId);
        }
    }

    public static bool CheckDead(int id)
    {
        return deadBosses.Contains(id);
    }
}
