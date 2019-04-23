using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EasyModeButton : MonoBehaviour {
    private TextMeshProUGUI text;

	// Use this for initialization
	void Start () {
        text = GetComponent<TextMeshProUGUI>();
	    text.text = FirstPerson.EASY_MODO ? "Easy Mode: On" : "Easy Mode: Off";
    }

    // Update is called once per frame
    void Update () {
    }

    public void Click()
    {
        FirstPerson.EASY_MODO = !FirstPerson.EASY_MODO;
	    text.text = FirstPerson.EASY_MODO ? "Easy Mode: On" : "Easy Mode: Off";
    }
}
