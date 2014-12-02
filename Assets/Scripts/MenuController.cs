using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	public bool isQuit = false;
	public bool isNG = false;
	public bool isLoadGame = false;
	public bool isCredits = false;
	// Use this for initialization
	void Start () {
	
	}

	void OnMouseEnter(){
		renderer.material.color = Color.red;
	}

	void OnMouseExit(){
		renderer.material.color = Color.white;
	}

	void OnMouseUp(){
		if (isQuit == true) {
			Application.Quit();
		}
		if (isNG == true) {
		//	Application.loadedLevel("butt");
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit();
		}
	}
}
