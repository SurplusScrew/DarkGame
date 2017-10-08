using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float JumpStrength
	{
		get
		{
			return jumpStrength;
		}
		set
		{
			jumpStrength = value;
		}

	}
	[SerializeField]
	private float jumpStrength = 5;
    public IInputManager[] InputManagers { get; set; }
	public IMovementController MovementController{ get; set; }

	public IRigidbodyPhysicsManager PhysicsManager{get;set;}

	private ICameraController cameraController;

	public GameObject Player, Camera;

    void Awake()
	{
		//Lazy loaded
		InputManagers = GetComponents<IInputManager>();
		if(InputManagers.Length == 0) InputManagers = new IInputManager[]{ gameObject.AddComponent<MB_KeyboardInputManager>() };

		//Lazy loaded
		MovementController = GetComponent<IMovementController>();
		if(MovementController == null) MovementController = Player.AddComponent<MB_PlayerMovementController>();

		cameraController = GetComponentInChildren<ICameraController>();
		cameraController.Camera = Camera;
		cameraController.ChaseTarget(Player);

		PhysicsManager = GetComponent<IRigidbodyPhysicsManager>();
		if(PhysicsManager == null) PhysicsManager = Player.AddComponent<PlayerPhysicsManager>();
	}

	void FixedUpdate()
	{
		Vector2 look = Vector2.zero;
		Vector2 move = Vector2.zero;

		foreach( IInputManager inputManager in InputManagers )
		{
			if(look == Vector2.zero) look = inputManager.GetLookVector();
			if(move == Vector2.zero) move = inputManager.GetMoveVector();
		}
		cameraController.Rotate(look);

		MovementController.Move(move, Camera.transform);
	}


	void LateUpdate ()
	{
		bool jump = false;
		foreach( IInputManager inputManager in InputManagers )
		{
			jump |= inputManager.ButtonIsPressed(Action.Jump);
		}
		if(jump)
		{
			PhysicsManager.Jump(JumpStrength);
		}
	}
}



