using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AI : MonoBehaviour {

	public bool Active;
	public float speed;
	public List<AINode> Destinations;
	public Dictionary<string, UnityEvent> eventDictionary;
	public AIStates AIS;


	public enum AIStates
	{
		OFF,
		STILL,
		MOVING,
		RUN,
		SIT,
		SPEAKING,
	}

	public delegate void SaveHandler(string sender, UnityEvent e);
	public event SaveHandler OnSave;



	void Awake()
	{
		if (Active) {

			AIS = AIStates.STILL;
		}
	}

	public void Start()
	{
		eventDictionary = new Dictionary<string,UnityEvent> (10);
		//MySaveFunction ();
		OnSave += MySaveFunction;
	}

	public void OnDestroy()
	{
		OnSave -= MySaveFunction;
	}

	public void MySaveFunction(string sender, UnityEvent e)
	{
		Debug.Log (sender);
		eventDictionary.Add (sender, e);
		//Save this sword in the list of objects that should be spawned when level is loaded
	}

	public void MoveTo(Vector3 start, Vector3 target)
	{
		AIS = AIStates.MOVING;
		DrawLine (start, target, new Color (255, 0, 0));
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(start, target, step);
	}

	public void TravelPath(AINode pathNode, bool tillTerminate)
	{
		MoveTo (gameObject.transform.position, pathNode.position);
	}

	public void Assert()
	{
		if(AIS == AIStates.OFF)
		{

		}
		else if(AIS == AIStates.STILL)
		{

		}
		else if(AIS == AIStates.MOVING)
		{

		}
		else if(AIS == AIStates.RUN)
		{

		}
		else if(AIS == AIStates.SIT)
		{

		}
		else if(AIS == AIStates.SPEAKING)
		{

		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	void DrawLine(Vector3 start, Vector3 end, Color color, float duration = 0.2f)
	{
		GameObject myLine = new GameObject();
		myLine.transform.position = start;
		myLine.AddComponent<LineRenderer>();
		LineRenderer lr = myLine.GetComponent<LineRenderer>();
		lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
		lr.SetColors(color, color);
		lr.SetWidth(0.1f, 0.1f);
		lr.SetPosition(0, start);
		lr.SetPosition(1, end);
		GameObject.Destroy(myLine, duration);
	}
}
