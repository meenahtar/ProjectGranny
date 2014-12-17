using UnityEngine;
using System.Collections;

public class Tazer : MonoBehaviour {
	
	GameObject Warden;
	bool facingRight;
	float scaleAmount;
	
	// Use this for initialization
	void Start () {
		Warden = GameObject.Find ("Warden");
		facingRight = Warden.GetComponent<Warden> ().facingRight;
		scaleAmount = .03f;
		transform.localScale = new Vector3 (transform.localScale.x * .05f, transform.localScale.y, transform.localScale.z);
	}
	
	// Update is called once per frame
	void Update () {
		if (facingRight == true) 
		{
			transform.position = new Vector3 (transform.position.x + .15f, transform.position.y, transform.position.z);
		} 
		else
		{
			transform.localScale = new Vector3 (transform.localScale.x + scaleAmount, transform.localScale.y, transform.localScale.z);
			transform.position = new Vector3 (transform.position.x - (scaleAmount / 2), transform.position.y, transform.position.z);
		}

		if (Time.time > (Warden.GetComponent<Warden>().attackStartTime + Warden.GetComponent<Warden>().attackDuration + 1.0f))
		{
			gameObject.SetActive(false);
		}
	}
	
	void OnCollisionEnter(Collision coll)
	{
		if(coll.gameObject.CompareTag("Granny"))
		{
			coll.gameObject.GetComponent<Granny>().takeDamage (Warden.GetComponent<Warden>().rangeDamage);
			gameObject.SetActive(false);
		}
	}
	
	
}
