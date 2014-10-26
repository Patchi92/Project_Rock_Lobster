using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {

	Vector3 turnSpeed = new Vector3(0,0,1f);
	Vector2 moveDirection;
	float nextMoveTimer = 0f;
	float moveSpeed = 1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

		transform.Rotate(turnSpeed);


		if(nextMoveTimer < Time.time)
		{
			moveDirection = NextMove();
			nextMoveTimer = 5f + Time.time;
		}



		transform.Translate(moveDirection * Time.deltaTime);

	}

	Vector2 NextMove(){								
		int r = Random.Range (1, 4);				
		switch(r){									
		case 1:
			return new Vector2(1 * moveSpeed, 0);
		case 2:
			return new Vector2(0, 1 * moveSpeed);
		case 3:
			return new Vector2(-1 * moveSpeed, 0);
		default:
			return new Vector2(0, -1 * moveSpeed);
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		moveDirection = -moveDirection;
		turnSpeed = -turnSpeed;
	}
}
