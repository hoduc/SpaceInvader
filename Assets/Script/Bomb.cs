using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Ent2D {
	public Ent2D parent;
	public bool fromShip = false;
	private bool lastMove = false;

	void Update () {
		if (fromShip) {
            //Debug.Log("move up");
			lastMove = mover.MoveUp (DIST_Y, UP_BOUND_Y);
		} else {
            //Debug.Log("move down!!!");
			lastMove = mover.MoveDown (DIST_Y, DOWN_BOUND_Y);
		}

		if (!lastMove) { // past the end of the screen(Y,-Y)
			OnDie(null);
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
			//destroy the bomb
			//Debug.Log("collided with : " + otherEnt.name);
			otherEnt.OnDie (other);
			OnDie (other);
		}
	}

	public override void OnDie(Collider2D other){
		base.OnDie(other);
		parent.shootable = true;
		Destroy (gameObject);
	}
}
