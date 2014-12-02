using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using System.Drawing;

public class Main : MonoBehaviour {

	//Enum for gameStates
	enum gameState{ main,gameLevel,pause,boss,shop};

	//Class for Granny
	public class Granny
	{
		//Fields for granny
		//list<int> inventory = new list<int>();
		//Rectangle hitBox = new Rectangle();
		int health;
		int attack;

		//Methods
		//Move method
		void GrannyMove()
		{
		}
		
		//Melee method (Walker)
		void GrannyMelee()
		{
		}
		
		//Ranged method (Colostomy bag)
		void GrannyRanged()
		{
		}
		
		//Grapple method (Knitting needles)
		void GrannyGrapple()
		{
		}
	}

	//Class for Enemy (parent)
	public class Enemy
	{
		//Fields for enemies
		public int health;
		public int attack;
		//Rectangle hitBox = new Rectangle();

		//Methods
		//Find Granny method
		public void FindGranny()
		{
		}
		
		//Patrol method
		public void Patrol()
		{
		}
		
		//Attack method
		public void Attack()
		{
		}
	}

	//Class for Special Enemy (child)
	class SpecialEnemy : Enemy
	{
		//Special attack methods
		//Orderly Attack
		public void specialAttackOrderly()
		{
		}

		//Lunch Lady Attack
		public void specialAttackLunchLady()
		{
		}

		//Warden Attack
		public void specialAttackWarden()
		{
		}

		//Satan Attack
		public void specialAttackSatan()
		{
		}


	}

	//Class for Special Enemy (child)
	class AttackEnemy : Enemy
	{
	}

	//Class for Special Enemy (child)
	class HealthEnemy : Enemy
	{
	}







	// Use this for initialization
	void Start () 
	{
		gameState curGameState;
		/*
		curGameState = gameState.main;

		if (curGameState = gameState.main) 
		{
		}

		else if (curGameState = gameState.gameLevel) 
		{
		}

		else if (curGameState = gameState.pause) 
		{
		}

		else if (curGameState = gameState.boss) 
		{
		}

		else if (curGameState = gameState.shop) 
		{
		}

		*/


	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
