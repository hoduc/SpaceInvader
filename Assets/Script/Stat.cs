using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat : MonoBehaviour {
	public int lives = 3;
	public GameObject liveSprite;
	private GameObject[] liveSprites;
	// Use this for initialization
	void Start () {
		//Player.TakeDamageEvent.AddListener (OnPlayerTakeDamage);
		SpriteRenderer liveSpriteRenderer = liveSprite.GetComponent<SpriteRenderer> ();
		float x = transform.position.x;
		float y = transform.position.y;
		liveSprites = new GameObject[lives];
		for (int i = 0; i < lives; i++) {
			liveSprites[i] = GameObject.Instantiate(liveSprite, new Vector3(x - (float)(i*liveSpriteRenderer.bounds.size.x), y, 0.0f), Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.F)) {
			OnPlayerTakeDamage ();
		}
	}

	void OnPlayerTakeDamage(){
		if (lives - 1 == 0) {
			Debug.Log ("game over");
			return;
		}
		//take off live
		Destroy(liveSprites[lives-1]);
		lives--;
	}
}
