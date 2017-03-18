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
    private Alien[] aliens;
    private Dictionary<Alien, int> pickedAlienMap = new Dictionary<Alien, int>();
    public AlienDieEvent alienDieEvent;
   

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
			goAlien.LEFT_BOUND_X = spawnX;
			goAlien.RIGHT_BOUND_X = spawnX + distX;//spawnX + goAlien.RIGHT_BOUND_X - (col - j) * (sr.bounds.size.x + insetX);
            goAlien.distDivider = DistDivider;
			goAlien.startMoving = true;
            aliens[j] = goAlien;
            pickedAlienMap.Add(goAlien, -1);
        }
        //pick the one who get to shoot
        if (shootable)
        {
            for (int i = 0; i < numShootable; i++)
            {
                pickRandomAlienShootable();
            }
        }
	}


    void pickRandomAlienShootable()
    {
        int randomIndex = Random.Range(0, aliens.Length - 1);
        while (aliens[randomIndex].isZombie) { randomIndex = Random.Range(0, aliens.Length - 1); }
        aliens[randomIndex].shootable = true;
        pickedAlienMap[aliens[randomIndex]] = randomIndex;
    }

    public void OnAlienDie(Alien alien)
    {
        int randomIndex = -1;
        if(pickedAlienMap.TryGetValue(alien, out randomIndex))
        {
            //regenerate the index
            pickRandomAlienShootable();
        }
    }
    
}
