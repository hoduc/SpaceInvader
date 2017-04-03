using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : Ent2D{
	public UnityEvent TakeDamageEvent; // drytest

	void Start(){
		Init ();
	}

	float ScreenX(){
		return Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
	}
	
	// Update is called once per frame
	public override void EntUpdate () {
		if(isZombie)
			return;
		//Debug.Log ("width left:" + Camera.main.ScreenToWorldPoint (new Vector3 (-Screen.width, 0.0f, 0.0f)).x);
		if (Input.GetMouseButtonDown (0) && transform.position.x <  ScreenX()) {
			mover.MoveRight (DIST_X, RIGHT_BOUND_X);
		} else if (Input.GetMouseButtonDown (0) && transform.position.x > ScreenX()) {
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

		if (/*Input.GetKeyDown (KeyCode.Space) &&*/ !isShooting && shootable) { //autofire
            Ent2D.CreateBomb(child, this, DIST_Y, UP_BOUND_Y, -DOWN_BOUND_Y);
		}
	}

	public void EnableShoot(){
		shootable = true;
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
