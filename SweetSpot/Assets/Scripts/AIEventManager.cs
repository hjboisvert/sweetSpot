using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class AIEventManager : MonoBehaviour {

	public static Dictionary <string, UnityEvent> eventDictionary;
	private static AIEventManager eventManager;

	public static AIEventManager instance
	{
		get
		{
			if (!eventManager)
			{
				eventManager = GameObject.Find ("p3").GetComponent<AIEventManager>();//FindObjectOfType (typeof (AIEventManager)) as AIEventManager;

				if (!eventManager)
				{
					Debug.LogError ("There needs to be one active EventManger script on a GameObject in your scene.");
				}
			}

			return eventManager;
		}
	}

	public enum EventArgs
	{

	}
		

	void Awake ()
	{
		eventDictionary = new Dictionary<string, UnityEvent>();
	}

	void Start()
	{
		//UnityEvent UE = new UnityEvent ();
		//eventDictionary.Add ("Hello", UE);
		//Debug.Log (eventDictionary["Hello"].GetPersistentMethodName(0));
	}

	public static void StartListening (string eventName, UnityAction listener)
	{
		UnityEvent thisEvent = null;
		eventDictionary = new Dictionary<string, UnityEvent>();
		//if (instance.eventDictionary.TryGetValue (eventName, out thisEvent))
		//{
			//thisEvent.AddListener (listener);
		//} 
		//else
		//{
			thisEvent = new UnityEvent ();
			thisEvent.AddListener (listener);
			eventDictionary.Add (eventName, thisEvent);
		//}
	}

	public static void StopListening (string eventName, UnityAction listener)
	{
		if (eventManager == null) return;
		UnityEvent thisEvent = null;
		if (eventDictionary.TryGetValue (eventName, out thisEvent))
		{
			thisEvent.RemoveListener (listener);
		}
	}

	public static void TriggerEvent (string eventName)
	{
		UnityEvent thisEvent = null;
		if (eventDictionary.TryGetValue (eventName, out thisEvent))
		{
			thisEvent.Invoke ();
		}
	}
}
