using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

public class StoryElementManager : MonoBehaviour
{	
	public string LoadPath;
	public StoryElementContainer ST;
	public List<GameObject> SceneCharacters;
	public bool DebugMode;


	//Debug use only
	void LoadFromText(string path)
	{

	}
	//debug
	void Awake()
	{
		if (DebugMode) {
			Debug.Log (LoadPath);
		}

		ST = StoryElementContainer.Load (LoadPath);
	}

	void Start()
	{
		if (DebugMode) {
			Debug.Log (ST.DSE [0].CID);
			Debug.Log (ST.DSE [0].NPCName);
			Debug.Log (ST.DSE [0].Portrait);
		}
		for(int x = 0; x < SceneCharacters.Count; x++)
		{
			AutoAssign (SceneCharacters [x].name);
		}

		//gameObject.GetComponent<StoryElement> ().NPCName = ST.DSE [0].NPCName;
		//gameObject.GetComponent<StoryElement> ().Portrait = Resources.Load<Texture> (ST.DSE [0].Portrait);
		//gameObject.GetComponent<StoryElement>().DialogueBoxes = new List<DStoryDialogue>(ST.DSE [0].DialogueBoxes);

		ManualAssign (SceneCharacters [0], SceneCharacters [0].name);
		if (DebugMode) {
			for (int x = 0; x < ST.DSE [0].DialogueBoxes.Count; x++) {
				Debug.Log ("SID: " + ST.DSE [0].DialogueBoxes [x].SID);
				Debug.Log ("Text: " + ST.DSE [0].DialogueBoxes [x].TextBody); 
			}
		}
	}

	public StoryElement Convert(int index)
	{
		StoryElement SR = new StoryElement ();
		SR.NPCName = ST.DSE [index].NPCName;
		SR.Portrait = Resources.Load<Texture>(ST.DSE [index].Portrait);
		for(int x = 0; x < ST.DSE [index].DialogueBoxes.Count; x++)
		{
			SR.DialogueBoxes[x] = ST.DSE [index].DialogueBoxes[x];
		}
		return SR;
	}

	public void ElementAssign(string ElementID)
	{
		foreach (DStoryElement DS in ST.DSE) {
			if(DS.NPCName == ElementID){
				GameObject.Find (ElementID).GetComponent<StoryElement>().Load(DS);
			}
		}
	}

	public void AutoAssign(string npc)
	{
		foreach (DStoryElement DS in ST.DSE) {
			if(DS.NPCName == npc){
				GameObject.Find (npc).GetComponent<StoryElement>().Load(DS);
				GameObject.Find (npc).GetComponent<MeshRenderer> ().material = new Material (Shader.Find ("Diffuse"));
				GameObject.Find (npc).GetComponent<MeshRenderer> ().material.mainTexture = Resources.Load<Texture> (ST.DSE [0].Portrait);
			}
		}
	}

	public void ManualAssign(GameObject obj, string NPC_ID)
	{
		foreach (DStoryElement DS in ST.DSE) {
			if(DS.NPCName == NPC_ID){
				obj.GetComponent<StoryElement> ().Load (DS);
				obj.GetComponent<MeshRenderer> ().material = new Material (Shader.Find ("Diffuse"));
				obj.GetComponent<MeshRenderer> ().material.mainTexture = Resources.Load<Texture> (ST.DSE [0].Portrait);
			}
		}
	}
}