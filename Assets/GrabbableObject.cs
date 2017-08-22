using UnityEngine;

public class GrabbableObject : MonoBehaviour
{
    public TouchControllerGrabber GrabberHeldBy;

    public void Grab(TouchControllerGrabber grabber)
    {
        if (GrabberHeldBy != null)
        {
            GrabberHeldBy.ReleaseObject();
        }

        GrabberHeldBy = grabber;
    }

    public void Release()
    {
        GrabberHeldBy = null;
    }
}
