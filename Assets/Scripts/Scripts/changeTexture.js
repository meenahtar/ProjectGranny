#pragma strict

function Start () 
{

}

function Update () 
{
	var attack: Texture = Resources.Load("GrannyAttack");
	var idle: Texture = Resources.Load("Granny");
	
	if (Input.GetKeyDown("j"))
	{
		renderer.material.mainTexture = attack;
	}
	if (Input.GetKeyUp("j"))
	{
		renderer.material.mainTexture = idle;
	}
}