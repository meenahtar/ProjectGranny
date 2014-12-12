using UnityEngine;
using System.Collections;

public class EnemyAnimation : MonoBehaviour {

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

		if (GetComponent<Enemy> ().attack == true) 
		{
			spriteRenderer.sprite = spritesAttack[1];
		}
	}
}
