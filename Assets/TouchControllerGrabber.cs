using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControllerGrabber : MonoBehaviour
{
    public List<Collider> CollidersGrabbedObjectsIgnore;
    public OVRInput.Controller AssignedController;

    public GameObject GrabbedObject;
    public Rigidbody GrabbedObjectRigidbody;
    private bool GrabbedObjectRigidbodyWasKinematic;
    private GameObject ObjectToGrab;

	// Update is called once per frame
	void FixedUpdate () {
        GrabOrReleaseObject();
        UpdateGrabbedObjectTransform();
    }

    private void OnTriggerEnter(Collider other)
    {
        ObjectToGrab = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == ObjectToGrab)
        {
            ObjectToGrab = null;
        }
    }

    private void GrabOrReleaseObject()
    {
        if (Input.GetKeyDown(KeyCode.Space) || OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, AssignedController)) {
            if (GrabbedObject != null)
            {
                ReleaseObject();
            }
            else
            {
                if (ObjectToGrab != null)
                {
                    GrabObject(ObjectToGrab);
                }
            }
        }
    }

    private void UpdateGrabbedObjectTransform()
    {
        if (GrabbedObject != null)
        {
            GrabbedObjectRigidbody.MovePosition(transform.position);
            GrabbedObjectRigidbody.MoveRotation(transform.rotation);
        }
    }

    private void GrabObject(GameObject obj) {
        GrabbedObject = obj;
        GrabbedObjectRigidbody = obj.GetComponent<Rigidbody>();

        var objCollider =  obj.GetComponent<Collider>();
        if (objCollider != null) {
            foreach (var handCollider in CollidersGrabbedObjectsIgnore) {
                Physics.IgnoreCollision(handCollider, objCollider);
            }
        }

        if (GrabbedObjectRigidbody != null) {
            GrabbedObjectRigidbodyWasKinematic = GrabbedObjectRigidbody.isKinematic;
            GrabbedObjectRigidbody.isKinematic = true;
        }
    }

    private void ReleaseObject() {
        var objCollider = GrabbedObject.GetComponent<Collider>();
        foreach (var handCollider in CollidersGrabbedObjectsIgnore)
        {
            Physics.IgnoreCollision(handCollider, objCollider, false);
        }

        GrabbedObjectRigidbody.isKinematic = GrabbedObjectRigidbodyWasKinematic;
        GrabbedObject = null;
        GrabbedObjectRigidbody = null;
    }
}
