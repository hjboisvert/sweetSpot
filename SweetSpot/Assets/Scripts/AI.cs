using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AI : MonoBehaviour {

	public bool Active;
	public bool Acknowledged;
	public float speed;
	public List<AINode> Destinations;
	public AIStates CurrentState;


	public enum AIStates
	{
		OFF,
		STILL,
		MOVING,
		RUN,
		SIT,
		SPEAKING,
	}
		
	void Awake()
	{
		if (Active) {

			CurrentState = AIStates.STILL;
		}
	}

	public void MoveTo(Vector3 start, Vector3 target)
	{
		if(start.x >= target.x)
		{
			transform.position = transform.position;
		}

		CurrentState = AIStates.MOVING;
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
		if(CurrentState == AIStates.OFF)
		{
			CurrentState = AIStates.STILL;
		}
		else if(CurrentState == AIStates.STILL)
		{
			CurrentState = AIStates.MOVING;
		}
		else if(CurrentState == AIStates.MOVING)
		{
			CurrentState = AIStates.RUN;
		}
		else if(CurrentState == AIStates.RUN)
		{
			CurrentState = AIStates.SIT;
		}
		else if(CurrentState == AIStates.SIT)
		{
			CurrentState = AIStates.SPEAKING;
		}
		else if(CurrentState == AIStates.SPEAKING)
		{
			CurrentState = AIStates.OFF;
		}
	}
	
	// Update is called once per frame
	void Start() {
		
	}

	void Update(){
		MoveTo (gameObject.transform.position, Destinations[0].position);
	}
		
	void DrawLine(Vector3 start, Vector3 end, Color color, float duration = 0.2f)
	{	
		bool str = true;
		GameObject myLine = new GameObject();
		myLine.transform.position = start;
		myLine.AddComponent<LineRenderer>();
		LineRenderer lr = myLine.GetComponent<LineRenderer>();
		lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
		lr.SetColors(color, color);
		lr.SetWidth(0.1f, 0.1f);
		lr.SetPosition(0, start);
		lr.SetPosition(1, end);
		lr.tag = "AIPath";
		GameObject.Destroy(myLine, duration);
	}
}
