using UnityEngine;
using System.Collections;

public class Warden : MonoBehaviour {

	float startXPos;
	float xScale;
	public bool patrolActive;
	
	public int health;
	int attackDamage;
	public int rangeDamage;
	
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
	public float attackDuration;
	public float attackStartTime;
	float timeBetween;
	public bool seekDone;
	public bool shooting;

	public bool isMelee;
	
	public bool facingRight;
	
	
	
	
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
		timeBetween = 3.0f;
		attackHit = false;
		attackStarted = false;
		
		attackStartTime = 0;
		
		recoilStarted = false;
		
		attack = false;
		seekDone = false;
		
		facingRight = false;
		isBossDead = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		//Death check
		if (health <= 0) 
		{
			//print("dead");
			PlayerPrefs.SetInt("lastLevel",Application.loadedLevel);
			isBossDead = true;
			gameObject.SetActive(false);
			//print(PlayerPrefs.GetInt("lastLevel"));
			//Application.LoadLevel("shop");
		}
		
		if ((Mathf.Abs(transform.position.x - Granny.transform.position.x) <= 10f) || sawGranny)
		{
			if (sawGranny == false)
			{
				sawGranny = true;
				//seekStarted = true;
				seekStartTime = Time.time;
			}
			//Boss attack main method
			if (Mathf.Abs(transform.position.x - Granny.transform.position.x) <= 2.5f && !attackStarted) //MELEE ----------------------
			{
				attack = true;
				isMelee = true;
			}
			else
			{
				attack = false;
				if (Mathf.Abs(transform.position.x - Granny.transform.position.x) <= 7.0f)//RANGED ------------------------------------
				{
					if(attackStarted == false)
					{
						shooting = true;
						attackStarted = true;
						attackStartTime = Time.time;
						attack = true;
						isMelee = false;
						Instantiate(Resources.Load("Tazer"), new Vector3(transform.position.x - 1.0f, transform.position.y + 0.575f, transform.position.z), Quaternion.identity);
					}
					else if(Time.time > (attackStartTime + attackDuration + 1.0f))
					{
						shooting = false;
						attack = false;
						seekDone = false;
						transform.position = new Vector3(transform.position.x - .01f, transform.position.y, transform.position.z);
					}
					
					if (Time.time > (attackStartTime + attackDuration + timeBetween))
					{
						attackStarted = false;
					}
				}
				else if (!attackStarted)
				{
					Seek ();
				}
			}

			if (!shooting)
			{
				Seek();
			}
		}
		else
		{
			Patrol();
		}
		
		if (health <= 0) 
		{
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
		if (coll.gameObject.GetComponent<Granny> ().attackDown == true && (!coll.gameObject.CompareTag("Tazer"))) 
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
