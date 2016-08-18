//==============================================================================================================================;
// MouseManager_script{}
//	-This class handles all mouse input.
//	References: none
// 	Stephen Enos
//------------------------------------------------------------------------------------------------------------------------------;
using UnityEngine;
using System.Collections;

public class MouseManager_script : MonoBehaviour {

	// the speed that the user click and drag the map
	public float dragSpeed;
	
	// Update is called once per frame
	void Update () {

		CheckInput (); // check for use input
	}

	//==============================================================================================================================;
	// CheckInput()
	//	-This function checks devices for user input.
	// 		Checks left mouse, right mouse, and mouse wheel.
	//	Requires: dragSpeed.
	//------------------------------------------------------------------------------------------------------------------------------;
	void CheckInput(){

		// call RayCast() and return the GameObject that it hits.
		GameObject col = RayCast ();


		// -----------SELECT TILE--------------------------
		// check left mouse button click
		if (Input.GetMouseButtonDown(0)) {

			// if col exists...
			if (col) {
				// store reference to the GameObject's mesh renderer.
				MeshRenderer meshR = col.GetComponentInChildren<MeshRenderer> ();

				if (meshR.material.color == Color.black) {					// if black...

					meshR.material.color = Color.white;						// change to white.
				} else {
					meshR.material.color = Color.black;						// else change to black.
				}
			} else {													// GameObject is null.
				return;
			}
		}
		//-------------------------------------------------

		// -----------MAP DRAG----------------------------- 
		// check right mouse button click
		if (Input.GetMouseButton (1)) {

			// get the change in mouse position
			Vector3 newMousePos = new Vector3(  -Input.GetAxis ("Mouse X") * dragSpeed * Time.deltaTime,
												-Input.GetAxis ("Mouse Y") * dragSpeed * Time.deltaTime, 0);

			// modify camera position by new mouse position
			Camera.main.transform.position = Camera.main.transform.position + newMousePos;
		}
		//-------------------------------------------------

		// -----------CAMERA ZOOM--------------------------  	
		// check mouse wheel positive input
		if (Input.GetAxis ("Mouse ScrollWheel") > 0) {
			
			// Zoom in
			Camera.main.orthographicSize += -0.5f;
		}
		//-------------------------------------------------

		// -----------CAMERA ZOOM-------------------------- 
		// check mouse wheel negitive input
		if (Input.GetAxis ("Mouse ScrollWheel") < 0) {
			
			// Zoom out
			Camera.main.orthographicSize += 0.5f;
		}
	}
	// End CheckInput()

	//==============================================================================================================================;
	// RayCast()
	//	-This function fires a ray from the camera through the mouse position.
	// 		Returns a GameObject equal to the GameObject of the collider hit.
	//	Requires: none.
	//------------------------------------------------------------------------------------------------------------------------------;
	GameObject RayCast(){

		GameObject col;

		// get mouse position as ray target.
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		RaycastHit hitInfo;

		// shoot ray
		if (Physics.Raycast (ray, out hitInfo)) {			// if ray hit something...

			col = hitInfo.collider.transform.gameObject; 	// get that GameObject and return it.

			return col;
		}

		return null;
	}
	// End RayCast()
}

