using UnityEngine;

public class TouchController : MonoBehaviour {
    public OVRInput.Controller AssignedController;
    private Rigidbody RigidbodyToDrive;

    private void Start()
    {
        RigidbodyToDrive = GetComponent<Rigidbody>();
    }

    void FixedUpdate () {
        // Update the transform in FixedUpdate so that if the GO we're controlling has a physics
        // collider, it will update its position as often as other physics calcs happen.
        UpdateTransformFromController();
    }

    void UpdateTransformFromController()
    {
        var localControllerPosition = OVRInput.GetLocalControllerPosition(AssignedController);
        var localControllerRotation = OVRInput.GetLocalControllerRotation(AssignedController);

        // If this script is driving a GO with a Rigidbody, move the GO via the Rigidbody so that
        // the physics system knows about the movement.
        // Else if this GO doesn't have a Rigidbody, just move the GO normally.
        if (RigidbodyToDrive != null)
        {
            RigidbodyToDrive.MovePosition(transform.parent.position + localControllerPosition);
            RigidbodyToDrive.MoveRotation(transform.parent.rotation * localControllerRotation);
        }
        else
        {
            transform.localPosition = localControllerPosition;
            transform.localRotation = localControllerRotation;
        }
    }
}
