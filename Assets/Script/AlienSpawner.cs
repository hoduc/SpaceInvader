using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSpawner : MonoBehaviour {
	public int row = 5;
	public int col = 5;
	public float insetX = 0.5f;
	public float insetY = 0.5f;
	public GameObject spawner;

	// Use this for initialization
	void Start () {
		SpriteRenderer sr = spawner.GetComponent<SpriteRenderer> ();
		float lastPos = transform.position.x + col * (sr.bounds.size.x + insetX);
		float distX = Ent2D.RBX - lastPos;
		for (int i = 0; i < row; i++) {
			for (int j = 0; j < col; j++) {
				float spawnX = transform.position.x + j * (sr.bounds.size.x + insetX);
				float spawnY = transform.position.y + i * insetY;
				GameObject go = Instantiate (spawner,new Vector3(spawnX,spawnY,0.0f),Quaternion.identity);
				Alien goAlien = go.GetComponent<Alien> ();
				goAlien.Init ();
				goAlien.LEFT_BOUND_X = spawnX;
				//Debug.Log ("rbx[b4]:" + goAlien.RIGHT_BOUND_X);
				goAlien.RIGHT_BOUND_X = spawnX + distX;//spawnX + goAlien.RIGHT_BOUND_X - (col - j) * (sr.bounds.size.x + insetX);
				//Debug.Log ("rbx[a3]:" + goAlien.RIGHT_BOUND_X);
				goAlien.startMoving = true;
			}
		}
	}
}
