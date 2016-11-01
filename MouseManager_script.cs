//==============================================================================================================================;
// MouseManager_script{}
//	-This class handles all mouse input.
//	References: 
//				-menu1(a reference to a pop up UI) and a vector3 used as an offset.
// 	Stephen Enos
//------------------------------------------------------------------------------------------------------------------------------;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MouseManager_script : MonoBehaviour {

	// is raycast enabled?
	public bool enableRayCast;
	// a gameobject that RayCast() will return
	GameObject col;
	// cashe of the last col
	GameObject prevCol;
	// is mouse drag enabled?
	public bool enableDrag;
	// the speed that the user can click and drag the map
	public float dragSpeed;
	// is mouse zoom enabled?
	public bool enableZoom;
	// the speed that the user can zoom the camera with the mouse;
	public float zoomSpeed;
	// the minimum camera zoom allowed (there is a check for this but make sure the minZoom is >= the camera's near clipping plane)
	public float minZoom;
	// the maximum camera zoom allowed
	public float maxZoom;
	// a reference to a UI element that you would like to use as a pop up action bar
	public RectTransform menu1;
	// this will offset the placement of the pop up action bar 
	public Vector3 menu1Offset;

	void Start () {
		// make sure that the minZoom is set to at least the near clipping plane
		if (minZoom < Camera.main.nearClipPlane) {
			minZoom = Camera.main.nearClipPlane;
		}
		// make sure that the maxZoom is set to at most the camera's far clipping plane;
		if (maxZoom > Camera.main.farClipPlane || maxZoom < minZoom) {
			maxZoom = Camera.main.farClipPlane;
		}
	}

	// Update is called once per frame
	void Update () {

		CheckInput (); // check for user input
	}

	//==============================================================================================================================;
	// CheckInput()
	//	-This function checks devices for user input.
	// 		Checks left mouse, right mouse, and mouse wheel.
	//	Requires: enableDrag, dragSpeed, enableZoom, zoomSpeed, minZoom, maxZoom, menu1, menu1Offset, col, prevCol, enableRayCast.
	//------------------------------------------------------------------------------------------------------------------------------;
	void CheckInput(){

		if (enableRayCast == true) { 									// is raycast enabled?
			// call RayCast() and return the GameObject that it hits.
			col = RayCast ();
		}


		// -----------SELECT OBJECT-----------------------
		// check left mouse button click
		if (Input.GetMouseButtonDown(0)) {
			Debug.Log ("The raycast hit: " + col);

			if (prevCol != col) { // is this the same object that we selected in the previous update?
				
				if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject () == false) { // is the mouse over a UI element?
					
					// if col exists...
					if (col) {
						// cashe col
						prevCol = col;
						// enabe menu1
						menu1.GetComponent<UI_Resources_script> ().setCanvasState (true);
						// pass col into menu1 so it can populate the buttons
						menu1.GetComponent<UI_Resources_script> ().GetMenuButtonsForObject (col.transform);
						// move menu1 to the selected object
						menu1.GetComponent<UI_Resources_script> ().Relocate (col.transform, menu1Offset);

					} else {													// GameObject is null.
						// disable menu1
						menu1.GetComponent<UI_Resources_script> ().setCanvasState (false);
						// reset menu to be used again
						menu1.GetComponent<UI_Resources_script> ().ResetMenu();
						// dump prevCol
						prevCol = null;
					}
				}
			}
		}
		//-------------------------------------------------

		// -----------MAP DRAG-----------------------------
		if (enableDrag == true) { 					// is drag enabled?
			// check right mouse button click
			if (Input.GetMouseButton (1)) {

				// get the change in mouse position
				Vector3 newMousePos = new Vector3 (-Input.GetAxis ("Mouse X") * dragSpeed * Time.deltaTime,
					                     -Input.GetAxis ("Mouse Y") * dragSpeed * Time.deltaTime, 0);

				// modify camera position by new mouse position
				Camera.main.transform.position = Camera.main.transform.position + newMousePos;
			}
		}
		//-------------------------------------------------

		// -----------ZOOM---------------------------------
		if (enableZoom == true){					// is zoom enabled
			// -----------CAMERA ZOOM IN-----------------------	
			// check mouse wheel positive input
			if (Input.GetAxis ("Mouse ScrollWheel") > 0) {

				if (Camera.main.orthographic == true) { // if camera is orthographic...
					if (Camera.main.orthographicSize >= minZoom + zoomSpeed) // are we close to the minimum zoom distance?
					// Zoom in
						Camera.main.orthographicSize += -zoomSpeed;
				} else { 													 // camera must be perspective.
					if (Camera.main.fieldOfView >= minZoom + zoomSpeed) {
						// Zoom in
						Camera.main.fieldOfView += -zoomSpeed;
					}
				}
			}
			//-------------------------------------------------

			// -----------CAMERA ZOOM OUT----------------------
			// check mouse wheel negitive input
			if (Input.GetAxis ("Mouse ScrollWheel") < 0) {

				if (Camera.main.orthographic == true) { // if camera is orthographic...
					if (Camera.main.orthographicSize <= maxZoom + zoomSpeed) // are we close to the maximum zoom distance?
						// Zoom out
						Camera.main.orthographicSize += zoomSpeed;
				} else { 													 // camera must be perspective.
					if (Camera.main.fieldOfView <= maxZoom + zoomSpeed) {
						// Zoom out
						Camera.main.fieldOfView += zoomSpeed;
					}
				}
			}
		}
	}
	// End CheckInput()

	//==============================================================================================================================;
	// RayCast()
	//	-This function fires a ray from the camera through the mouse position.
	// 		Returns the parent GameObject of the collider hit.
	//	Requires: none.
	//	Notes: this function assumes that each gameobject that can be selected
	//  	   has an empty parent object with the tag "Selectable" and a collider.
	//	Notes2: Problems will arise if any child object of the gameobject with the "Selectable" tag, have a collider and are not
	//			on the ignore raycast layer.
	//------------------------------------------------------------------------------------------------------------------------------;
	GameObject RayCast(){

		GameObject col;

		// get mouse position as ray target.
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		RaycastHit hitInfo;

		// shoot ray
		if (Physics.Raycast (ray, out hitInfo)) {			// if ray hit something...
			//Debug.Log(hitInfo);
			if (hitInfo.collider.transform.gameObject.tag == "Selectable") { // is this something selectable?
				//Debug.Log("ho");
				col = hitInfo.collider.transform.gameObject; 	// get that GameObject and return its parent.
				return col.transform.gameObject;
			} 
		}
	return null;
	}
	// End RayCast()
}

