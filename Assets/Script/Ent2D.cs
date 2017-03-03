using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (SpriteRenderer))]
[RequireComponent (typeof (Movement))]
public class Ent2D : MonoBehaviour {
	protected SpriteRenderer sr;
	protected Movement mover;
	public GameObject child;
	public bool shootable = true;

	public float DIST_X;
	public float DIST_Y;


	public void Init(){
		sr = GetComponent<SpriteRenderer> ();
		mover = GetComponent<Movement> ();
		DIST_X = sr.bounds.extents.x;
		DIST_Y = sr.bounds.extents.y;
	}

	// Use this for initialization
	void Start () {
		Init ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
