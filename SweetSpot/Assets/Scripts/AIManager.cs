using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AIManager : MonoBehaviour {

	private int currentActorIndex;
	public Dictionary<string, UnityEvent> eventDictionary;

	public bool move;
	public bool mv;
	public float speed;
	public float rotationSpeed;
	public float zoomSpeed;

	public string cAI
	{
		get{
			return PresentActors[currentActorIndex].name;
		}

		set{
			PresentActors[currentActorIndex].name = value; 
		}
	}

	[Header("Toggle Debug Mode")]
	public bool debugMode;

	[Header("Force Turn off")]
	public bool DeadSwitch;

	[Header("All In Scene Actors")]
	public List<AI> PresentActors;


	public delegate void SaveHandler(string sender, UnityEvent e);
	public event SaveHandler OnSave;


	public void Start()
	{
		eventDictionary = new Dictionary<string,UnityEvent> (10);
		OnSave += MySaveFunction;
	}

	public void OnDestroy()
	{
		OnSave -= MySaveFunction;
	}
		
	public void MySaveFunction(string sender, UnityEvent e)
	{
		Debug.Log (sender);
		eventDictionary.Add (sender, e);
		Debug.Log (eventDictionary.ContainsKey (sender));

		//foreach (string ky in eventDictionary.Keys) {
		//	Debug.Log (ky);
		//}
	}

		/*Debug.Log("Clicked");
		if (gameObject.tag == "whatever")
		{
			Debug.Log("Tag is equal to: " + gameObject.tag);
		}*/
	
	// Update is called once per frame
	void Update () {
		/*if(Input.GetKeyDown(KeyCode.LeftShift) && Input.GetMouseButtonDown (1))
		{
			gameObject.transform.position = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
		}
		if(Input.GetButtonDown("Horizontal"))
		{
			gameObject.transform.position = new Vector3 (gameObject.transform.position.x + 5, gameObject.transform.position.y, gameObject.transform.position.z);
		}
		else if(Input.GetButtonDown("Horizontal"))
		{
			gameObject.transform.position = new Vector3 (gameObject.transform.position.x - 5, gameObject.transform.position.y, gameObject.transform.position.z);
		}
		else if(Input.GetButtonDown("Vertical"))
		{
			gameObject.transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y + 5, gameObject.transform.position.z);
		}
		else if(Input.GetButtonDown("Vertical"))
		{
			gameObject.transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y - 5, gameObject.transform.position.z);
		}*/

		if ( Input.GetMouseButtonDown (0)){ 
			RaycastHit hit; 
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
			if (Physics.Raycast (ray,out hit)) {
				OnSave += MySaveFunction; 
				if (hit.collider.GetComponent<AI> ()) {
					hit.collider.GetComponent<AI> ().Acknowledged = true;
				}

				Debug.Log(hit.transform.name + " Acknowledged!");
				gameObject.GetComponent<PlayerCharacter> ().Target = hit.collider.gameObject;
				Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object

				if (hit.collider.GetComponent<AINode> ()) {
					transform.position = Vector3.MoveTowards(transform.position, gameObject.GetComponent<PlayerCharacter> ().Target.transform.position, 25.0f);
					hit.collider.GetComponent<AI> ().Acknowledged = true;
				}

			}
		}

		if (Input.GetMouseButtonDown (1)) { 
			move = !move;
		}

		if (Input.GetMouseButtonDown (2)) {
			mv = !mv; 
		}
			
		if(move){
			Camera mycam = GetComponent<Camera>();
			transform.LookAt(mycam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mycam.nearClipPlane)), Vector3.up);
			/*
			float translation = Input.GetAxis ("Mouse ScrollWheel") * speed;
			float rotation = Input.GetAxis ("Mouse X") * rotationSpeed;

			translation *= Time.deltaTime;
			rotation *= Time.deltaTime;
			transform.Translate (0, translation, 0);
			transform.Rotate (0, rotation, 0);
			//transform.RotateAround (transform.position, gameObject.GetComponent<PlayerCharacter> ().Target.transform.position, 90.0f);*/
		}

		if (mv) {
			float rotationB = Input.GetAxis ("Mouse Y") * zoomSpeed;
			transform.Translate (0, 0, rotationB);
		}
	}
}
