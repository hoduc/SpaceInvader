using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Ent2D {
	private int index = 0;
    private int indexSize = 1;
    public float diameterX = 5.0f;
	public float diameterY = 5.0f;
	public float distDivider = 1.0f;

	public bool startMoving = false;

	private int count = 0;
	//testing movement
	void Start(){
		Init(transform.position.x, transform.position.x + diameterX, transform.position.y + diameterY/2.0f, transform.position.y - diameterY/2.0f);
	}

	public override void EntUpdate(){
		//mover.MoveDiagonalUp(DIST_X, DIST_Y/5, RIGHT_BOUND_X, UP_BOUND_Y);
		// count++;
		if (startMoving && !MoveIndex (index)) {
			index = ( index + 1 )%indexSize;
		}
	}

	bool MoveIndex(int index){
		bool ret = false;
		switch (index) {
		case 0:
			ret = mover.MoveDiagonalUpRight(DIST_X/distDivider, DIST_Y/distDivider, RIGHT_BOUND_X/2, UP_BOUND_Y/2);
			break;
		case 1:
			ret = mover.MoveDiagonalDownRight(DIST_X/distDivider, DIST_Y/distDivider, RIGHT_BOUND_X, DOWN_BOUND_Y/2);
			break;
        case 2:
			ret = mover.MoveDiagonalDownLeft(DIST_X / distDivider, DIST_Y/distDivider, LEFT_BOUND_X/2, DOWN_BOUND_Y/2);
            break;
        case 3:
			ret = mover.MoveDiagonalUpLeft(DIST_X / distDivider, DIST_Y/distDivider, LEFT_BOUND_X/2, UP_BOUND_Y/2);
            break;

        }

		return ret;
	}
}
