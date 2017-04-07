using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StoryElement : MonoBehaviour
{
	protected bool ConvoTriggered;
	//[SerializeField]
	public GameObject Template;

	public string DialogueTemplate;
	public string NPCName;
	public Texture Portrait;
	public List<StoryDialogue> DialogueBoxes;

	void Awake()
	{
		
	}

	void Start()
	{
		
		//DialogueBoxes = new List<StoryDialogue> ();
	}

	void Update()
	{

	}

	public StoryElement()
	{

	}

	public void Load(DStoryElement DS)
	{
		NPCName = DS.NPCName;
		Portrait = Resources.Load<Texture> (DS.Portrait);
		 //GameObject.Find (DialogueTemplate);

		for(int s = 0; s < DS.DialogueBoxes.Count; s++)
		{
			GameObject DSX = Instantiate(Resources.Load("TemplateDialogue")) as GameObject;
			DSX.name = DS.DialogueBoxes[s].SID;
			DSX.GetComponent<StoryDialogue> ().DS9 = DS.DialogueBoxes [s];
			DSX.GetComponent<StoryDialogue>().SID = DSX.GetComponent<StoryDialogue>().DS9.SID;
			DSX.GetComponent<StoryDialogue>().TextBody = DSX.GetComponent<StoryDialogue>().DS9.TextBody;//DS.DialogueBoxes [s].TextBody;
			DialogueBoxes.Add (DSX.GetComponent<StoryDialogue>());
			DSX.transform.parent = gameObject.transform;
		}
	}
}