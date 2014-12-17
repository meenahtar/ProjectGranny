using UnityEngine;
using System.Collections;

public class PortalToYourMom : MonoBehaviour {

	public SpriteRenderer spriteRenderer;
	public Sprite[] sprites;
	float startTime;
	bool portalOpen;
	bool groundDeleted;

	GameObject Portal;

	// Use this for initialization
	void Start () {
		spriteRenderer = renderer as SpriteRenderer;
		Portal = GameObject.Find ("Portal to your mom");
		startTime = Time.time;
		portalOpen = false;
		groundDeleted = false;
	}
	
	// Update is called once per frame
	void Update () {
		spriteRenderer.sprite = sprites[1];
		if(Time.time > startTime + .15f)
		{
			spriteRenderer.sprite = sprites[2];
		}
		if(Time.time > startTime + .3f)
		{
			spriteRenderer.sprite = sprites[3];
		}
		if(Time.time > startTime + .45f)
		{
			spriteRenderer.sprite = sprites[4];
		}
		if(Time.time > startTime + .6f)
		{
			spriteRenderer.sprite = sprites[5];
		}
		if(Time.time > startTime + .75f)
		{
			spriteRenderer.sprite = sprites[6];
			portalOpen = true;
		}

		if (portalOpen) 
		{
			if(Time.time > startTime + 1.25f && groundDeleted == false)
			{
				GameObject.Find("Ground").SetActive(false);
				groundDeleted = true;
			}
			if(Time.time > startTime + 2.75f)
			{
				Application.LoadLevel("level4");
			}
		}
	}
}
