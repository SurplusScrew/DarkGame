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
    public IInputManager inputManager { get; set; }
	public IMovementController movementController{ get; set; }

	private ICameraController cameraController;

	public GameObject Player, Camera;

    void Awake()
	{
		inputManager = GetComponent<IInputManager>();

		//Lazy loaded
		if(inputManager == null) inputManager = gameObject.AddComponent<MB_InControlInputManager>();

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
		cameraController.Rotate(inputManager.GetLookVector());
		movementController.Move(inputManager.GetMoveVector(), cameraController.GetForwardVector());
	}

	// Update is called once per frame
	void LateUpdate ()
	{
		if(inputManager.ButtonIsPressed(Action.Jump))
		{
			movementController.Jump(JumpStrength);
		}
	}
}



