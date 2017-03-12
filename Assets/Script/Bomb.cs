using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Ent2D {
	public Ent2D parent;
	public bool fromShip = false;
	private bool lastMove = false;

	void Update () {
		if (fromShip) {
			lastMove = mover.MoveUp (DIST_Y, UP_BOUND_Y);
		} else {
			lastMove = mover.MoveDown (DIST_Y, DOWN_BOUND_Y);
		}

		if (!lastMove) { // past the end of the screen(Y,-Y)
			parent.shootable = true;	
			Destroy (this.gameObject);
		}
	}

	public void SetOwner(Ent2D parent, bool fromShip){
		this.fromShip = fromShip;
		this.parent = parent;
		if (this.fromShip)
			this.sr.flipY = true;
	}

	void OnTriggerEnter2D(Collider2D other){
		Ent2D otherEnt = other.GetComponent<Ent2D> ();
		if (otherEnt && otherEnt != parent) {
			Debug.Log("collided with : " + otherEnt.name);
			otherEnt.OnDie (other);
		}
	}
}
