using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("StoryElementContainer")]
public class StoryElementContainer
{	
	[XmlIgnore]
	public string LoadPath;
	[XmlArray("StoryElement"), XmlArrayItem("Element")]
	public List<DStoryElement> DSE;

	//public StoryElement SE;
	protected bool ConvoTriggered;

	public static StoryElementContainer Load(string path)
	{
		var xml = new XmlSerializer (typeof(StoryElementContainer));
		using (var file = new FileStream (path, FileMode.Open)) {
			return xml.Deserialize (file) as StoryElementContainer;
		}
	}
}