using UnityEngine;
using System.Collections;

public class PlayerOne : PlayerSetup {

	public GameObject Attack;
	public Transform AttackPos;

	protected float RocketCD = -1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	



		transform.Translate(moveSpeed * Time.deltaTime);
		



		if(Input.GetKey(KeyCode.A))
		{
			transform.Rotate(turnSpeed);
		}

		if(Input.GetKey(KeyCode.D))
		{
			transform.Rotate(turnSpeed*-1);
		}

		if(Input.GetKey(KeyCode.F))
		{
			FireRocket();
		}

	}

	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag == "Wall")
			transform.Rotate (0,0,180f);		
	}

	void FireRocket(){

		if(RocketCD < Time.time)
		{
			GameObject Rocket = Instantiate(Attack, AttackPos.position, AttackPos.rotation) as GameObject;
			Rocket.rigidbody2D.velocity = new Vector2(Mathf.Cos((transform.eulerAngles.z + 90f) * (Mathf.PI / 180f)),
			                                          Mathf.Sin((transform.eulerAngles.z + 90f) * (Mathf.PI / 180f))) * 5f;
			CDAttack();
		}
	}


	void CDAttack() {
		RocketCD = 1f + Time.time;
		
		return;
	}
}
