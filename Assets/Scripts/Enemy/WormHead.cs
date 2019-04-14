﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormHead : MonoBehaviour
{

    public GameObject WormTail;
    public int Length;
    public int enrageLength;

    FlierAI ai;
    ComplexEnemyHealth health;
    WormBody first;
    private float dist;
    public float fireRate;
    public float fireDelay;
    private float timer;

    // Use this for initialization
    void Start()
    {
        ai = GetComponent<FlierAI>();
        health = GetComponent<ComplexEnemyHealth>();
        Transform node = health.WeakPoints[0].transform;
        GameObject next = Instantiate(WormTail);
        first = next.GetComponent<WormBody>();
        WormBody comp = first;
        WormBody last = first;
        //next.transform.parent = node;
        next.transform.position = node.position;
        node = comp.Connect.transform;
        node.forward = transform.forward;
        node.up = Vector3.up;

        for (int i = 1; i < Length; i++)
        {
            next = Instantiate(WormTail);
            next.name = "Body Segment: " + i;
            comp = next.GetComponent<WormBody>();
            //next.transform.parent = node;
            next.transform.position = node.position;
            node = comp.Connect.transform;
            node.forward = transform.forward;
            node.up = Vector3.up;
            last.Weak.Dependant = next;
            last.Next = comp;
            last = comp;
        }

        health.WeakPoints[0].Dependant = first.gameObject;

        dist = (transform.position - first.transform.position).magnitude;
        timer = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        //return;
        if (first != null)
        {
            int l = first.WormMove(transform.position, dist);
            if (timer > 0 && l <= enrageLength)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    first.WormShoot(fireDelay);
                    timer = fireRate;
                }
            }
        }
    }
}
