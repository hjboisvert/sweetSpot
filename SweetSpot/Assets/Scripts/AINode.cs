using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AINode : MonoBehaviour {

	public Collider Col;
	public Vector3 position;
	public bool Triggered;

	void OnTriggerEnter()
	{
		Triggered = true;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
