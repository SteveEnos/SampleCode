using UnityEngine;
using System.Collections;

public class Base_script : MonoBehaviour {
		
	//------------------------------------------------------------------------------------------------;
	// Base Attributes

	int health;
	int defense;
	public int screenSide;

	public string selectedPathName;

	bool alive;
	bool spawning;

	//------------------------------------------------------------------------------------------------;
	// Prefabs

	public Transform minon_g; // declare Minon_Generic prefab

	//------------------------------------------------------------------------------------------------;

	// Use this for initialization
	void Start() {
	
		alive = true;
		spawning = true;

	}
	
	// Update is called once per frame
	void Update () {

		if (alive) {

			CheckInput ();
		}
	
	}

	void CheckInput () {

		if (Input.GetKeyDown ("s")) { 		// if key press...
			if (spawning){ 					// if can spawn...
				Spawn(); 					// spawn minon
			}
		}
	}

	void Spawn () {

		Instantiate (minon_g, new Vector3 (0 , 0, 0), Quaternion.identity);
		minon_g.GetComponent<Stats_script> ().team = this.gameObject.GetComponent<Stats_script> ().team;
		minon_g.GetComponent<Minion_script>().pathName = selectedPathName;

	}
}
