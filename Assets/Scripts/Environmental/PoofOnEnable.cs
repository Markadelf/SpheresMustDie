using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoofOnEnable : MonoBehaviour {
    public GameObject poofPrefab = null;
    bool started = false;
    public bool onEnable;
    public bool onDisable;

    private void Start()
    {
        started = true;
        OnEnable();
    }

    void OnEnable()
    {
        if(!started || !onEnable)
        {
            return;
        }
        GameObject poof = ObjectPool.GetObj(poofPrefab);
        if (poof != null)
        {
            poof.transform.position = transform.position;
            poof.SetActive(true);
            ParticleSystem.MainModule main = poof.GetComponent<ParticleSystem>().main;
            main.startColor = GetComponent<Renderer>().material.color;
        }
    }

    private void OnDisable()
    {
        if (!started || !onDisable)
        {
            return;
        }
        GameObject poof = ObjectPool.GetObj(poofPrefab);
        if (poof != null)
        {
            poof.transform.position = transform.position;
            poof.SetActive(true);
            ParticleSystem.MainModule main = poof.GetComponent<ParticleSystem>().main;
            main.startColor = GetComponent<Renderer>().material.color;
        }
    }

    private void OnApplicationQuit()
    {
        started = false;
    }
}
