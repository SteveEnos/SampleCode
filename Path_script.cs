using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Path_script : MonoBehaviour {

	public Color pathColor = Color.green;
	public List<Transform> pathNodes = new List<Transform> ();
	Transform array;

	void OnDrawGizmos(){
		Gizmos.color = pathColor;
		array = GetComponentInChildren<Transform> ();
		pathNodes.Clear();

		foreach (Transform pathNode in array) {

			if (pathNode != this.transform){
				pathNodes.Add (pathNode);
			}
		}

		for (int i = 0; i < pathNodes.Count; i++) {

			Vector3 pathNodePosition = pathNodes [i].position;
			if (i > 0){
				Vector3 previousPathNodePosition = pathNodes [i - 1].position;
				Gizmos.DrawLine (previousPathNodePosition,pathNodePosition);
				Gizmos.DrawWireSphere (pathNodePosition,0.3f);
			}
		}
	}
	
}
