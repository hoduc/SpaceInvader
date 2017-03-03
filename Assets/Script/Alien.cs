using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : Ent2D {
	private int time = 0;
	// Use this for initialization
	void Start () {
		Init ();
	}
	
	// Update is called once per frame
	void Update () {
		//if (Time.time / 2 == 0) {
			if (!mover.MoveRight (DIST_X / 4)) {
				//mover.MoveLeft (DIST_X / 4);
			}

		//}
	}
}
