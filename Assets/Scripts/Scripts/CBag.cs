using UnityEngine;
using System.Collections;

public class CBag : MonoBehaviour {

	GameObject Granny;
	bool facingRight;

	// Use this for initialization
	void Start () {
		Granny = GameObject.Find ("First Person Controller");
		facingRight = Granny.GetComponent<GrannyMovement> ().facingRight;
	}
	
	// Update is called once per frame
	void Update () {
		if (facingRight == true) 
		{
			transform.position = new Vector3 (transform.position.x + .15f, transform.position.y, transform.position.z);
		} 
		else
		{
			transform.position = new Vector3 (transform.position.x - .15f, transform.position.y, transform.position.z);
		}
	}

	void OnCollisionEnter(Collision coll)
	{
		if(coll.gameObject.CompareTag("Enemy"))
		{
			coll.gameObject.GetComponent<Enemy>().takeDamage (Granny.GetComponent<Granny>().rangeDamage);
			gameObject.SetActive(false);
		}
		else if(coll.gameObject.CompareTag("Boss"))
		{
			coll.gameObject.GetComponent<Boss>().takeDamage (Granny.GetComponent<Granny>().rangeDamage);
			gameObject.SetActive(false);
		}
		else if(coll.gameObject.CompareTag("LunchLady"))
		{
			coll.gameObject.GetComponent<LunchLady>().takeDamage (Granny.GetComponent<Granny>().rangeDamage);
			gameObject.SetActive(false);
		}
	}
}
