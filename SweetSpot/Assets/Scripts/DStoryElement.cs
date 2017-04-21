using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

public class DStoryElement
{
	[XmlAttribute("ElementID")]
	public string EID;
	[XmlElement("NPCName")]
	public string NPCName;
	[XmlArray("NPCDialogueBoxes"), XmlArrayItem("DialogueBox")]
	public List<DStoryDialogue> DialogueBoxes;
	[XmlArray("NPCDialogSound"), XmlArrayItem("SoundBox")]
	public List<DStoryDialogue> SoundBoxes;
	[XmlElement("NPCPortrait")]
	public string Portrait;
}