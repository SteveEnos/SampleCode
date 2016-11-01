using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TowerActions_script : MonoBehaviour {

	public Button Button_Prefab;
	string[] level0ButtonNames; 

	// sprite references here..
	//
	//
	//
	//
	//
	//
	//
	//
	//
	//

	void Start () {
		//level0Buttons = new Button[]{Button_Prefab};
		level0ButtonNames = new string[]{"Barrage", "Sandbags", "Testing"};
		//level0Buttons = new Button[]{Button_Prefab,Button_Prefab,Button_Prefab};
		//level0Buttons = new Button[]{Button_Prefab,Button_Prefab,Button_Prefab,Button_Prefab};
	}

	public string[] RetrieveStringArray(string name){

		return level0ButtonNames;
	}

	public void Dispatcher(string str) {

		if 				(str == "Barrage") {
												Barrage ();
		} else if 		(str == "Sandbags") {
												Sandbags ();
		}
	}

	public void Barrage () {
		Debug.Log ("barrage!");
	}
	public void Sandbags () {
		Debug.Log ("Sandbags!");
	}
}
