using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Ent2D {
	public Ent2D parent;
	public bool fromShip = false;
	private bool lastMove = false;
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
		if (fromShip) {
			//Debug.Log ("DIST_Y:" + DIST_Y);
			//Debug.Log ("UP_BOUND_Y:" + UP_BOUND_Y);
			lastMove = mover.MoveUp (DIST_Y, UP_BOUND_Y);
		} else {
			lastMove = mover.MoveDown (DIST_Y, DOWN_BOUND_Y);
		}

		if (!lastMove) {
			parent.shootable = true;	
			Destroy (this.gameObject);
		}
	}

	public void flipY(){
		sr.flipY = true;
	}
}
