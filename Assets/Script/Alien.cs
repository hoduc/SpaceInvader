using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : Ent2D {
	public bool startMoving = false;
	private int index = 0; //move direction
	//driving index by an array for example
	// Update is called once per frame
	void Update () {
		if (startMoving && !MoveIndex (index)) {
			index = ( index + 1 )%2;
		}
	}

	bool MoveIndex(int index){
		bool ret = false;
		switch (index) {
		case 0:
			ret = mover.MoveRight (DIST_X/6, RIGHT_BOUND_X);
			break;
		case 1:
			ret = mover.MoveLeft (DIST_X/6, LEFT_BOUND_X);
			break;
		}

		return ret;
	}
}
