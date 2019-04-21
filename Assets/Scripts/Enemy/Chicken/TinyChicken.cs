using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinyChicken : MonoBehaviour {
    public ChickenCore core;
    public bool active;
    public float agility;
    public float speed;
    Rigidbody rigid;

    private Vector3 rand;

	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody>();
	}

    private void OnEnable()
    {
        rand = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
    }

    // Update is called once per frame
    void Update() {
        Vector3 target = new Vector3();
        if (ChickenCore.collecting)
        {
            target = core.transform.position;
        }
        else
        {
            target = transform.position + rand;
        }

        Vector3 toPlayer = target - transform.position;
        toPlayer.y = 0;
        if (toPlayer.x != 0 || toPlayer.z != 0)
        {
            Vector3 dir = Vector3.RotateTowards(transform.forward, toPlayer, agility * Time.deltaTime, 10000);
            dir.y = 0;
            transform.forward = dir;
        }
        rigid.velocity = transform.forward * speed + new Vector3(0, rigid.velocity.y, 0);
    }

    private void OnDisable()
    {
        if (active)
        {
            core.Health--;
        }
    }

}
