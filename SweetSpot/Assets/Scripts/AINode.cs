using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AINode : MonoBehaviour {

	public Collider Col;
	public Vector3 position;
	public bool Triggered;

	void OnMouseButtonDown()
	{
		Debug.Log ("AINode " + gameObject.name);
	}

	void OnTriggerEnter()
	{
		Triggered = true;
	}

	// Use this for initialization
	void Start () {
		Col = gameObject.GetComponent<Collider> ();
		position = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
