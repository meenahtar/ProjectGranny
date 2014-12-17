using UnityEngine;
using System.Collections;

public class Meatball : MonoBehaviour {
	
	GameObject LunchLady;
	bool facingRight;
	
	// Use this for initialization
	void Start () {
		LunchLady = GameObject.Find ("LunchLady");
		facingRight = LunchLady.GetComponent<LunchLady> ().facingRight;
	}
	
	// Update is called once per frame
	void Update () {
		if (facingRight == true) 
		{
			transform.position = new Vector3 (transform.position.x + .15f, transform.position.y, transform.position.z);
		} 
		else
		{
			transform.position = new Vector3 (transform.position.x - .15f, transform.position.y - .03f, transform.position.z);
			if(transform.position.y <= -0.7)
			{
				Instantiate(Resources.Load("MeatMinion"), new Vector3(transform.position.x, 1.041055f, transform.position.z), Quaternion.identity);
				gameObject.SetActive(false);
			}
		}
	}
}
