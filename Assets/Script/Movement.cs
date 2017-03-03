using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	private float WIDTH = 7.79f;
	private float HEIGHT = 7.79f;

	// Use this for initialization
	void Start () {
		WIDTH = Camera.main.orthographicSize;
		HEIGHT = WIDTH;
//		Debug.Log ("width:" + WIDTH);
//		Debug.Log ("HEIGHT:" + HEIGHT);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool MoveRight(float dist){
//		Debug.Log ("dist:" + dist);
//		Debug.Log ("postion.x:" + transform.position.x);
//		Debug.Log ("new y:" + transform.position.x + dist);
		float newX = transform.position.x + dist;
		if (newX <= WIDTH && newX >= -WIDTH) {
			transform.position += new Vector3 (dist, 0.0f, 0.0f);
			return true;
		}
		return false;
	}

	public bool MoveLeft(float dist){
		return MoveRight (-dist);
	}

	public bool MoveUp(float dist){
		float newY = transform.position.y + dist;
		if (newY <= HEIGHT &&  newY >= -HEIGHT) {
			transform.position += new Vector3 (0.0f, dist, 0.0f);
			return true;
		}
		return false;
	}

	public bool MoveDown(float dist){
		return MoveUp (-dist);
	}
}
