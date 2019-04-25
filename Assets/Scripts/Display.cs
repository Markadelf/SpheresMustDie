using UnityEngine;
using System.Collections;

public class Display : MonoBehaviour {

    private float angle = 0.0f;
    private Quaternion rotation;
    private Vector3 position;
    public float offSet = 0;

	// Use this for initialization
	void Start ()
    {
        rotation = this.gameObject.transform.rotation;
        position = this.gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        rotation = Quaternion.Euler(rotation.x, angle, rotation.z);
        angle -= 25.0f * Time.deltaTime;

        position.y = Mathf.Sin(Time.time)/2 + offSet;

        transform.rotation = rotation;
        transform.position = position;
    }
}
