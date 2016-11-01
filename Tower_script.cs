using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Tower_script : MonoBehaviour {

	public List<Transform> targets = new List<Transform> ();
	public Transform projectile;
	Transform target;
	int size;

	// Use this for initialization
	void Start () {
		// initially, a new tower is not eligible for a level up 
		this.gameObject.GetComponent<Stats_script> ().levelUpEligible = false;
		// Hard set timer to 100
		this.gameObject.GetComponent<Stats_script>().timer = 100;
		// check if tower is red....
		if (gameObject.tag == "Red_Tower") {
			this.gameObject.GetComponent<Stats_script>().team = "red";
		}
		// or blue.
		if (gameObject.tag == "Blue_Tower") {
			this.gameObject.GetComponent<Stats_script>().team = "blue";
		}
	}
	
	// Update is called once per frame
	void Update () {
		// check if tower has NOT completed its timer.... if NOT...
		if (this.gameObject.GetComponent<Stats_script> ().timer > 0) {
			this.gameObject.GetComponent<Stats_script> ().timer -= this.gameObject.GetComponent<Stats_script> ().fireRate; // decrement timer by fireRate
		}
		// check if tower has completed its timer and that it has a target.	
		if (this.gameObject.GetComponent<Stats_script>().timer <= 0 && targets.Count > 0) {
			this.gameObject.GetComponent<Stats_script>().timer = 100; // Hard reset timer to 100

			if (target == null) {
				targets.Remove (target);
			}

			target = GetClosestTarget ();
			// if targets still exist. FIRE!!
			if (target != null) {
				ShootProjectile ();
			}
		}
	}

	void OnTriggerEnter(Collider col){

		if (this.gameObject.GetComponent<Stats_script>().team == "red" && col.tag == "Blue_Minion") {
			targets.Add (col.transform);  // why is this triggering twice?????
		}
		if (this.gameObject.GetComponent<Stats_script>().team == "blue" && col.tag == "Red_Minion") {
			targets.Add (col.transform);  // why is this triggering twice?????
		}
		 
	}
	void OnTriggerExit(Collider col){

		if (this.gameObject.GetComponent<Stats_script>().team == "red" && col.tag == "Blue_Minion") {
			targets.Remove (col.transform);  // why is this triggering twice?????
		}
		if (this.gameObject.GetComponent<Stats_script>().team == "blue" && col.tag == "Red_Minion") {
			targets.Remove (col.transform);  // why is this triggering twice?????
		}

	}

	Transform GetClosestTarget(){

		Transform closestTarget = null;
		float closestDistanceSquared = Mathf.Infinity;
		Vector3 currentPosition = transform.position;
		foreach (Transform potentailTarget in targets) {

			Vector3 directionToTarget = potentailTarget.position - currentPosition;
			float distanceSquaredToTarget = directionToTarget.sqrMagnitude;
			if (distanceSquaredToTarget < closestDistanceSquared) {

				closestDistanceSquared = distanceSquaredToTarget;
				closestTarget = potentailTarget;
			}
		}
		return closestTarget;
	}

	void ShootProjectile(){
		
		Instantiate (projectile, new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
		projectile.GetComponent<Projectile_script> ().target = target;
		projectile.GetComponent<Stats_script> ().attackModifier = (this.gameObject.GetComponent<Stats_script>().attack);
		if (this.gameObject.GetComponent<Stats_script>().team == "red") {
			projectile.GetComponent<Projectile_script> ().tag = "Red_Projectile";
		}
		if (this.gameObject.GetComponent<Stats_script>().team == "blue") {
			projectile.GetComponent<Projectile_script> ().tag = "Blue_Projectile";
		}

		GainExp ();

	}

	void GainExp(){

		this.gameObject.GetComponent<Stats_script>().exp += 1;
		CheckExp ();
	}

	void CheckExp(){

		int exp = this.gameObject.GetComponent<Stats_script> ().exp;
		int level = this.gameObject.GetComponent<Stats_script> ().level;

		if 		(exp >= 50  && level < 1)  {	// level 1
			this.gameObject.GetComponent<Stats_script>().levelUpEligible = true;
		} 
		else if (exp >= 125 && level < 2) { 	// level 2
			this.gameObject.GetComponent<Stats_script>().levelUpEligible = true;
		} 
		else if (exp >= 225 && level < 3) { 	// level 3
			this.gameObject.GetComponent<Stats_script>().levelUpEligible = true;
		} 
		else if (exp >= 350 && level < 4) { 	// level 4
			this.gameObject.GetComponent<Stats_script>().levelUpEligible = true;
		}
		else if (exp >= 475 && level < 5) { 	// level 5
			this.gameObject.GetComponent<Stats_script>().levelUpEligible = true;
		}
	}

	public void LevelUp(){

		this.gameObject.GetComponent<Stats_script>().level += 1;

		// to do: add in some special attack that comes from the tower. 

	}
}
