using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplineTraverser : MonoBehaviour {

    [SerializeField]
    private BezierSpline spline;

    [SerializeField]
    [Range(0, 1)]
    private float progress = 0;

    private void Update() {
        this.transform.position = spline.GetPoint(progress);
    }

}
