using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryDialogue : MonoBehaviour {

	public string CID;
	public string SID;
	public string TextBody;
	public DStoryDialogue DS9;
		
	public StoryDialogue()
	{
		
	}

	public StoryDialogue(DStoryDialogue DS)
	{
		DS.CID = CID;
		DS.SID = SID;
		DS.TextBody = TextBody;
	}

}
