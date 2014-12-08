using UnityEngine;
using System.Collections;

public class shop : MonoBehaviour {

	public bool hasItem1 = false;
	public bool hasItem2 = false;
	public bool hasItem3 = false;
	public bool hasItem4 = false;
	public bool item1Box = false;
	public bool item2Box = false;
	public bool item3Box = false;
	public bool item4Box = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseEnter(){
		renderer.material.color = Color.red;
	}
	
	void OnMouseExit(){
		renderer.material.color = Color.white;
	}

	void OnMouseUp(){
		if (item1Box == true) {
			//renderer.material.color = color.black;
			//GUI.Box(Rect(0,0,Screen.width, Screen.height), "Got it");
		}
		if (item2Box == true) {
			//renderer.material.color = color.black;
		}
		if (item3Box == true) {
			//renderer.material.color = color.black;
		}
		if (item4Box == true) {
			//renderer.material.color = color.black;
		}
	}
}
