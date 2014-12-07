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

	void OnCollisionEnter(Collision coll)
	{
		//if (coll.gameObject.tag == "Enemy") 
		//{
			//transform.position.y += 1;
			healthGUI.GetComponent<healthController>().takeDamage(1);
		//}
	}
}
