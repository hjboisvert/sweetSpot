using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AIEventTest : MonoBehaviour {

	private UnityAction someListener;

	void Awake ()
	{
		someListener = new UnityAction (SomeFunction);
	}

	void OnEnable ()
	{
		AIEventManager.StartListening ("test", someListener);
		AIEventManager.StartListening ("Spawn", SomeOtherFunction);
		AIEventManager.StartListening ("Destroy", SomeThirdFunction);
	}

	void OnDisable ()
	{
		AIEventManager.StopListening ("test", someListener);
		AIEventManager.StopListening ("Spawn", SomeOtherFunction);
		AIEventManager.StopListening ("Destroy", SomeThirdFunction);
	}

	void SomeFunction ()
	{
		Debug.Log ("Some Function was called!");
	}

	void SomeOtherFunction ()
	{
		Debug.Log ("Some Other Function was called!");
	}

	void SomeThirdFunction ()
	{
		Debug.Log ("Some Third Function was called!");
	}
}
