
using System;
using System.Collections;
using UnityEngine;

public class PlayerPhysicsManager : MonoBehaviour, IRigidbodyPhysicsManager
{

    private new Collider collider;
    private new Rigidbody rigidbody;

    [SerializeField]
    public float CollisionCheckRange = 0.025f;

    public void Awake()
    {
        collider = GetComponent<Collider>();
        rigidbody = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        rigidbody.useGravity = !IsGrounded();
    }
    public bool IsGrounded()
    {
        RaycastHit hit;
        Ray ray = new Ray(GetBottomOfPlayerObject(), Vector3.down);
		Debug.DrawRay(GetBottomOfPlayerObject(), Vector3.down, Color.red, CollisionCheckRange);
		Physics.Raycast(ray, out hit, CollisionCheckRange);
        return hit.collider != null;

    }

    public void Jump( float jumpStrength)
    {
        Debug.Log("Trying to jump.");
        if(IsGrounded())
        {
            Debug.Log("Jumping!");
            rigidbody.AddForceAtPosition(new Vector3(0,jumpStrength, 0), transform.position, ForceMode.Impulse);
        }
    }
    public void SetGravityEnabled(bool enabled)
    {
        rigidbody.useGravity = enabled;
    }

    private Vector3 GetBottomOfPlayerObject()
	{
		return transform.position - new Vector3(0, collider.bounds.extents.y - 0.01f, 0);
	}
}