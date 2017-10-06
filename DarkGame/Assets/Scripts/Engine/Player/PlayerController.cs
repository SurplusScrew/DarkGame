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
    public IInputManager[] inputManagers { get; set; }
	public IMovementController movementController{ get; set; }

	private ICameraController cameraController;

	public GameObject Player, Camera;

    void Awake()
	{
		inputManagers = GetComponents<IInputManager>();

		//Lazy loaded
		if(inputManagers.Length == 0) inputManagers = new IInputManager[]{ gameObject.AddComponent<MB_KeyboardInputManager>() };

		movementController = GetComponent<IMovementController>();

		//Lazy loaded
		if(movementController == null) movementController = gameObject.AddComponent<PlayerMovementController>();
		movementController.Player = Player;


		cameraController = GetComponentInChildren<ICameraController>();
		cameraController.Camera = Camera;

		cameraController.ChaseTarget(Player);
	}

	void FixedUpdate()
	{
		Vector2 look = Vector2.zero;
		Vector2 move = Vector2.zero;

		foreach( IInputManager inputManager in inputManagers )
		{
			if(look == Vector2.zero) look = inputManager.GetLookVector();
			if(move == Vector2.zero) move = inputManager.GetMoveVector();
		}
		cameraController.Rotate(look);
		movementController.Move(move, cameraController.GetForwardVector());
	}

	// Update is called once per frame
	void LateUpdate ()
	{
		bool jump = false;
		foreach( IInputManager inputManager in inputManagers )
		{
			jump |= inputManager.ButtonIsPressed(Action.Jump);
		}
		if(jump)
		{
			movementController.Jump(JumpStrength);
		}
	}
}



