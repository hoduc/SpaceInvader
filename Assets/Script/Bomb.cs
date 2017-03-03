using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Ent2D {
	public Ent2D parent;
	public bool fromShip = false;
	private bool lastMove = false;
	// Use this for initialization
	void Start () {
		Init ();
	}
	
	// Update is called once per frame
	void Update () {
		if (fromShip) {
			lastMove = mover.MoveUp (DIST_Y);
		} else {
			lastMove = mover.MoveDown (DIST_Y);
		}

		if (!lastMove) {
			parent.shootable = true;	
			Destroy (this.gameObject);
		}
	}
}
