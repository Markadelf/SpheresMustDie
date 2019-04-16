using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrakenHead : MonoBehaviour {

    [SerializeField]
    private Vector2 depthOverTime;

    [SerializeField]
    private float timeUntilSink;

    [SerializeField]
    private float timeToSink;

    [SerializeField]
    GameObject mouth;

    private bool sinking = false;
    private bool dealtDamage = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (!sinking) {

            timeUntilSink -= Time.deltaTime;
            if (timeUntilSink <= 0) {
                StartCoroutine(Sink());
            }

            if (mouth == null && !dealtDamage && !sinking) {
                KrakenManager.health--;
                dealtDamage = true;
                StartCoroutine(Sink());
            }

        }
        

    }

    private IEnumerator Sink() {

        sinking = true;

        float timer = 0;
        while (timer < timeToSink) {

            timer += Time.deltaTime;
            float progress = timer / timeToSink;

            Vector3 pos = this.transform.localPosition;
            pos.y = Mathf.Lerp(depthOverTime.x, depthOverTime.y, progress);

            this.transform.localPosition = pos;

            yield return null;

        }

        Destroy(this.gameObject);

    }

}
