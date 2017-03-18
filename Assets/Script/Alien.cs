using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : Ent2D {
	public bool startMoving = false;
	private int index = 0; //move direction
    public float distDivider = 1.0f;
	//driving index by an array for example

	void Update () {
        //Debug.Log("alien Shootable:" + shootable);
        if (shootable)
        {
            Ent2D.CreateBomb(child, this, -DIST_Y, -7.79f, 7.79f, false);
        }
		if (startMoving && !MoveIndex (index)) {
			index = ( index + 1 )%2;
		}
	}

	bool MoveIndex(int index){
		bool ret = false;
		switch (index) {
		case 0:
			ret = mover.MoveRight (DIST_X / distDivider, RIGHT_BOUND_X);
			break;
		case 1:
			ret = mover.MoveLeft (DIST_X/ distDivider, LEFT_BOUND_X);
			break;
		}

		return ret;
	}

    public void OnDie(Collider2D other)
    {
        base.OnDie(other);
        isZombie = true;
        //broadcast die event
        new AlienDieEvent().Invoke(this);
    }
}
