using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ObserverBehaviour<T> : MonoBehaviour 
{
	protected List<Observer<T>> _observers;
	protected Enum _state;
	
	public void AddObserver( Observer<T> observer )
	{
		_observers.Add( observer );
	}
	
	public void RemoveObserver( Observer<T> observer )
	{
		_observers.Remove( observer );
	}

	protected void NotifyObservers()
	{
		foreach( Observer<T> observer in _observers )
		{
			observer.StateChanged( this, _state );
		}
	}
}

public interface Observer<T>
{
	void StateChanged(ObserverBehaviour<T> t, Enum e);

}
