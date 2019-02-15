using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

    List<Transform> tracked;

    Vector3 lastpos;

    private void Start()
    {
        tracked = new List<Transform>();
    }

    // Update is called once per frame
    void LateUpdate () {
        //Vector3 delta = transform.position - lastpos;
        //for (int i = 0; i < tracked.Count; i++)
        //{
        //    tracked[i].position += delta;
        //}
        //lastpos = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        OnTriggerStay(other);   
    }

    private void OnTriggerStay(Collider other)
    {
        if (!tracked.Contains(other.transform))
        {
            tracked.Add(other.transform);
        }
        other.transform.parent = transform.parent;
    }

    private void OnTriggerExit(Collider other)
    {
        tracked.Remove(other.transform);
        other.transform.parent = null;
    }
}
