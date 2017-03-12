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

	protected float DIST_X;
	protected float DIST_Y;

	public float LEFT_BOUND_X;
	public float RIGHT_BOUND_X;
	public float UP_BOUND_Y;
	public float DOWN_BOUND_Y;

	public void Init(float lbx = -7.79f, float rbx = 7.79f, float uby = -7.79f, float dby = 7.79f){
		sr = GetComponent<SpriteRenderer> ();
		mover = GetComponent<Movement> ();
		DIST_X = sr.bounds.extents.x;
		DIST_Y = sr.bounds.extents.y;
		LEFT_BOUND_X = lbx;
		RIGHT_BOUND_X = rbx;
		UP_BOUND_Y = uby;
		DOWN_BOUND_Y = dby;
	}

	public void SetUpBoundY(float uby){
		UP_BOUND_Y = uby;
	}

	public void SetDownBoundY(float dby){
		DOWN_BOUND_Y = dby;
	}

//	public void Init(){
//		sr = GetComponent<SpriteRenderer> ();
//		mover = GetComponent<Movement> ();
//		DIST_X = sr.bounds.extents.x;
//		DIST_Y = sr.bounds.extents.y;
//		LEFT_BOUND_X = -7.79f;
//		RIGHT_BOUND_X = 7.79f;
//		UP_BOUND_Y = -7.79f;
//		DOWN_BOUND_Y = 7.79f;
//
//	}
}
