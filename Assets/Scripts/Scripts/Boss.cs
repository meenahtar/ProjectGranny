using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

	float startXPos;
	float xScale;
	public bool patrolActive;
	
	public int health;
	int attackDamage;
	int rangeDamage;
	
	public bool attack;
	
	bool attackHit;


	
	bool recoilStarted;
	float recoilStartTime;
	
	GameObject Granny;
	bool sawGranny;
	
	Collision collisionEvent;

	public bool isBossDead;

	//For boss attack
	bool attackStarted;
	bool seekStarted;
	float seekStartTime;
	float attackDuration;
	float attackStartTime;
	float timeBetween;
	public bool seekDone;
	
	//Variable to be changed for different enemies
	public float distance;
	public float speed;
	
	// Use this for initialization
	void Start () {
		startXPos = transform.position.x;
		xScale = transform.localScale.x;
		patrolActive = true;

		attackDamage = 5;
		rangeDamage = 5;
		
		Granny = GameObject.Find ("First Person Controller");
		sawGranny = false;
		
		attackDuration = 1.0f;
		timeBetween = 20.0f;
		attackHit = false;
		attackStarted = false;
		
		recoilStarted = false;
		
		attack = false;
		seekDone = false;
		isBossDead = false;
	}
	
	// Update is called once per frame
	void Update () {

		//Death check
		if (health <= 0) 
		{
			//print("dead");
			Instantiate(Resources.Load("BingoBall"), new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			Instantiate(Resources.Load("BingoBall"), new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			Instantiate(Resources.Load("BingoBall"), new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			Instantiate(Resources.Load("BingoBall"), new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			Instantiate(Resources.Load("BingoBall"), new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			Instantiate(Resources.Load("BingoBall"), new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			Instantiate(Resources.Load("BingoBall"), new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			Instantiate(Resources.Load("BingoBall"), new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			Instantiate(Resources.Load("BingoBall"), new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			Instantiate(Resources.Load("BingoBall"), new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			Instantiate(Resources.Load("BingoBall"), new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			Instantiate(Resources.Load("BingoBall"), new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			Instantiate(Resources.Load("BingoBall"), new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			Instantiate(Resources.Load("BingoBall"), new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			Instantiate(Resources.Load("BingoBall"), new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			Instantiate(Resources.Load("BingoBall"), new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			Instantiate(Resources.Load("BingoBall"), new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			Instantiate(Resources.Load("BingoBall"), new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			Instantiate(Resources.Load("BingoBall"), new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			Instantiate(Resources.Load("BingoBall"), new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);

			PlayerPrefs.SetInt("lastLevel",Application.loadedLevel);
			isBossDead = true;
			gameObject.SetActive(false);
			//print(PlayerPrefs.GetInt("lastLevel"));
			//Application.LoadLevel("shop");

		}

		if ((Mathf.Abs(transform.position.x - Granny.transform.position.x) <= 5f) || sawGranny)
		{
			if (sawGranny == false)
			{
				sawGranny = true;
				//seekStarted = true;
				seekStartTime = Time.time;
			}
			//Boss attack main method
			if (Time.time < (seekStartTime + 0.01f))
			{
				Seek();
			}
			else
			{
				seekDone = true;
				if(attackStarted == false)
				{
					attackStarted = true;
					attackStartTime = Time.time;
					attack = true;
					Instantiate(Resources.Load("Minion"), new Vector3(66.0f, 1.041055f, 0.0f), Quaternion.identity);
					Instantiate(Resources.Load("Minion"), new Vector3(67.0f, 1.041055f, 0.0f), Quaternion.identity);

				}
				else if(Time.time > (attackStartTime + attackDuration))
				{
					attack = false;
					seekDone = false;
					transform.position = new Vector3(transform.position.x - .01f, transform.position.y, transform.position.z);
				}

				if (Time.time > (attackStartTime + attackDuration + timeBetween))
				{
					attackStarted = false;
				}
			}
		}
		else
		{
			Patrol();
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
		if (transform.position.x > Granny.transform.position.x)
		{
			transform.localScale = new Vector3(xScale, transform.localScale.y, transform.localScale.z);
			transform.position = new Vector3(transform.position.x - .03f, transform.position.y, transform.position.z);
		}
		else
		{
			transform.localScale = new Vector3(-xScale, transform.localScale.y, transform.localScale.z);
			transform.position = new Vector3(transform.position.x + .03f, transform.position.y, transform.position.z);
		}
	}
	
	void OnCollisionEnter (Collision coll) {
		if (coll.gameObject.GetComponent<Granny> ().attackDown == true) 
		{
			collisionEvent = coll;
			
			
			if (recoilStarted == false)
			{
				//start recoil
				recoilStarted = true;
				recoilStartTime = Time.time;
				//set 50% alpha
				renderer.material.color = new Color (renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, .5f);



				//this is a fix not a solution
				//health = health - coll.gameObject.GetComponent<Granny>().attackDamage;



			}
			else if (attackHit == false) 
			{
				//enemy takes hit
				attackHit = true;
				//damage
				coll.gameObject.GetComponent<Granny>().takeDamage (attackDamage);
			}
		} 
	}
	
	public void takeDamage (int toTake)
	{
		health = health - toTake;
	}
}

