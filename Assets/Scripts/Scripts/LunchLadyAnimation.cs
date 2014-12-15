using UnityEngine;
using System.Collections;

public class LunchLadyAnimation : MonoBehaviour {

	public SpriteRenderer spriteRenderer;
	public Sprite[] sprites;
	public Sprite[] spritesAttack;
	public float framesPerSecond;
	GameObject lunchLady;
	
	// Use this for initialization
	void Start () 
	{
		spriteRenderer = renderer as SpriteRenderer;
		lunchLady = GameObject.Find ("LunchLady");
		//framesPerSecond = 3;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		int index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
		index = index % sprites.Length;
		spriteRenderer.sprite = sprites[ index ];
		
		if (GetComponent<LunchLady> ().seekDone == true) {
			spriteRenderer.sprite = sprites[0];
		}
		
		if (GetComponent<LunchLady> ().attack == true) 
		{
			spriteRenderer.sprite = spritesAttack[1];
			if(Time.time > (lunchLady.GetComponent<LunchLady>().attackStartTime + (lunchLady.GetComponent<LunchLady>().attackDuration / 6)))
			{
				spriteRenderer.sprite = spritesAttack[2];
			}
		}
	}
}
