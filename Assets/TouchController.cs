using UnityEngine;

public class TouchController : MonoBehaviour {
    public OVRInput.Controller AssignedController;
	
	// Update is called once per frame
	void Update () {
        transform.localPosition = OVRInput.GetLocalControllerPosition(AssignedController);
        transform.localRotation = OVRInput.GetLocalControllerRotation(AssignedController);
    }
}
