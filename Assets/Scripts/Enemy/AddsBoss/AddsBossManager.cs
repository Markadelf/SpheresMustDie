using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddsBossManager : MonoBehaviour {
    public GameObject leaf1;
    public GameObject leaf2;
    public GameObject stem;
    public static GameObject head;
    // Use this for initialization

    private void Awake()
    {
        head = gameObject;
    }
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        if (head == null) {

                Destroy(leaf1);
                Destroy(leaf2);
                Destroy(stem);
                //foreach (Transform child in leaf1.transform) {
                //    GameObject.Destroy(child.gameObject);
                //}
                //foreach (Transform child in leaf2.transform)
                //{
                //    GameObject.Destroy(child.gameObject);
                //}
                //foreach (Transform child in stem.transform)
                //{
                //    GameObject.Destroy(child.gameObject);
                //}

            
        }

	}
}
