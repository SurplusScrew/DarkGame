using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PlayerController : MonoBehaviour {
    public float JumpStrength { get; internal set; }
    public IInputManager inputManager { get; internal set; }
	public IMovementController movementController{ get; internal set; }

	[SerializeField]
	private Collider collider;
    void Awake()
	{

		if(inputManager == null) inputManager = gameObject.AddComponent<InControlInputManager>();
		if(movementController == null) movementController = gameObject.AddComponent<PlayerMovementController>();
		collider = GetComponent<Collider>();

	}
	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{
		movementController.Move(inputManager.GetInputVector());
		if(inputManager.GetButtonState(Action.Jump)) Jump();
	}

	public bool IsOnSurface()
	{
		Debug.DrawRay(GetBottomOfPlayerObject(), transform.TransformDirection(Vector3.down), Color.red, 0.025f);
		return Physics.Raycast(GetBottomOfPlayerObject(), transform.TransformDirection(Vector3.down), 0.025f);
	}

	private Vector3 GetBottomOfPlayerObject()
	{
		return transform.position - new Vector3(0, collider.bounds.extents.y, 0);
	}

    public void Jump()
	{
		if(IsOnSurface())
		{
			Debug.Log("Jumping.");
			movementController.Jump(JumpStrength);
		}
	}
}



