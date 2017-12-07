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

	public InputController ButtonInputController{get;set;}
	public IMovementController MovementController{ get; set; }

	public ICharacterPhysicsManager PhysicsManager{get;set;}

	private ICameraController cameraController;

	public GameObject Player, Camera;

    void Awake()
	{
		InitializeInputs();
		InitializeMovementController();
		InitializeCameraController();
		InitializePhysicsManager();
		RegisterCommandDelegates();
	}

	void InitializeInputs()
	{
		//Lazy loaded
		IInputManager[] InputManagers = GetComponents<IInputManager>();
		if(InputManagers.Length == 0)
		{
			InputManagers = new IInputManager[]{ gameObject.AddComponent<MB_KeyboardInputManager>() };
		}

		ActionMap ActionMap = GetComponent<MB_ActionMapWrapper>().ActionMap;

		ButtonInputController = new InputController(ActionMap,  InputManagers);
	}

	void InitializeMovementController()
	{
		//Lazy loaded
		MovementController = GetComponent<IMovementController>();
		if(MovementController == null)
		{
			MovementController = Player.AddComponent<MB_PlayerMovementController>();
		}
	}

	void InitializeCameraController()
	{
		cameraController = GetComponentInChildren<ICameraController>();
		cameraController.Camera = Camera;
		cameraController.ChaseTarget(Player);
	}

	void InitializePhysicsManager()
	{
		PhysicsManager = Player.GetComponent<ICharacterPhysicsManager>();
		if(PhysicsManager == null)
		{
			PhysicsManager = Player.AddComponent<MB_PlayerPhysicsManager>();
		}
	}

	void RegisterCommandDelegates()
	{
		ButtonInputController.RegisterButtonDelegate(Action.Jump, this.Jump);
		ButtonInputController.RegisterButtonDelegate(Action.Climb, this.Climb);
		Debug.Log("Delegates registered");
	}
	void FixedUpdate()
	{
		ButtonInputController.FixedTick();

		UpdatePlayer();
	}

	void LateUpdate ()
	{
		ButtonInputController.LateTick();
	}

	void UpdatePlayer()
	{
		PhysicsManager.SetVelocity(
			MovementController.Move(
				ButtonInputController.MoveVector,
				Camera.transform,
				PhysicsManager.GetVelocity()
				)
			);

		cameraController.Rotate(ButtonInputController.LookVector);

		Player.transform.rotation = MovementController.Rotate(
			Camera.transform,
			PhysicsManager.GetVelocity().magnitude
		);
	}
	public void Jump()
	{
		PhysicsManager.Jump(JumpStrength);
	}
	public void Climb()
	{
		Debug.LogWarning("-- Climb -- Not yet implemented!");
	}

}



