using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryDialogue : MonoBehaviour {

	public string SID;
	public string TextBody;
		
	public StoryDialogue()
	{
		
	}

	public StoryDialogue(DStoryDialogue DS)
	{
		DS.SID = SID;
		DS.TextBody = TextBody;
	}

}
