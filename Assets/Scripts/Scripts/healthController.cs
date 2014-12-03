using UnityEngine;
using System.Collections;

public class healthController : MonoBehaviour {

	public int Health = 100;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		controlHealth ();
	}

	void controlHealth(){
		//GUIText.text = ("Health - " + health);
		//healthGUI = GameObject.Find ("displayHealth").GUIText;
		guiText.text = "Health - " + Health;
	}

	public void takeDamage(int toTake)
	{
		Health = Health - toTake;
	}
}
