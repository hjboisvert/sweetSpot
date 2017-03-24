using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StoryElement : MonoBehaviour
{
	protected bool ConvoTriggered;
	public string NPCName;
	public Texture Portrait;
	public List<DStoryDialogue> DialogueBoxes;


	public StoryElement()
	{

	}

	public void Load(DStoryElement DS)
	{
		NPCName = DS.NPCName;
		Portrait = Resources.Load<Texture>(DS.Portrait);
		DialogueBoxes = new List<DStoryDialogue> (DS.DialogueBoxes);
	}

	void Start()
	{

	}

	void Update()
	{

	}

}