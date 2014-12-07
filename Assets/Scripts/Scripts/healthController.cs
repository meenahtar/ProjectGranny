using UnityEngine;
using System.Collections;

public class healthController : MonoBehaviour {

	public int Health = 100;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		guiText.text = "Health - " + Health;
	}

	public void controlHealth(int damage){
		//GUIText.text = ("Health - " + health);
		//healthGUI = GameObject.Find ("displayHealth").GUIText;
		Health = Health - damage;

	}

	public void takeDamage(int toTake)
	{
		Health = Health - toTake;
	}
}
