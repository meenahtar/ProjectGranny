using UnityEngine;
using System.Collections;

public class GrannyAnimation : MonoBehaviour {

	public SpriteRenderer spriteRenderer;
	public Sprite[] spritesWalk;
	public Sprite[] spritesAttack;
	public Sprite[] spritesThrow;
	public float framesPerSecond;
	GameObject granny;
	int animationCase;

	// Use this for initialization
	void Start () 
	{
		spriteRenderer = renderer as SpriteRenderer;
		granny = GameObject.Find ("First Person Controller");
		//framesPerSecond = 3;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (granny.GetComponent<GrannyMovement> ().isMoving == true) 
		{
			//int index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
			//index = index % spritesWalk.Length;
			//spriteRenderer.sprite = spritesWalk[ index ];
			animationCase = 1;
			if (granny.GetComponent<Granny> ().attackDown == true) {
				animationCase = 2;
			}
			else if (granny.GetComponent<Granny> ().isThrowing == true) 
			{
				animationCase = 3;
			}
		} 
		else 
		{
			animationCase = 0;
			if(granny.GetComponent<Granny> ().attackDown == true)
			{
				//int index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
				//index = index % spritesAttack.Length;
				//spriteRenderer.sprite = spritesAttack[1];
				animationCase = 2;
			}
			else if (granny.GetComponent<Granny> ().isThrowing == true) 
			{
				animationCase = 3;
			}
		}




		switch (animationCase) 
		{
			//Idle
			case 0:
				spriteRenderer.sprite = spritesWalk[0];
				break;
			//Walking
			case 1:
				int index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
				index = index % spritesWalk.Length;
				spriteRenderer.sprite = spritesWalk[ index ];
				break;
			//Attack 
			case 2:
				spriteRenderer.sprite = spritesAttack[1];
				break;
			//Range
			case 3:
				spriteRenderer.sprite = spritesThrow[0];
			if(Time.time > (granny.GetComponent<Granny> ().rangeStartTime + (granny.GetComponent<Granny> ().rangeAnimationDuration / 6)))
					{
						spriteRenderer.sprite = spritesThrow[1];
					}
				break;
			//Idle if nothing else
			default:
				spriteRenderer.sprite = spritesWalk[0];
				break;
		}


	}

}
