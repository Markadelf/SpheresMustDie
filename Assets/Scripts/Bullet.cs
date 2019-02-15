using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed;
    public float range;

    private Rigidbody rigid;
    private float timer;

	// Use this for initialization
	void Awake () {
        rigid = GetComponent<Rigidbody>();
	}

    private void OnEnable()
    {
        rigid.velocity = transform.forward * speed;
        timer = range / speed;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            ObjectPool.Release(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        ObjectPool.Release(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        ObjectPool.Release(gameObject);
    }
}
