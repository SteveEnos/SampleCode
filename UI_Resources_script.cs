using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class UI_Resources_script : MonoBehaviour {

	RectTransform thisRect;
	int buttonWidth = 40;
	public Button button_Prefab;

	//public GameObject popUpButton_Prefab;

	void Start () {
		thisRect = this.gameObject.GetComponent<RectTransform> ();
	}

	public void setCanvasState (bool state) {

		Canvas myParent = this.transform.parent.GetComponent<Canvas> ();
		myParent.enabled = state;

	}// end ToggleCanvas()

	//----------------------------------------------------------------------------------------------
	// Unity uses different sets of positional data.
	// The position of objects in the scene can be relitive to the world coordinates(3D environment),
	// or
	// relitive to the screen coordinates(2D plane), from the cameras point of view.
	// This function takes the world position of a selected object and converts it
	// into screen position. Then moves the object this class is attached to,
	// to that position. 

	// USES
	// Attach to a UI object other than a canvas.
	// Feed in a selectedobject(Transform).
	public void Relocate (Transform obj, Vector3 offset) {

		// Translate the selected objects world position into screen position.
		Vector3 screenPos = Camera.main.WorldToScreenPoint (obj.position);
		// set our position to that screen position.
		this.gameObject.transform.position = screenPos + offset;
	}// end Relocate()

	public void GetMenuButtonsForObject (Transform selectedObject) {

		// get the stats for the selected object
		Stats_script stats = selectedObject.GetComponentInChildren<Stats_script> ();
		// get the correct buttons for the selected object
		string[] selectedObjectButtonNames = selectedObject.GetComponentInChildren<TowerActions_script> ().RetrieveStringArray(stats.name);
		// define new panel size
		Vector2 v = new Vector2 (buttonWidth * selectedObjectButtonNames.Length, 40);
		// resize panel
		thisRect.sizeDelta = v;

		int count = 0;

		foreach (string btnCall in selectedObjectButtonNames) {

			Debug.Log ("SelectedObjectButtonNames index " + count + " = " + btnCall);
			// create a button
			Button go = Instantiate (button_Prefab) as Button;
			// set the new button's parent to be this panel
			go.gameObject.transform.SetParent (this.gameObject.transform);
			// change the text of the button to match the button call
			go.GetComponentInChildren<Text> ().text = btnCall;

			// give the new button a string to call to the dispatcher
			go.GetComponent<Click_script> ().call = btnCall;

			// give the new button a reference to the selected object
			go.GetComponent<Click_script> ().reference = selectedObject;

			RectTransform btnRect = go.GetComponent<RectTransform> ();

			Vector3 v3 = new Vector3 ((((thisRect.sizeDelta.x / selectedObjectButtonNames.Length) * count) - (thisRect.sizeDelta.x / 2)), 0, 0);

			btnRect.localPosition = v3;
			// count
			count ++;

		}
	}

	public void ResetMenu () {
		// resize panel to zero
		thisRect.sizeDelta = Vector2.zero;
		// destroy all buttons
		foreach (Transform child in this.transform) {
			GameObject.Destroy (child.gameObject);
		}
	}
}
