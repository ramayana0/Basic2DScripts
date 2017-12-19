using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicNPC2D : PhysicsObject {

	public float maxSpeed = 1f;

	protected bool isWalking;

	public float walkTime = 1f;
	protected float walkCounter;
	public float waitTime = 3f;
	protected float waitCounter;

	protected int walkDirection;

	// Use this for initialization
	void Start () 
	{
		waitCounter = waitTime;
		walkCounter = walkTime;

		//ChooseDirection();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(isWalking)
		{
			walkCounter -= Time.deltaTime;

			if(walkCounter < 0)
			{
				isWalking = false;
				waitCounter = waitTime;
			}
			switch(walkDirection)
			{
				case 0 :
					rb2d.velocity = new Vector2(maxSpeed,0);
					break;
				case 1 :
					rb2d.velocity = new Vector2(-maxSpeed,0);
					break;	
			}
		}
		else
		{
			waitCounter -= Time.deltaTime;

			if(waitCounter < 0)
			{
				ChooseDirection();
			}
		}
	}

	void ChooseDirection()
	{
		walkDirection = Random.Range(0, 2);
		isWalking = true;
		walkCounter = walkTime;
	}
}
