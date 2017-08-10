using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DotProductCalculator : MonoBehaviour {
    public GameObject ArrowA;
    public GameObject ArrowB;
    public Text TextComponent;

	// Use this for initialization
	void Start ()
    {

    }
	
	// Update is called once per frame
	void Update () {
        // Because this visualization is for the dot product of two vectors, we need to build
        // direction vectors out of the rotations to take the dot product of. We might be tempted
        // to simply take the dot product of the two rotations, but any given vector can have
        // multiple rotations that result in it. Different rotations yield different dot products,
        // even though the vectors are identical. Identical vectors should always yield the same
        // dot product, so this doesn't work.
        //
        // Multiply the rotations by Vector3.right because the initial orientation of the arrows
        // is in the +x direction;  the direction the arrows are facing is an offset from +x.
        var directionA = ArrowA.transform.rotation * Vector3.right;
        var directionB = ArrowB.transform.rotation * Vector3.right;

        var result = Vector3.Dot(directionA, directionB);
        TextComponent.text = string.Format("direction A: {0}\ndirection b:{1}\nangle between: {2}\ndot product: {3}",
            directionA,
            directionB,
            Vector3.Angle(directionA, directionB),
            result);
	}
}
