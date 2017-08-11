using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sets the given Collider components to ignore collisions between each other.
/// 
/// Similar results can be achieved using layers; this is an alternative if using layers is not
/// desired.
/// </summary>
public class CollisionIgnoreGroup : MonoBehaviour {
    public List<Collider> Colliders;

    void Start () {
		for (var i = 0; i < Colliders.Count; i++)
        {
            for (var j = i + 1; j < Colliders.Count; j++)
            {
                Physics.IgnoreCollision(Colliders[i], Colliders[j]);
            }
        }
	}
}
