using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour {
	public GameObject spawner;
	public float DistDivider = 6;
	public bool shootable = false;
	public int rowShootable = 3;
	public string AlienType;
	public float diameterX = 5.0f;
	public float diameterY = 5.0f;
	public int deads = 0;
	// Use this for initialization

	void Spawn(Vector3 Location){
		GameObject bossGo = Instantiate (spawner,transform.position,Quaternion.identity);
		Boss boss = spawner.GetComponent<Boss> ();
		boss.Init(transform.position.x, transform.position.x + diameterX, transform.position.y + diameterY/2.0f, transform.position.y - diameterY/2.0f);
		boss.shootable = true;
		//Debug.Log ("Boss spawn");
	}

	public void OnPossibleSpawn(int row){
		if(rowShootable == row){
			Spawn (transform.position);
		}
	}
}
