using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour {


	public string playerName;
	public int playerStress;
	public List<bool> LifeLines;

	public GameObject Target;


	// Use this for initialization
	void Start () {
		Application.targetFrameRate = 60;
		PlayerPrefs.SetString ("Player_Name",playerName);	
		PlayerPrefs.SetInt ("Player_Stress", playerStress);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
