using UnityEngine;
using System.Collections;

public class WardenAnimation : MonoBehaviour {

	public SpriteRenderer spriteRenderer;
	public Sprite[] sprites;
	public Sprite[] spritesAttack;
	public Sprite[] spritesRanged;
	public float framesPerSecond;
	GameObject Warden;
	
	// Use this for initialization
	void Start () 
	{
		spriteRenderer = renderer as SpriteRenderer;
		Warden = GameObject.Find ("Warden");
		//framesPerSecond = 3;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		int index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
		index = index % sprites.Length;
		spriteRenderer.sprite = sprites[ index ];

		if (GetComponent<Warden> ().attack == true) 
		{
			spriteRenderer.sprite = spritesAttack[0];
		}
		else if(Warden.GetComponent<Warden>().shooting)
		{
			spriteRenderer.sprite = spritesRanged[0];
		}
	}
}
