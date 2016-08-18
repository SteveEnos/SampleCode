//==============================================================================================================================;
// GenerateMap_script{}
//	-This class creates the map.
//  References: Hex_Prefab
// 	Stephen Enos
//------------------------------------------------------------------------------------------------------------------------------;
using UnityEngine;
using System.Collections;

public class GenerateMap_script : MonoBehaviour {

	public GameObject hex_Prefab;

	// this is the number of hexes that make up the map
	int mapWidth  = 20;
	int mapHeight = 20;

	// offsets to make the generation, generate the map properly.
	float xOffset = 1.05f;
	float yOffset = 1.05f;

	// I do not have a 3D hex asset right now, If and when I do, these values can be used.
	//float xOffset = 0.9f;
	//float yOffset = 0.778f;


	// Use this for initialization
	void Start () {

		GenerateMap ();

	}
	//==============================================================================================================================;
	// GenerateMap()
	//	-This function generates the map.
	// 		By traversing through the mapWidth * mapHeight and creating a new gameobject from the hex_Prefab.
	//	Requires: mapWidth, mapHeight, xOffset, yOffset.
	//------------------------------------------------------------------------------------------------------------------------------;
	void GenerateMap(){

		for (int x = 0; x < mapWidth; x++) {			// Nested for loops to traverse a matrix of size x * y,
			for (int y = 0; y < mapHeight; y++) {		// and to create hexes to represent the map.

				float xPosition	=  x * xOffset;			// size the x by the width of the sprite relitive to 1 unity world unit.

				if (y % 2 == 1) {						// the row is odd....

					xPosition += xOffset / 2f;			// so increment new hex's x position by half the width of the sprite
														// relitive to 1 unity world unit.
				}

				// create a new hex.
				// cast as a (GameObject) instead of object)).
				GameObject hex = (GameObject)Instantiate (hex_Prefab, new Vector3 (xPosition, y * yOffset, 0), Quaternion.identity); 

				// change the name to indicate the index for use later.
				hex.gameObject.name = "Hex" + x + "_" + y;

				// set hex parent to matrix, to keep them in a folder in the hierarchy.
				hex.transform.SetParent (this.transform);
			}
		}
	}
	// End GenerateMap()
}
