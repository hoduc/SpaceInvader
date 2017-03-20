using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class AlienDieEvent : UnityEvent<Alien> {}

public class AlienSpawner : MonoBehaviour {
	//public int row = 5;
	public int col = 5;
	public float insetX = 0.5f;
	public float insetY = 0.5f;
	public GameObject spawner;
    public float DistDivider = 6;
    public bool shootable = false;
    public int numShootable = 3;
    public string AlienType;
    private Alien[] aliens;
    private Dictionary<int, int> pickedAlienMap = new Dictionary<int, int>();
    private int deads = 0;
    public static AlienDieEvent alienDieEvent = new AlienDieEvent();
   

	// Use this for initialization
	void Start () {
        aliens = new Alien[col];
		SpriteRenderer sr = spawner.GetComponent<SpriteRenderer> ();
		float lastPos = transform.position.x + col * (sr.bounds.size.x + insetX);
		float distX = Ent2D.RBX - lastPos;
		for (int j = 0; j < col; j++) {
			float spawnX = transform.position.x + j * (sr.bounds.size.x + insetX);
			float spawnY = transform.position.y /*+ i *  insetY*/;
			GameObject go = Instantiate (spawner,new Vector3(spawnX,spawnY,0.0f),Quaternion.identity);
			Alien goAlien = go.GetComponent<Alien> ();
			goAlien.Init ();
            //Debug.Log("debug:" + goAlien.shootable);
			goAlien.LEFT_BOUND_X = spawnX;
			goAlien.RIGHT_BOUND_X = spawnX + distX;//spawnX + goAlien.RIGHT_BOUND_X - (col - j) * (sr.bounds.size.x + insetX);
            goAlien.distDivider = DistDivider;
			goAlien.startMoving = true;
            aliens[j] = goAlien;
            
        }
        //pick the one who get to shoot
        if (shootable)
        {
            for (int i = 0; i < numShootable; i++)
            {
                pickRandomAlienShootableNotDead();
            }
        }

        alienDieEvent.AddListener(OnAlienDie);
	}

    //picked = isZombie || isInMap
    bool isAlienAlreadyPicked(Alien alien){
        //Debug.Log("hashcodeater:" + alien.GetHashCode());
        int index;
        bool isZ = alien.isZombie;
        //Debug.Log("isZombie:"+ isZ);
        bool isPrevPicked = pickedAlienMap.TryGetValue(alien.GetHashCode(), out index);
        //Debug.Log("isPrevPicked:"+ isPrevPicked);
        return isZ || isPrevPicked;
    }

    int pickRandomAlienIndexNotDead()
    {
        int randomIndex = Random.Range(0, aliens.Length - 1);
        //Debug.Log("how about index:" + randomIndex);
        //Debug.Log("hashcodeb4:" + aliens[randomIndex].GetHashCode());
        while (isAlienAlreadyPicked(aliens[randomIndex])) { randomIndex = Random.Range(0, aliens.Length - 1); }
        return randomIndex;
    }

    void pickRandomAlienShootableNotDead(){
        if(deads == aliens.Length)
            return;
        int randomIndex = pickRandomAlienIndexNotDead();
        Debug.Log("randomIndex:" + randomIndex);
        aliens[randomIndex].shootable = true;
        pickedAlienMap.Add(aliens[randomIndex].GetHashCode(), randomIndex);
    }

    public void OnAlienDie(Alien alien)
    {   
        //does it belong to my spawner?
        if(spawner && spawner.GetComponent<Alien>().AlienType != alien.AlienType){
            Debug.Log("not in this spawner");
            return;
        }
        //register dead
        deads++;
        int index;
        if(pickedAlienMap.TryGetValue(alien.GetHashCode(),out index)){ //armed one dead, pick new shootable
            pickedAlienMap.Remove(alien.GetHashCode());
            pickRandomAlienShootableNotDead();
        }
        //unarmed alien dead ?
    }
    
}
