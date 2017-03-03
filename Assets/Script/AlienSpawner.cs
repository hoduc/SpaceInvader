using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSpawner : MonoBehaviour {
	public int row = 5;
	public int col = 5;
	public float insetX = 0.5f;
	public float insetY = 0.5f;
	public GameObject[] Spawners;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < row; i++) {
			for (int j = 0; j < col; j++) {
				GameObject spawner = Spawners[Random.Range(0, Spawners.Length)];
				SpriteRenderer sr = spawner.GetComponent<SpriteRenderer> ();
				float spawnX = transform.position.x + j * (sr.bounds.size.x + insetX);
				float spawnY = transform.position.y + i * insetY;
				GameObject go = Instantiate (spawner,new Vector3(spawnX,spawnY,0.0f),Quaternion.identity);
				Alien goAlien = go.GetComponent<Alien> ();
				goAlien.Init ();
				goAlien.LEFT_BOUND_X = spawnX;
				goAlien.RIGHT_BOUND_X = spawnX + goAlien.RIGHT_BOUND_X - (col - j) * (sr.bounds.size.x + insetX);
				goAlien.startMoving = true;
			}
		}
	}
}
