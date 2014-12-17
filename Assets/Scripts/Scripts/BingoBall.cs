using UnityEngine;
using System.Collections;

public class BingoBall : MonoBehaviour {

	GameObject Granny;

	// Use this for initialization
	void Start () {
		Granny = GameObject.Find ("First Person Controller");
	}
	
	// Update is called once per frame
	void Update () {
		checkCollisions ();
	}

	void checkCollisions()
	{
		if ((Granny.transform.position.x > transform.position.x - 0.25f) && (Granny.transform.position.x < transform.position.x + 0.25f)) 
		{
			PlayerPrefs.SetInt ("bingoBalls", PlayerPrefs.GetInt ("bingoBalls") + 10);
			print (PlayerPrefs.GetInt ("bingoBalls"));
			gameObject.SetActive (false);
		}
	}

	/*
	void OnCollisionEnter(Collision coll)
	{
		if (coll.gameObject.CompareTag ("Granny")) 
		{
			PlayerPrefs.SetInt ("bingoBalls", PlayerPrefs.GetInt ("bingoBalls") + 10);
			print (PlayerPrefs.GetInt ("bingoBalls"));
			gameObject.SetActive (false);
		}
	}
	*/
}
