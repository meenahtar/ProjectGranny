using UnityEngine;
using System.Collections;

public class Meatball : MonoBehaviour {
	
	GameObject LunchLady;
	bool facingRight;
	public bool spawnMonster;
	public float x;
	public float y;
	
	// Use this for initialization
	void Start () {
		LunchLady = GameObject.Find ("LunchLady");
		facingRight = LunchLady.GetComponent<LunchLady> ().facingRight;
		spawnMonster = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (facingRight == true) 
		{
			transform.position = new Vector3 (transform.position.x + .15f, transform.position.y, transform.position.z);
		} 
		else
		{
			transform.position = new Vector3 (transform.position.x - .15f, transform.position.y - .06f, transform.position.z);
			if(transform.position.y <= -0.7)
			{
				spawnMonster = true;
				x = transform.position.x;
				y = transform.position.y;
				gameObject.SetActive(false);
			}
		}
	}




}
