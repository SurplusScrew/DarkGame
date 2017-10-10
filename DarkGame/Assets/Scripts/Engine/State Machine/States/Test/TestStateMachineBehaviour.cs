using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum test
{
	t1,
	t2,
	t3
}
public class TestStateMachineBehaviour  : StateMachineBehaviour<test>
{

	public void t1_Update()
	{
		//Debug.Log(" in t1.");
	}

	public void t2_Update()
	{
		//Debug.Log(" in t2." );
	}
	public void t2_EnterState()
	{
		Debug.Log("enterState t2");
	}

	public void All_Update()
	{
		Debug.Log("IN ALL UPDATE");
		if( Input.GetKeyDown("h"))
		{
			state = test.t2;

		}
	}

	public void All_ExitState()
	{
		Debug.Log( "--- IN EXIT ALL ---" );
	}

	public void All_EnterState()
	{
		Debug.Log( "--- IN ENTER ALL ---" );
	}



}
