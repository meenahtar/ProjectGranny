using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	float startXPos;
	float xScale;
	public bool patrolActive;

	public int health;
	int attackDamage;
	int rangeDamage;

	public bool attack;

	bool attackHit;
	bool attackStarted;
	float attackStartTime;
	float attackDuration;

	bool recoilStarted;
	float recoilStartTime;

	GameObject Granny;
	bool sawGranny;

	Collision collisionEvent;

	//Variable to be changed for different enemies
	public float distance;
	public float speed;
	public float seekRange;

	// Use this for initialization
	void Start () {
		startXPos = transform.position.x;
		xScale = transform.localScale.x;
		patrolActive = true;

		health = 100;
		attackDamage = 5;
		rangeDamage = 5;

		Granny = GameObject.Find ("First Person Controller");
		sawGranny = false;

		attackDuration = 1.0f;
		attackHit = false;
		attackStarted = false;

		recoilStarted = false;

		attack = false;
	}
	
	// Update is called once per frame
	void Update () {

		//Attack method
		Attack ();

		if ((Mathf.Abs(transform.position.x - Granny.transform.position.x) <= seekRange) || sawGranny)
		{
			if (sawGranny == false)
			{
				sawGranny = true;
			}
			Seek();
		}
		else
		{
			Patrol();
		}

		if (health <= 0) 
		{
			Instantiate(Resources.Load("BingoBall"), new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			gameObject.SetActive(false);
		}

		//recoil
		if ((Time.time > (recoilStartTime + 0.2f)) && recoilStarted) {
			recoilStarted = false;
			//reset alpha to 100%
			renderer.material.color = new Color (renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, 1.0f);
		} else if (recoilStarted == true) {
			if (collisionEvent.gameObject.transform.position.x > transform.position.x)
			{
				transform.position = new Vector3(transform.position.x - 0.15f, transform.position.y, transform.position.z);
			}
			else if (collisionEvent.gameObject.transform.position.x < transform.position.x)
			{
				transform.position = new Vector3(transform.position.x + 0.15f, transform.position.y, transform.position.z);
			}
		}
	}

	void Patrol () {
		if(patrolActive == true)
		{
			transform.localScale = new Vector3(-xScale, transform.localScale.y, transform.localScale.z);
			if(transform.position.x < startXPos + distance)
			{
				transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
			}
			else
			{
				patrolActive = false;
			}
		}
		else
		{
			transform.localScale = new Vector3(xScale, transform.localScale.y, transform.localScale.z);
			if(transform.position.x > startXPos - distance)
			{
				transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);

				if(transform.position.x < startXPos - distance)
				{
					patrolActive = true;
				}
			}
		}
	}
	
	void Seek() {
		if (transform.position.x > Granny.transform.position.x + 1.0f)
		{
			transform.localScale = new Vector3(xScale, transform.localScale.y, transform.localScale.z);
			transform.position = new Vector3(transform.position.x - .03f, transform.position.y, transform.position.z);
		}
		else if (transform.position.x < Granny.transform.position.x - 1.0f)
		{
			transform.localScale = new Vector3(-xScale, transform.localScale.y, transform.localScale.z);
			transform.position = new Vector3(transform.position.x + .03f, transform.position.y, transform.position.z);
		}
	}

	void Attack()
	{
		if (Mathf.Abs(transform.position.x - Granny.transform.position.x) <= 2.5f) 
		{
			attack = true;
		}
		else
		{
			attack = false;
		}

	}
	
	void OnCollisionEnter (Collision coll) {
		if ((coll.gameObject.GetComponent<Granny> ().attackDown == true) || (coll.gameObject.CompareTag("CBag"))) 
		{
			collisionEvent = coll;
		
	
			if (recoilStarted == false)
			{
				//start recoil
				recoilStarted = true;
				recoilStartTime = Time.time;
				//set 50% alpha
				renderer.material.color = new Color (renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, .5f);
			}

		} 
		else if (attackHit == false) 
		{
			//enemy takes hit
			attackHit = true;
			//damage
			coll.gameObject.GetComponent<Granny>().takeDamage (attackDamage);
		}
	}

	public void takeDamage (int toTake)
	{
		health = health - toTake;
	}
}