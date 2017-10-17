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

	public ICharacterPhysicsManager PhysicsManager{get;set;}

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

		PhysicsManager = GetComponent<ICharacterPhysicsManager>();
		if(PhysicsManager == null) PhysicsManager = Player.AddComponent<MB_PlayerPhysicsManager>();
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

		PhysicsManager.SetVelocity(
			MovementController.Move(
				move,
				Camera.transform,
				PhysicsManager.GetVelocity()
				)
			);

		Player.transform.rotation = MovementController.Rotate(Camera.transform, PhysicsManager.GetVelocity().magnitude);
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
			Debug.Log("Jumping");
			PhysicsManager.Jump(JumpStrength);
		}
	}
}



