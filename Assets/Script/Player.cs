using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : Ent2D{
	public UnityEvent TakeDamageEvent; // drytest
	// Use this for initialization

	void Start(){
		Init ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			mover.MoveRight (DIST_X, RIGHT_BOUND_X);
		}

		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			mover.MoveLeft (DIST_X, LEFT_BOUND_X);
		}

		if (Input.GetKeyDown (KeyCode.D)) {
			TakeDamageEvent.Invoke (); //die
		}

		if (Input.GetKeyDown (KeyCode.Space) && shootable) {
            Ent2D.CreateBomb(child, this, DIST_Y);
		}
	}

	public void OnDieTest(){
		//nothing
		OnDie(this.GetComponent<BoxCollider2D>());
	}
}
