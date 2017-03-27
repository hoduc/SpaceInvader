using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : Ent2D{
	public UnityEvent TakeDamageEvent; // drytest
	// Use this for initialization

	bool isMouseDown = false;
	void Start(){
		Init ();
	}


	// Update is called once per frame
	public override void EntUpdate () {
		if (Input.GetMouseButtonDown (0) && transform.position.x <  Camera.main.ScreenToWorldPoint(Input.mousePosition).x) {
			mover.MoveRight (DIST_X, RIGHT_BOUND_X);
		} else if (Input.GetMouseButtonDown (0) && transform.position.x > Camera.main.ScreenToWorldPoint(Input.mousePosition).x) {
			mover.MoveLeft (DIST_X, LEFT_BOUND_X);
		}

		if (Input.GetKeyDown (KeyCode.RightArrow) && !isZombie) {
			mover.MoveRight (DIST_X, RIGHT_BOUND_X);
		}

		if (Input.GetKeyDown (KeyCode.LeftArrow) && !isZombie) {
			mover.MoveLeft (DIST_X, LEFT_BOUND_X);
		}

		if (Input.GetKeyDown (KeyCode.D)) {
			TakeDamageEvent.Invoke (); //die
		}

		if (Input.GetKeyDown (KeyCode.Space) && shootable) {
            Ent2D.CreateBomb(child, this, DIST_Y, UP_BOUND_Y, -DOWN_BOUND_Y);
		}
	}

	public void OnDieTest(){
		//nothing
		OnDie(this.GetComponent<BoxCollider2D>());
	}

	public override void OnDie(Collider2D other){
		base.OnDie(other);
		//fire player event
		EventDispatcher.Instance.PlayerDieEvent.Invoke();
	}

	public void OnRespawn(){
		isZombie = false;
		shootable = true;
		GetComponent<BoxCollider2D>().isTrigger = true;
		sr.sprite = spawnSprite;
		sr.enabled = true;
	}

	public void OnGameOver(){
		Destroy(gameObject);
	}
}
