using UnityEngine;
using System.Collections;

public class BossAnimation : MonoBehaviour {

	public SpriteRenderer spriteRenderer;
	public Sprite[] sprites;
	public Sprite[] spritesAttack;
	public float framesPerSecond;
	
	// Use this for initialization
	void Start () 
	{
		spriteRenderer = renderer as SpriteRenderer;
		//framesPerSecond = 3;
	}
	
	// Update is called once per frame
	void Update () 
	{

		int index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
		index = index % sprites.Length;
		spriteRenderer.sprite = sprites[ index ];

		if (GetComponent<Boss> ().seekDone == true) {
			spriteRenderer.sprite = sprites[0];
		}

		if (GetComponent<Boss> ().attack == true) 
		{
			spriteRenderer.sprite = spritesAttack[1];
		}
	}

}
