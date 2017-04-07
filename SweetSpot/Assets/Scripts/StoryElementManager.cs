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

	void Start()
	{
		ST = StoryElementContainer.Load (LoadPath);
		if (DebugMode) {
			Debug.Log (LoadPath);
			Debug.Log (ST.DSE [0].CID);
			Debug.Log (ST.DSE [0].NPCName);
			Debug.Log (ST.DSE [0].Portrait);
		}

		for(int x = 0; x < SceneCharacters.Count; x++)
		{
			AutoAssign (SceneCharacters [x].name);
		}
	}

	public StoryElement Convert(int index)
	{
		StoryElement SR = new StoryElement ();
		SR.NPCName = ST.DSE [index].NPCName;
		SR.Portrait = Resources.Load<Texture>(ST.DSE [index].Portrait);
		for(int x = 0; x < ST.DSE [index].DialogueBoxes.Count; x++)
		{
			SR.DialogueBoxes[x] = new StoryDialogue(ST.DSE [index].DialogueBoxes[x]);
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
		GameObject GB = GameObject.Find (npc);

		foreach (DStoryElement DS in ST.DSE) {
			if(DS.NPCName == npc){
				GB.GetComponent<StoryElement>().Load(DS);
				GB.GetComponent<MeshRenderer> ().material = new Material (Shader.Find ("Diffuse"));
				GB.GetComponent<MeshRenderer> ().material.mainTexture = Resources.Load<Texture> (ST.DSE [0].Portrait);
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