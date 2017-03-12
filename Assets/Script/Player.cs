using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : Ent2D{
	public UnityEvent TakeDamageEvent;
	// Use this for initialization
	void Start () {
		Init ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			//Debug.Log("result(plus):" + (Mathf.Abs(transform.position.x + DIST_X) - RIGHT_BOUND_X));
			mover.MoveRight (DIST_X, RIGHT_BOUND_X);
		}

		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			mover.MoveLeft (DIST_X, LEFT_BOUND_X);
		}

		if (Input.GetKeyDown (KeyCode.Space) && shootable) {
			GameObject go = GameObject.Instantiate (child, new Vector3 (transform.position.x, transform.position.y + DIST_Y, 0.0f), Quaternion.identity);
			Bomb b = go.GetComponent<Bomb> ();
			b.fromShip = true;
			b.parent = this;
			b.Init ();
			b.SetUpBoundY (7.79f);
			b.SetDownBoundY (-7.79f);
			b.flipY ();
			shootable = false;
		}

//		if (bulletMover) {
//			bulletMover.MoveUp(
//		}

		/*
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			mover.MoveUp (DIST_Y);
			//Debug.Log(sr.bounds.extents.y);
		}

		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			mover.MoveDown (DIST_Y);
		}*/
	}

//	void Shoot(){
//		if (shootable) {
//			bullet = Instantiate (bullet);
//		}
//	}
}
