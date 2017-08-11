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
        var lines = new string[]{
            "DOT PRODUCT",
            string.Format("Vector A (orange): {0}", directionA),
            string.Format("Vector B (yellow): {0}", directionB),
            string.Format("A·B = ({0} * {1}) + ({2} * {3}) + ({4} * {5}) = {6}",
                directionA.x.ToString("n1"),
                directionB.x.ToString("n1"),
                directionA.y.ToString("n1"),
                directionB.y.ToString("n1"),
                directionA.z.ToString("n1"),
                directionB.z.ToString("n1"),
                result.ToString("n1")),
        };
        TextComponent.text = string.Join("\n", lines);
	}
}
