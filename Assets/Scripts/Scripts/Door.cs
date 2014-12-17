using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	public SpriteRenderer spriteRenderer;
	public Sprite[] sprites;
	GameObject Granny;

	bool reached;
	float reachedTime;
	bool door25;
	bool door50;

	// Use this for initialization
	void Start () {
		spriteRenderer = renderer as SpriteRenderer;
		Granny = GameObject.Find ("First Person Controller");
		reached = false;
		door25 = false;
		door50 = false;
	}
	
	// Update is called once per frame
	void Update () {
		if ((Granny.transform.position.x > (transform.position.x - (transform.localScale.x / 2.0f) - 1.0f)) && (reached == false)) 
		{
			reached = true;
			reachedTime = Time.time;
		}

		if (reached) 
		{
			if (!door25)
			{
				transform.position = new Vector3 (transform.position.x - (transform.localScale.x * .125f), transform.position.y, transform.position.z);
				door25 = true;
			}
			spriteRenderer.sprite = sprites[0];

			if(Time.time > reachedTime + 0.5f)
			{
				if (!door50)
				{
					transform.position = new Vector3 (transform.position.x - (transform.localScale.x * .125f), transform.position.y, transform.position.z);
					door50 = true;
				}
				spriteRenderer.sprite = sprites[1];

				if (Time.time > reachedTime + 1.5f) {
					Application.LoadLevel("shop");
				}
			}
		}
	}
}
