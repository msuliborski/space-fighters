using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Variable<T> : ScriptableObject 
{
	[SerializeField] private T _value;

	public T Value 
	{ 
		get
		{
			return _value;
		} 
		set
		{
			_value = value;
			ValueChangedEvent.Invoke();
		} 
	}

    public UnityEvent ValueChangedEvent;
}

[CreateAssetMenu]
public class IntVariable : Variable<int>{

}
