using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	public bool isQuit = false;
	public bool isNG = false;
	public bool isLoadGame = false;
	public bool isCredits = false;
	public bool isMainMenu = false;
	public bool isMenuBox = false;
	public bool isPauseObj = false;
	public bool showPause = false;
	public bool isTestShop = false;
	public int state = 0; //Game state control, 0 - main menu, 1 - level1, 2 - level2, 3 - level3, 4 - level4, 5 - credit screen, 6 - death screen, 7 - store
	public bool isPaused = false;
	//public GUIStyle textScale;
	//public GameObject NGText = GameObject.Find("New Game");
	// Use this for initialization
	void Start () {
	}

	void OnMouseEnter(){
		renderer.material.color = Color.red;
	}

	void OnMouseExit(){
		renderer.material.color = Color.black;
	}

	void OnMouseUp(){
		if (isQuit == true) {
			Application.Quit();
		}
		if (isNG == true) {

			Application.LoadLevel("level1");
		}
		if (isCredits == true) {

			Application.LoadLevel("credits");
		}
		if (isMainMenu == true) {

			Application.LoadLevel("mainMenu");
		}
		if (isTestShop == true) {
			Application.LoadLevel("shop");
		}

	}
	
	// Update is called once per frame
	void Update () {
		state = Application.loadedLevel;
		//print (state);
		if (state == 0) {
			if (Input.GetKeyDown (KeyCode.Escape)) {
				Application.Quit ();
			}
		}
		if (state == 1) {
			if (Input.GetKeyUp (KeyCode.Escape)) {
				//if(isPaused == false){
					pauseMenu();
				//}
			}
		}
	}

	void pauseMenu(){
		if (isPaused == false) {
			print (isPaused);
			Time.timeScale = 0;
			Time.fixedDeltaTime = 0;
			//GameObject.Find("Main Camera").GetComponent(MouseLook).enabled = false;
			//GameObject.Find("First Person Controller").GetComponent(MouseLook).enabled = false;
			showPause = true;
			GameObject.Find ("pauseObject").guiText.enabled = true;
			print (isPaused);
			if (Input.GetKeyDown ("p")) {
				//backtoGame();
				isPaused = true;
				print("Working");
			}
		}
		if (isPaused == true) {
			Time.timeScale = 1;
			Time.fixedDeltaTime = 1;
			//GameObject.Find("Main Camera").GetComponent(MouseLook).enabled = true;
			//GameObject.Find("First Person Controller").GetComponent(MouseLook).enabled = true;
			showPause = false;
			GameObject.Find("pauseObject").guiText.enabled = false;
			isPaused = false;
		}
	}
}
