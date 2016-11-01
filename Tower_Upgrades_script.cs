using UnityEngine;
using System.Collections;

public class Tower_Upgrades_script : MonoBehaviour {
	// This isnt being used right now because there is no UI to trigger a level up.

	public GameObject tower;
	int towerAttack;

	public void IncreaseAttack(){
		Debug.Log ("Increase Attack");

		tower.GetComponent<Stats_script> ().attack += 1;
		tower.GetComponentInChildren<Canvas> ().enabled = false;

	}
	void IncreaseDefense(){


	}
	void IncreaseHealth(){


	}
}
