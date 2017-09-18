using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;

public abstract class StateMachineBehaviour<T> : ExposableMonoBehaviour {

	private enum SupportedStates
	{
		_Update,
		_EnterState,
		_ExitState
	}

	[ExposeProperty]
	public T state
	{
		get
		{
			return (T) _state;
		}
		set
		{
			if( _state.Equals( value )) return;

			_nextState = (T) value;
			_nextStateToString = _nextState.ToString();
			_stateIsDirty = true;
			UpdateMethodStrings();
			UpdateStates();
		}
	}

	[SerializeField] [HideInInspector]
	private T _state;
	private string _stateToString;
	private T _nextState;
	private string _nextStateToString;
	protected bool _stateIsDirty;

	private string _updateMethod, _exitStateMethod, _enterStateMethod;

	private Dictionary<string, Delegate> _methodList;

	private MethodInfo _allUpdate, _stateUpdate;

	private delegate void _stateMethod();


	void Awake()
	{
		_nextState = _state;
		_stateToString = state.ToString();
		_nextStateToString = _nextState.ToString();
		_methodList = new Dictionary<string, Delegate>();
		PopulateMethodDictionary();
		UpdateMethodStrings();


	}

	void Start ()
	{
		_stateToString = _state.ToString();
	}

	void Update ()
	{
		if( _methodList.ContainsKey( "All_Update" ) )
		{
			_methodList["All_Update"].Method.Invoke(this, null);
		}
		if( _methodList.ContainsKey( _updateMethod ) )
		{
			_methodList[_updateMethod].Method.Invoke(this, null);
		}
	}

	void UpdateStates()
	{
		if( _stateIsDirty )
		{
			if( Application.isPlaying )
			{
				if( _methodList.ContainsKey( "All_ExitState" ))
				{
					_methodList["All_ExitState"].Method.Invoke(this, null);
				}
				if(_methodList.ContainsKey(_exitStateMethod))
				{
					_methodList[_exitStateMethod].Method.Invoke(this, null);
				}
			}

			//#endif

			_exitStateMethod = _nextStateToString+"_ExitState";


			if( _nextState != null )
			{
				if( Application.isPlaying )
				{
					if( _methodList.ContainsKey( "All_EnterState" ))
					{
						_methodList["All_EnterState"].Method.Invoke(this, null);
					}
					if( _methodList.ContainsKey( _enterStateMethod ))
					{
						_methodList[_enterStateMethod].Method.Invoke(this, null);
					}
				}

				_state = _nextState;
				_stateToString = _nextStateToString;

				if( _methodList.ContainsKey( _updateMethod ) )
				{
					_stateUpdate = _methodList[_updateMethod].Method;
				}

				_nextState = default(T);
				_nextStateToString = "";
			}

			_stateIsDirty = false;
		}
	}

	void UpdateMethodStrings()
	{
		_exitStateMethod = _stateToString + "_ExitState";
		_enterStateMethod = _nextStateToString + "_EnterState";
		_updateMethod = _nextStateToString + "_Update";
	}

	protected void PopulateMethodDictionary()
	{
		if( typeof(T).IsEnum )
		{
			foreach( Enum eState in Enum.GetValues( typeof(T) ))
			{
				AddMethodForSupportedStates( eState.ToString() );
			}
			AddMethodForSupportedStates( "All" );
		}
	}

	protected void AddMethodForSupportedStates( string state )
	{
		string methodName = "";
		MethodInfo methodInfo = null;

		foreach( SupportedStates supState in Enum.GetValues( typeof( SupportedStates )))
		{
			methodName = state + supState.ToString();

			methodInfo = this.GetType().GetMethod( methodName );
			if( methodInfo != null )
			{
				_methodList.Add(methodName, Delegate.CreateDelegate(typeof(_stateMethod), this, methodInfo, true));
			}
		}
	}
}

