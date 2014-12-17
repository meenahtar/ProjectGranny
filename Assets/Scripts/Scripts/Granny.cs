using UnityEngine;
using System.Collections;

public class Granny : MonoBehaviour {

	GameObject healthGUI;
	GameObject graphics;

	bool recoilStarted;
	float recoilStartTime;

	Collision collisionEvent;

	public bool attackDown;
	Texture attack;
	Texture idle;

	bool attackHit;
	bool attackStarted;
	float attackStartTime;
	float attackDuration;

	bool rangeOnCooldown;
	public float rangeStartTime;
	float rangeTimer;
	public float rangeAnimationDuration;
	public bool isThrowing;
	
	public int attackDamage;
	public int rangeDamage;

	// Use this for initialization
	void Start () 
	{
		PlayerPrefs.SetInt ("bingoBalls", 0);

		//How to add
		//PlayerPrefs.SetInt ("bingoBalls", PlayerPrefs.GetInt ("bingoBalls") + 1);

		healthGUI = GameObject.Find ("displayHealth");
		graphics = GameObject.Find ("Graphics");

		attackDown = false; 
		attack = Resources.Load<Texture2D>("GrannyAttack");
		idle = Resources.Load<Texture2D>("Granny");

		attackDamage = 25;
		//Changes for sprite
		attackDuration = 0.3f;
		attackHit = false;
		attackStarted = false;

		rangeOnCooldown = false;
		rangeTimer = 0.01f;
		//normally 2.0f
		isThrowing = false;
		rangeAnimationDuration = 0.25f;

		rangeDamage = 25;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//attack
		if (Input.GetKeyDown("j") && attackStarted == false)
		{
			attackDown = true;
			attackStarted = true;
			attackStartTime = Time.time;
			graphics.renderer.material.mainTexture = attack;
		}

		//range
		if (Input.GetKeyDown ("k") && rangeOnCooldown == false) 
		{
			Instantiate(Resources.Load("CBag"), new Vector3(transform.position.x, transform.position.y+.9f, transform.position.z), Quaternion.identity);
			rangeOnCooldown = true;
			rangeStartTime = Time.time;
			isThrowing = true;
		}

		if (Time.time > rangeStartTime + rangeAnimationDuration) 
		{
			isThrowing = false;
		}

		if (Time.time > rangeStartTime + rangeTimer) 
		{
			rangeOnCooldown = false;
		}

		if (Time.time > attackStartTime + attackDuration)
		{
			graphics.renderer.material.mainTexture = idle;
			attackDown = false;
			attackStarted = false;
			attackHit = false;
		}

		//recoil
		if ((Time.time > (recoilStartTime + 0.5f)) && recoilStarted) {
			recoilStarted = false;
			//reset alpha to 100%
			graphics.renderer.material.color = new Color (graphics.renderer.material.color.r, graphics.renderer.material.color.g, graphics.renderer.material.color.b, 1.0f);
		} else if (recoilStarted == true) {
			if (collisionEvent.gameObject.transform.position.x > transform.position.x)
			{
				if(transform.position.x > GameObject.Find("Left Wall").transform.position.x + 2.5f)
				{
					transform.position = new Vector3(transform.position.x - 0.15f, transform.position.y, transform.position.z);
				}
			}
			else if (collisionEvent.gameObject.transform.position.x < transform.position.x)
			{
				if(transform.position.x < GameObject.Find("Right Wall").transform.position.x - 2.5f)
				{
					transform.position = new Vector3(transform.position.x + 0.15f, transform.position.y, transform.position.z);
				}
			}
		}

		if (healthGUI.GetComponent<healthController>().Health <= 0) 
		{
			//gameObject.SetActive(false);
			//SWITCH LEVEL TO DEATH
			PlayerPrefs.SetInt("lastLevel", Application.loadedLevel);
			//print(PlayerPrefs.GetInt("lastLevel"));
			Application.LoadLevel("death");
		}
	}

	void OnCollisionEnter(Collision coll)
	{
		if ((attackDown == false) && (!coll.gameObject.CompareTag("CBag"))) {
			collisionEvent = coll;

			healthGUI.GetComponent<healthController> ().takeDamage (5);
			if (recoilStarted == false)
			{
				//start recoil
				recoilStarted = true;
				recoilStartTime = Time.time;
				//set 50% alpha
				graphics.renderer.material.color = new Color (graphics.renderer.material.color.r, graphics.renderer.material.color.g, graphics.renderer.material.color.b, .5f);
			}
		} else if (attackHit == false) {
			//enemy takes hit
			attackHit = true;
			//damage
			if(coll.gameObject.CompareTag("Enemy"))
			{
				coll.gameObject.GetComponent<Enemy>().takeDamage (attackDamage);
			}
			else if(coll.gameObject.CompareTag("Boss"))
			{
				coll.gameObject.GetComponent<Boss>().takeDamage (attackDamage);
			}
			else if(coll.gameObject.CompareTag("LunchLady"))
			{
				coll.gameObject.GetComponent<LunchLady>().takeDamage (attackDamage);
			}
		}
	}

	public void takeDamage (int toTake)
	{
		healthGUI.GetComponent<healthController> ().takeDamage (toTake);
	}
}
