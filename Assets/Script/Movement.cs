using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	public bool MoveRight(float dist, float bound){
		float newX = transform.position.x + dist;
		if (newX <= bound) {
			transform.position += new Vector3 (dist, 0.0f, 0.0f);
			return true;
		}
		return false;
	}

	public bool MoveLeft(float dist, float bound){
		float newX = transform.position.x - dist;
		if (newX >= bound) {
			transform.position -= new Vector3 (dist, 0.0f, 0.0f);
			return true;
		}
		return false;
	}

	public bool MoveUp(float dist, float bound){
		float newY = transform.position.y + dist;
		if (newY <= bound &&  newY >= -bound) {
			transform.position += new Vector3 (0.0f, dist, 0.0f);
			return true;
		}
		return false;
	}

	public bool MoveDown(float dist, float bound){
		return MoveUp (-dist, bound);
	}

	public bool MoveDiagonalUp(float distX, float distY, float boundX, float boundY){
		bool ret = MoveRight(distX, boundX);
		ret &= MoveUp(distY, boundY);
		return ret;
	}

	public bool MoveDiagonalDown(float distX, float distY, float boundX, float boundY){
		bool ret = MoveDown(distY, boundY);
		ret &= MoveRight(distY, boundY);
		return ret;
	}
}
