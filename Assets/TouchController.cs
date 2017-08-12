using UnityEngine;

public class TouchController : MonoBehaviour {
    public OVRInput.Controller AssignedController;
	
	// Update in FixedUpdate since this controller drives a model with a physics collider.
	void FixedUpdate () {
        transform.localPosition = OVRInput.GetLocalControllerPosition(AssignedController);
        transform.localRotation = OVRInput.GetLocalControllerRotation(AssignedController);
    }
}
