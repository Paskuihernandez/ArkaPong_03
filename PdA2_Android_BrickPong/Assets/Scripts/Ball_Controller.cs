using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Controller : MonoBehaviour {

	//Untener una referencia para el rigidbody attachado al gameObject
	Rigidbody rb;


	// Use this for initialization
	void Start () {

		//Get shortcut to rigidbody component
		rb = GetComponent<Rigidbody> ();

		//Pause ball logic for 1.5 seconds, delay launch
		StartCoroutine (Pause ());


	}
	
	// Update is called once per frame
	void Update () {

		//Si la bola va a la izquierda
		if (transform.position.x < -9.94f) {

			transform.position = Vector3.zero;
			rb.velocity = Vector3.zero;

			//El player 2 gana un punto
			Scoreboard_Controller.instance.GivePlayerTwoAPoint();


			StartCoroutine (Pause ());
		}


        //Si la bola va a la derecha
        if (transform.position.x > 9.94f) {

			transform.position = Vector3.zero;
			rb.velocity = Vector3.zero;

            //El player 1 gana un punto
            Scoreboard_Controller.instance.GivePlayerOneAPoint();

			StartCoroutine (Pause ());
		}


	}

	IEnumerator Pause () {


		//La bola vuelve salir en (1.5 seg):
		yield return new WaitForSeconds (1.5f);

		//Call function that launches the ball
		LaunchBall ();
	}

	void LaunchBall () {

		transform.position = Vector3.zero;

		//Ball Chooses a direction
		//Flies that direction

		//Flip a coin, determine direction in x-axis
		int xDirection = Random.Range(0, 2);

		//Flip another coin, determine direction in y-axis
		int yDirection = Random.Range(0, 3);


		Vector3 launchDirection = new Vector3 ();

		//Check results of one coin toss
		if (xDirection == 0) {

			launchDirection.x = -8f;
		}
		if (xDirection == 1) {

			launchDirection.x = 8f;
		}

		//Check results of second coin toss
		if (yDirection == 0) {

			launchDirection.y = -8f;
		}
		if (yDirection == 1) {

			launchDirection.y = 8f;
		}
		if (yDirection == 2) {

			launchDirection.y = 0f;
		}

		//Assign velocity based off of where we launch ball
		rb.velocity = launchDirection;
	}





	// When we hit something else...
	void OnCollisionEnter (Collision hit) {

		//If it was the top or bottom of the screen...
		if (hit.gameObject.name == "TopBounds") {

			float speedInXDirection = 0f;

			if (rb.velocity.x > 0f)
				speedInXDirection = 8f;

			if (rb.velocity.x < 0f)
				speedInXDirection = -8f;

			rb.velocity = new Vector3 (speedInXDirection, -8f, 0f);
		}

		if (hit.gameObject.name == "BottomBounds") {
			
			float speedInXDirection = 0f;

			if (rb.velocity.x > 0f)
				speedInXDirection = 8f;

			if (rb.velocity.x < 0f)
				speedInXDirection = -8f;

			rb.velocity = new Vector3 (speedInXDirection, 8f, 0f);
		}

		//If it was one of the bats
		if (hit.gameObject.name == "Left_Bat") {

			rb.velocity = new Vector3 (13f, 0f, 0f);


			//Check if we hit lower half of the bat...
			if (transform.position.y - hit.gameObject.transform.position.y < -1) {

				rb.velocity = new Vector3 (8f, -8f, 0f);
			}
			//Check if we hit lower half of the bat...
			if (transform.position.y - hit.gameObject.transform.position.y > 1) {

				rb.velocity = new Vector3 (8f, 8f, 0f);
			}
		}
		if (hit.gameObject.name == "Right_Bat") {

			rb.velocity = new Vector3 (-13f, 0f, 0f);


			//Check if we hit lower half of the bat...
			if (transform.position.y - hit.gameObject.transform.position.y < -1) {

				rb.velocity = new Vector3 (-8f, -8f, 0f);
			}
			//Check if we hit lower half of the bat...
			if (transform.position.y - hit.gameObject.transform.position.y > 1) {

				rb.velocity = new Vector3 (-8f, 8f, 0f);
			}
		}

	}

}
