using UnityEngine;
using System.Collections;

public class Projectile_script : MonoBehaviour {

	public Transform target;

	Vector3 currentPosition;

	// Use this for initialization
	void Start () {
	
		currentPosition = transform.position;

	}
	
	// Update is called once per frame
	void Update () {

		if (target == null){
			GameObject.Destroy (gameObject);
			return;
		}
		Move ();
	
	}

	void Move(){
		currentPosition = transform.position;
		transform.position = Vector3.MoveTowards (currentPosition, target.position, this.gameObject.GetComponent<Stats_script>().speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider trig){
		if (trig.tag == "Red_Minion") {
			
			trig.GetComponent<Minion_script> ().TakeDamage(this.gameObject.GetComponent<Stats_script>().attack + this.gameObject.GetComponent<Stats_script>().attackModifier);
			GameObject.Destroy (gameObject);
		}
		if (trig.tag == "Blue_Minion") {
			
			trig.GetComponent<Minion_script> ().TakeDamage(this.gameObject.GetComponent<Stats_script>().attack + this.gameObject.GetComponent<Stats_script>().attackModifier);
			GameObject.Destroy (gameObject);
		}
	}
}
