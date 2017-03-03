using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : Ent2D {
	private int index = 0; //move direction
	//driving index by an array for example
	// Use this for initialization
	void Start () {
		Init ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!MoveIndex (index)) {
			index = ( index + 1 )%2;
		}
	}

	bool MoveIndex(int index){
		bool ret = false;
		switch (index) {
		case 0:
			ret = mover.MoveRight (DIST_X/4);
			break;
		case 1:
			ret = mover.MoveLeft (DIST_X/4);
			break;
		}

		return ret;
	}
}
