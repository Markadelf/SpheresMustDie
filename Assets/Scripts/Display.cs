using UnityEngine;
using System.Collections;

public class Display : MonoBehaviour {

    public float angle = 0.0f;
    public Quaternion rotation;
    public bool On = false;
    public bool Off = true;
    public Quaternion Origin;

	// Use this for initialization
	void Start ()
    {
        rotation = transform.rotation;
        Origin = gameObject.transform.rotation;
	}
	
	// Update is called once per frame
	void Update ()
    {
        rotation = Quaternion.Euler(0, angle, 0);
        transform.rotation = rotation;

        if (gameObject.tag == "Shield")
        {
            rotation = Quaternion.Euler(0, 0, angle);
            transform.rotation = rotation;
        }


        if (Input.GetKey(KeyCode.Alpha1))
        {
            On = true;
            Off = false;
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            if (gameObject.tag == "Back")
            {
                On = false;
                Off = true;
                rotation = Quaternion.Euler(0, 0, 0);
                angle = 0.0f;
            }
            else if (gameObject.tag == "Sides")
            {
                On = false;
                Off = true;
                rotation = Quaternion.Euler(0, 90, 0);
                angle = 90.0f;
            }
            else if (gameObject.tag == "Shield")
            {
                On = false;
                Off = true;
                rotation = Quaternion.Euler(0, 0, 0);
                angle = 0.0f;
            }
        }

        if (On == true)
        {
            Turn();
        }
       

        if (angle >= 360.0f)
        {
            angle = 0.0f;
        }
        else if (angle <= -360.0f)
        {
            angle = 0.0f;
        }
    }

    public void Turn()
    {
        angle -= 90.0f * Time.deltaTime;
    }

    void OnGUI()
    {
        GUI.Box(new Rect(190, 80,400,25), "Press 1 to activate Display Mode and Press 2 to Deactivate it");
    }

}
