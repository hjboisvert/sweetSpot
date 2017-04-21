using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SConversationSystem : MonoBehaviour {

	public Image Converser;
	public Text NPCName;
	public Text ConverserBody;
	public Button AnswerA;
	public Button AnswerB;
	public Button AnswerC;
	public Button AnswerD;
	public Button End;

	public promptType pt;
	public enum promptType {

		NONE,
		TALK,
		TRIGGER,
		STRESS,
		AWARD
	}

	public GameObject Player;

	public void Prompt()
	{
		if(pt == promptType.TALK)
		{

		}
		else if(pt == promptType.TRIGGER)
		{

		}
		else if(pt == promptType.STRESS)
		{

		}
		else if(pt == promptType.AWARD)
		{

		}
	}
		

	// Use this for initialization
	void Start () {
		GetComponent<CanvasGroup> ().alpha = 0;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
