using UnityEngine;
using System.Collections;

public class charaterHealth : MonoBehaviour {

	GameObject healthGUI;


	// Use this for initialization
	void Start () 
	{
		healthGUI = GameObject.Find ("displayHealth");
	}
	
	// Update is called once per frame
	void Update () 
	{


	}


	void collision(Collision2D coll)
	{
		if (coll.gameObject.tag == "Enemy") 
		{

			healthGUI.GetComponent<healthController>().Health -= 1;
		}
	}
}
