using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stem : MonoBehaviour {

    public int stemLen;
    public GameObject AddsBossHead;
    public GameObject[] stemSegs;
    public GameObject[] insSegs;
    public Vector3[] segStartPos;

	// Use this for initialization
	void Start () {
        int p = 0;
        for (int i = 0; i < (stemLen/stemSegs.Length); i++) {
            for (int j = 0; j < stemSegs.Length; j++) {
                GameObject go = Instantiate(stemSegs[j], new Vector3(this.transform.position.x, this.transform.position.y + 2.8f * p, this.transform.position.z), Quaternion.identity) as GameObject;
                go.transform.parent= this.transform;
                insSegs[p] = go;
                segStartPos[p] = go.transform.position;
                p++;
            }
        }
        GameObject head = Instantiate(AddsBossHead, new Vector3(765, 30, 48), Quaternion.identity) as GameObject;
        head.transform.parent = this.transform;
        insSegs[p] = head;
        segStartPos[p] = head.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < insSegs.Length - 1; i++) {
            insSegs[i].transform.position = segStartPos[i] + new Vector3(Mathf.Sin(Time.time + 0.5f * i), 0, 0);
        }
	}
}
