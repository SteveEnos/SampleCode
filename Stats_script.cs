using UnityEngine;
using System.Collections;

public class Stats_script : MonoBehaviour {

	public string objectName;
	public string team;
	public int level;		// A rough guage of how stong the tower is. 
							// ... The higher the value the more points
							// ... the player has to spend on upgrades.
	public int exp;			// The towers progress toward a level up. 
							// ... right now, every shot incresses exp.
	public float health;	// The current health of the tower.
	public float maxHealth;	// The maximum health the tower can have at any given time.
	public int attack;
	public int attackModifier;
	public int defense;
	public float speed;

	public float timer;		// The unit of time in which the tower will shoot
							// ... a projectile. The higher the value the less 
							// ... effective fireRate will be.
	public float fireRate;  // The rate at which a tower can shoot a projectile
							// ... The higher the value the faster the timer will 
							// ... approch zero. 
	public bool levelUpEligible;
}
