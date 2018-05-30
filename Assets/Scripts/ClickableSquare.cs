using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableSquare : MonoBehaviour {
	public int squareNumber = 0;
	void OnMouseDown(){
		// Finds game manager and calls a method with SendMessage, with a parameter gameObject
		//gameObject is a variable (which refers to the specific GameObject that the script is attached to) 
		// Essentially gameObject is like the word: this.
		GameObject.Find("Game Manager").SendMessage("SquareClicked",gameObject); 
		Destroy(this); // Destroy the gameobject aka the script, so you can't click more than once
	}

	


	
}
