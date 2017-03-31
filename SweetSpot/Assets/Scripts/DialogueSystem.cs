using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSystem : MonoBehaviour {

	public PlayerCharacter PC;
	public AI NPC;
	public ConversationPhase CP;

	public enum ConversationPhase
	{
		PLAYER_TALKING,
		NPC_TALKING
	}

	public void PlayerChoice()
	{

	}

	public void NPCChoice()
	{

	}

	public void ChoiceMade()
	{
		if(CP == ConversationPhase.NPC_TALKING)
		{
			CP = ConversationPhase.PLAYER_TALKING;
		}
		else{
			CP = ConversationPhase.NPC_TALKING;
		}
	}
		
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
