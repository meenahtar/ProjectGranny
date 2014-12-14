using UnityEngine;
using System.Collections;

public class deathScreen : MonoBehaviour {

	public bool isMainMenu = false;
	public bool isContinue = false;
	public bool isQuit = false;
	public bool isShop = false;
	public string lastLevel = "";

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
		if (isQuit == true) {
			Application.Quit();
		}
		if (isContinue == true) {
			Application.LoadLevel(PlayerPrefs.GetInt("lastLevel"));
		}
		if (isMainMenu == true) {
			Application.LoadLevel("mainMenu");
		}
		if (isShop == true) {
			Application.LoadLevel("shop");
		}
		
	}
}
