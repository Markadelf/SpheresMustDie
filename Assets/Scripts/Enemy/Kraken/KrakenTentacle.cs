using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrakenTentacle : MonoBehaviour {

    [Header("Display")]

    [SerializeField]
    private BezierSpline[] splines;

    [SerializeField]
    private Transform segmentHolder;

    [SerializeField]
    private int numSegments;

    [SerializeField]
    private GameObject segmentPrefab;

    [SerializeField]
    private AnimationCurve segmentScaleCurve;

    [SerializeField]
    private Color highlightColor;

    [Header("Aniamtion")]

    [SerializeField]
    private AnimationCurve idleAnimationCurve;

    [SerializeField]
    private AnimationCurve attackPullbackCurve;

    [SerializeField]
    private AnimationCurve attackSlamCurve;

    private Transform[] segments;

    [Header("Combat")]

    [SerializeField]
    private BoxCollider hitbox;

    private enum State {
        Idle,
        Attack
    }
    private State currentState = State.Idle;

	// Use this for initialization
	void Start () {
        Build();
        StartCoroutine(Idle());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private IEnumerator Idle() {

        int numCycles = 3;
        while (State.Idle == currentState) {

            float transitionProgress = 0;
            while (transitionProgress < 2) {

                transitionProgress += Time.deltaTime;
                if (transitionProgress > 2) transitionProgress = 2;

                float scaledProgress = Mathf.Abs(transitionProgress - 1);
                scaledProgress = idleAnimationCurve.Evaluate(scaledProgress);

                UpdateSegmentPositions(splines[0], splines[1], scaledProgress);
                yield return null;

            }

            numCycles--;
            if (numCycles == 0) {
                currentState = State.Attack;
            }

        }

        StartCoroutine(Attack());

    }

    private IEnumerator Attack() {

        float pullbackTime = 2f;
        float currPullbackTime = 0;
        while (currPullbackTime < pullbackTime) {

            currPullbackTime += Time.deltaTime;
            if (currPullbackTime > pullbackTime) currPullbackTime = pullbackTime;

            float transitionProgress = currPullbackTime / pullbackTime;
            float scaledProgress = attackPullbackCurve.Evaluate(transitionProgress);

            UpdateSegmentPositions(splines[1], splines[2], scaledProgress);

            yield return null;

        }

        yield return new WaitForSeconds(1);

        int numSlamSegments = 4;
        for (int i = 0; i < numSlamSegments; i++) {

            if (i == numSlamSegments - 1) {
                hitbox.enabled = true;
            }

            float slamSegmentTime = 0.05f;
            float currSlamTime = 0;
            while (currSlamTime < slamSegmentTime) {

                currSlamTime += Time.deltaTime;
                if (currSlamTime > slamSegmentTime) currSlamTime = slamSegmentTime;

                float transitionProgress = currSlamTime / slamSegmentTime;

                UpdateSegmentPositions(splines[2 + i], splines[3 + i], transitionProgress);

                yield return null;

            }

        }

        hitbox.enabled = false;

        yield return new WaitForSeconds(3);

        Destroy(this.gameObject);

    }

    private void Build() {
        segments = new Transform[numSegments];
        for (int i = 0; i < numSegments; i++) {
            float progress = (float)i / (float)(numSegments - 1);
            GameObject newSegObj = Instantiate(segmentPrefab, segmentHolder);
            Transform newSegTransform = newSegObj.transform;
            if (i % 3 == 0) {
                newSegObj.transform.Find("Center").GetComponent<MeshRenderer>().material.color = highlightColor;
            }
            newSegTransform.localScale = Vector3.one * segmentScaleCurve.Evaluate(progress);
            segments[i] = newSegObj.transform;
        }
        UpdateSegmentPositions(splines[0]);
    }

    private void UpdateSegmentPositions(BezierSpline spline) {
        for (int i = 0; i < numSegments; i++) {
            Transform seg = segments[i];
            float progress = (float)i / (float)(numSegments - 1);
            seg.transform.position = spline.GetPoint(progress);
        }
    }

    private void UpdateSegmentPositions(BezierSpline splineStart, BezierSpline splineEnd, float transitionProgress) {
        for (int i = 0; i < numSegments; i++) {
            Transform seg = segments[i];
            float progress = (float)i / (float)(numSegments - 1);
            seg.transform.position = Vector3.Slerp(splineStart.GetPoint(progress), splineEnd.GetPoint(progress), transitionProgress);
        }
    }

    private void OnTriggerEnter(Collider other) {
        
        if (other.gameObject.tag == "Player" && !FirstPerson.EASY_MODO) {
            Destroy(other.gameObject);
        }

    }

    private void OnCollisionEnter(Collision collision) {
        Debug.Log(collision.gameObject);
    }

}
