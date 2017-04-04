using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {
	public GameObject spawner;
	public Player player;

	public void OnSpawn(){
		GameObject go = Instantiate (spawner,new Vector3(transform.position.x,transform.position.y,0.0f),Quaternion.identity);
        go.name = "player";
        player = go.GetComponent<Player> ();
        player.Init ();
	}

	public void OnGameOver(){
		player.OnGameOver();
	}

	public void OnPlayerDie(){
		player.OnRespawn();
	}
}
