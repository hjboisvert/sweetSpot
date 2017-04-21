using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AINode : MonoBehaviour {

	public Collider Col;
	public promptType pt;
	public Vector3 position;
	public bool Triggered;

	[SerializeField]
	GameObject ConversationSystem;

	public enum promptType {
		
		NONE,
		TALK,
		UPSET,
		CALM
	}

	void OnTriggerEnter(Collider col)
	{
		GameObject.Find ("ConversationSystem").GetComponent<SConversationSystem>().Player = col.gameObject;//Player = col.collider.gameObject;
		ConversationSystem.GetComponent<SConversationSystem>().Player = col.gameObject;

		ConversationSystem.GetComponent<SConversationSystem> ().NPCName.text = gameObject.GetComponent<StoryElement> ().NPCName;
		ConversationSystem.GetComponent<SConversationSystem> ().Converser.sprite = gameObject.GetComponent<StoryElement> ().Portrait;
		ConversationSystem.GetComponent<SConversationSystem> ().ConverserBody.text = gameObject.GetComponent<StoryElement> ().DialogueBoxes [0].TextBody;

		ConversationSystem.GetComponent<SConversationSystem> ().AnswerA.GetComponentInChildren<Text>().text = gameObject.GetComponent<StoryElement> ().DialogueBoxes [0].TextBody;
		ConversationSystem.GetComponent<SConversationSystem> ().AnswerB.GetComponentInChildren<Text>().text = gameObject.GetComponent<StoryElement> ().DialogueBoxes [1].TextBody;
		ConversationSystem.GetComponent<SConversationSystem> ().AnswerC.GetComponentInChildren<Text>().text = gameObject.GetComponent<StoryElement> ().DialogueBoxes [0].TextBody;
		ConversationSystem.GetComponent<SConversationSystem> ().AnswerD.GetComponentInChildren<Text>().text = gameObject.GetComponent<StoryElement> ().DialogueBoxes [1].TextBody;

		for (int x = 0; x < gameObject.GetComponent<StoryElement> ().DialogueBoxes.Count; x++) {

			Debug.Log (gameObject.GetComponent<StoryElement> ().DialogueBoxes [x].CID);
			Debug.Log (gameObject.GetComponent<StoryElement> ().DialogueBoxes [x].TextBody);

			if(col.gameObject.GetComponent<StoryElement>().NPCName == gameObject.GetComponent<StoryElement> ().DialogueBoxes[x].CID)
			{
				ConversationSystem.GetComponent<SConversationSystem> ().AnswerA.GetComponentInChildren<Text>().text = gameObject.GetComponent<StoryElement> ().DialogueBoxes [x].TextBody;
				ConversationSystem.GetComponent<SConversationSystem> ().AnswerB.GetComponentInChildren<Text>().text = gameObject.GetComponent<StoryElement> ().DialogueBoxes [x].TextBody;
				ConversationSystem.GetComponent<SConversationSystem> ().AnswerC.GetComponentInChildren<Text>().text = gameObject.GetComponent<StoryElement> ().DialogueBoxes [x].TextBody;
				ConversationSystem.GetComponent<SConversationSystem> ().AnswerD.GetComponentInChildren<Text>().text = gameObject.GetComponent<StoryElement> ().DialogueBoxes [x].TextBody;

			}
		}
	}

	void OnTriggerStay(Collider col)
	{
		ConversationSystem.GetComponent<CanvasGroup> ().alpha = 1;
		col.GetComponent<AI>().Active = false;
	}

	public void LoadConversation(DStoryElement DS)
	{
		ConversationSystem.GetComponent<SConversationSystem>().NPCName.text = DS.NPCName;
		ConversationSystem.GetComponent<SConversationSystem>().ConverserBody.text = DS.DialogueBoxes[0].TextBody;
		ConversationSystem.GetComponent<SConversationSystem>().Converser.sprite = Resources.Load<Sprite> (DS.Portrait);
	}

	void OnMouseButtonDown()
	{
		Debug.Log ("AINode " + gameObject.name);
	}

	void OnCollisionEnter(Collision C)
	{
		Triggered = true;
	}

	/*void OnCollisionStay(Collision C)
	{
		if (Triggered) {
			if (gameObject.GetComponent<AINode> ().pt == promptType.TALK) {
				ConversationSystem.GetComponent<CanvasGroup> ().alpha = 1;
				Debug.Log ("I'm Here");
			}
		}

	}*/

	// Use this for initialization
	void Start () {
		Col = gameObject.GetComponent<Collider> ();
		position = gameObject.transform.position;
		Debug.Log (ConversationSystem.name);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
	}
}
