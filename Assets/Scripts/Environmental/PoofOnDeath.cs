using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoofOnDeath : MonoBehaviour {
    public GameObject poofPrefab = null;

    private void OnDestroy()
    {
        GameObject poof = ObjectPool.GetObj(poofPrefab);
        if (poof != null)
        {
            poof.transform.position = transform.position;
            poof.SetActive(true);
            ParticleSystem.MainModule main = poof.GetComponent<ParticleSystem>().main;
            main.startColor = GetComponent<Renderer>().material.color;
        }
    }
}
