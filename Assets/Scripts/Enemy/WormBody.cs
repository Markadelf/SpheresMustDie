using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormBody : MonoBehaviour {

    public WeakPoint Weak;
    public Transform Connect;
    public WormBody Next;
    public Vector3 delta;

    private Gun gun;

    float timer;
    float delay;

	// Use this for initialization
	void Start () {
        gun = GetComponent<Gun>();
	}

    private void Update()
    {
        if (timer > 0 && Next != null)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Next.WormShoot(delay);
            }
        }
    }

    // Update is called once per frame
    // Feeds back length info
    public int WormMove(Vector3 pos, float dist)
    {
        Vector3 delta = pos - transform.position;
        transform.forward = delta;
        transform.position = pos - (delta.normalized * dist);
        if (Next)
        {
            return 1 + Next.WormMove(transform.position, dist);
        }
        else
        {
            return 1;
        }
    }

    public void WormShoot(float delay)
    {
        timer = delay;
        this.delay = delay;
        gun.TryShoot();
    }
}
