using UnityEngine;
using System.Collections;

public class Click_script : MonoBehaviour {
	
	public Transform reference;
	public string call;

	public void Call () {
		reference.GetComponentInChildren<TowerActions_script> ().Dispatcher(call);
	}
}
