using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Minion_script : MonoBehaviour {

	public int currentNodeID = 0;

	private float reachDistance = 1.0f;

	public float rotationSpeed = 5.0f;

	public string pathName;

	Path_script path;

	public GameObject combatTextPrefab;

	Color combatTextColor;


	Vector3 lastNode;
	Vector3 currentNode;

	// Use this for initialization
	void Start () {

		if (this.gameObject.GetComponent<Stats_script> ().team == "red") {
			this.gameObject.tag = "Red_Minion";
		}
		if (this.gameObject.GetComponent<Stats_script> ().team == "blue") {
			this.gameObject.tag = "Blue_Minion";
		}
		path = GameObject.Find (pathName).GetComponent<Path_script>();
		lastNode = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		if (this.gameObject.GetComponent<Stats_script>().health <= 0 ){
			Kill ();
		}

		float distance = Vector3.Distance (path.pathNodes [currentNodeID].position, transform.position);

		transform.position = Vector3.MoveTowards (transform.position, path.pathNodes[currentNodeID].position, this.gameObject.GetComponent<Stats_script>().speed * Time.deltaTime);

		if (distance <= reachDistance) {

			if (currentNodeID != path.pathNodes.Count - 1) {
				
				currentNodeID++;
			}
				
		}
	
	}

	void ShowCombatText(string text, Color color){

		GameObject combatText = Instantiate (combatTextPrefab) as GameObject;
		RectTransform rect = combatText.GetComponent<RectTransform> ();
		combatText.transform.SetParent (transform.FindChild ("Minion_Canvas"));
		rect.transform.localPosition = combatTextPrefab.transform.localPosition;
		rect.transform.localScale = combatTextPrefab.transform.localScale;
		rect.transform.localRotation = combatTextPrefab.transform.localRotation;

		combatText.GetComponent<Text> ().text = text;

		combatText.GetComponent<Text> ().color = color;
		Destroy (combatText.gameObject, 1);
	}

	public void TakeDamage (int damage){

		this.gameObject.GetComponent<Stats_script>().health -= damage;
		combatTextColor = GetCombatTextColor (damage);
		ShowCombatText (damage.ToString(), combatTextColor);
	}

	void Kill (){

		GameObject.Destroy (gameObject,1);
	}
	//  THIS NEEDS WORK!!!! ... haha maxHealth was set to zero!
	Color GetCombatTextColor(float damage){
		float num = (this.gameObject.GetComponent<Stats_script>().health / this.gameObject.GetComponent<Stats_script>().maxHealth);

		if (num >= 0.68) {
			return Color.green;
		} else if (num >= 0.38 && num <= 0.67) {
			return Color.yellow;
		} else {
			return Color.red;
		}
	}
}
