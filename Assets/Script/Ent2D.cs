using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (SpriteRenderer))]
[RequireComponent (typeof (Movement))]
public class Ent2D : MonoBehaviour {
	protected SpriteRenderer sr;
	protected Movement mover;
	public GameObject child;
	public AudioClip spawnClip;
	public AudioClip dieClip;
	public Sprite spawnSprite;
	public Sprite dieSprite;
	public float dieSec = 1.0f;
	public bool shootable = true;
    public bool isZombie = false;

	protected float DIST_X;
	protected float DIST_Y;

	public float LEFT_BOUND_X;
	public float RIGHT_BOUND_X;
	public float UP_BOUND_Y;
	public float DOWN_BOUND_Y;

	//public static float LBX = Camera.main.ScreenToWorldPoint(new Vector3(-Screen.width, 0.0f, 0.0f)).x;  //-7.79f;
	//public static float RBX = Screen.width;  //7.79f;
	//public static float UBY = Screen.height; //-7.79f;
	//public static float DBY = -Screen.height; //7.79f;

	void Start(){
		sr = GetComponent<SpriteRenderer> ();
		mover = GetComponent<Movement> ();
	}

	public virtual void EntUpdate(){
	}

	void Update(){
		EntUpdate();
	}

	public virtual void Init(float lbx /*= -7.79f*/, float rbx /*= 7.79f*/, float uby /*= -7.79f*/, float dby /*= 7.79f*/){
		sr = GetComponent<SpriteRenderer> ();
		mover = GetComponent<Movement> ();
		DIST_X = sr.bounds.extents.x;
		DIST_Y = sr.bounds.extents.y;
		LEFT_BOUND_X = lbx;
		RIGHT_BOUND_X = rbx;
		UP_BOUND_Y = uby;
		DOWN_BOUND_Y = dby;
		//Debug.Log ("spawnCLip:" + spawnClip);
		PlaySound (spawnClip, transform.position);
	}

	public virtual void Init(){
		Init(Camera.main.ScreenToWorldPoint(new Vector3(-Screen.width, 0.0f, 0.0f)).x, 
			 Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, 0.0f)).x, 
			 Camera.main.ScreenToWorldPoint(new Vector3(0.0f, Screen.height, 0.0f)).y, 
			 Camera.main.ScreenToWorldPoint(new Vector3(0.0f, -Screen.height, 0.0f)).y);
	}

	public void SetUpBoundY(float uby){
		UP_BOUND_Y = uby;
	}

	public void SetDownBoundY(float dby){
		DOWN_BOUND_Y = dby;
	}

	public void SetLeftBoundX(float lbx){
		LEFT_BOUND_X = lbx;
	}

	public void SetRightBoundX(float rbx){
		RIGHT_BOUND_X = rbx;
	}

	public void PlaySound(AudioClip clip, Vector3 pos){
		if (clip) {
			//Debug.Log ("play : " + clip.name);
			AudioSource.PlayClipAtPoint (clip, pos);
		}
	}

	//Overwrite this for dying and custom dying
	public virtual void OnDie(Collider2D other){
		Vector3 soundPos = this.transform.position;
		if (other) {
			//Debug.Log ("hello");
			soundPos = other.transform.position;
			other.isTrigger = false;
		}
		PlaySound (dieClip, soundPos);//play die clip
		sr.sprite = dieSprite;
		isZombie = true;
		shootable = false;
		GetComponent<BoxCollider2D>().isTrigger = false;
		StartCoroutine (finishedDieTime (dieSec));
	}

	IEnumerator finishedDieTime(float sec){
		yield return new WaitForSeconds (sec);
		sr.enabled = false;
		EventDispatcher.Instance.PlayerFinishedDyingEvent.Invoke();
    }

    public static Bomb CreateBomb(GameObject bomb, Ent2D owner, float dropY, float upBoundY, float downBoundY, bool bomFlip = true)
    {
        GameObject go = GameObject.Instantiate(bomb, new Vector3(owner.transform.position.x, owner.transform.position.y + dropY, 0.0f), Quaternion.identity);
        Bomb b = go.GetComponent<Bomb>();
        b.Init();
        b.SetOwner(owner, bomFlip);
        b.SetUpBoundY(upBoundY);
        b.SetDownBoundY(downBoundY);
        owner.shootable = false;
        return b;
    }
}
