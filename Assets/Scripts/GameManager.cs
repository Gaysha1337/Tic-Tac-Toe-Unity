using System.Collections;
using UnityEditor.SceneManagement; // for reloading game
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	// These are for the object prefabs
	public GameObject ZERO; // naught
	public GameObject X; // Cross

	int[] squares = new int[9]; // This tells us who owns which square in the game

	int turn = 1; // turn tells us who's turn it is (1 = 0, 2 = X)
	int winner = 0;
	int ClickCount = 0;
	public void SquareClicked(GameObject square) {
		// Get the square number
		// param square gets the script ClickableSqaure from there grabs the var squarenumber
		int squareNumber = square.GetComponent<ClickableSquare>().squareNumber;
		//print(squareNumber);

		// Increase ClickCount
		ClickCount+=1;
		// Create the prefab when clicked
		// Geth the prefabs position
		SpawnPrefab(square.transform.position);
		
		//Make the player own the square
		squares[squareNumber] = turn;
		// Check for winner
		CheckForWinner();
		// Next player's turn
		NextTurn();

		
	}

	void CheckForWinner(){

		for(int player=1; player<=2;player++)
		{
			// First row
			if (squares[0] ==player && squares[1]==player && squares[2]==player){
				DisableSquares();
				print(player + "wins");
				winner = player;
			}
			//Second Row
			else if (squares[3] ==player && squares[4]==player && squares[5]==player){
				DisableSquares();
				print(player +  "wins");
				winner = player;
			}
			//Third row
			else if (squares[6] ==player && squares[7]==player && squares[8]==player){
				print(player +  "wins");
				winner = player;
			}
			//First column
			else if (squares[0] ==player && squares[3]==player && squares[6]==player){
				DisableSquares();
				print(player +  "wins");
				winner = player;
			}
			//Second column
			else if (squares[1] ==player && squares[4]==player && squares[7]==player){
				DisableSquares();
				print(player +  "wins");
				winner = player;
			}
			//Third column
			else if (squares[2] ==player && squares[5]==player && squares[8]==player){
				DisableSquares();
				print(player +  "wins");
				winner = player;
			}
			//Left to right diagonal
			else if (squares[0] ==player && squares[4]==player && squares[8]==player){
				DisableSquares();
				print(player +  "wins");
				winner = player;
			}
			//Right to left diagonal
			else if (squares[2] ==player && squares[4]==player && squares[6]==player){
				DisableSquares();
				print(player +  "wins");
				winner = player;
			}

		}
		// Check for a draw
		if (ClickCount ==9 && winner==0){
			winner = 3;
		}
		
	}



	void DisableSquares(){
		// Destroy the remaining squares
		foreach(ClickableSquare square in GameObject.FindObjectsOfType<ClickableSquare>()){
			Destroy(square);
		}
	}
	void SpawnPrefab(Vector3 position){
		position.z = 0;
		//print(turn);

		// Check who's turn it is then spawn their prefab
		if (turn==1) {
		Instantiate(ZERO, position, Quaternion.identity);
		}
		else if (turn == 2){
			Instantiate(X,position,Quaternion.identity);
		}
	}
	void NextTurn() {
		// Increases turn 
		turn = turn + 1;

		// check turn status
		if (turn == 3) {
			turn = 1;
		}
	}

	void OnGUI(){
		// Check if we have a winner
		

		if (winner == 1){
			// Winner is O
			GUI.Label(new Rect(Screen.width/2 -50, Screen.height /2-25,100,50),"O is the winner");
		}
		else if (winner == 2){
			// Winner is X
			GUI.Label(new Rect(Screen.width/2 -50, Screen.height /2-25,100,50),"X is the winner");
		}
		else if (winner == 3){
			// Draw
			GUI.Label(new Rect(Screen.width/2 -50, Screen.height /2-25,100,50),"It's a draw");
		}

		// Check if game is over
		if (winner!=0){
			if (GUI.Button(new Rect(Screen.width/2 -50, Screen.height /2 + 25,100,50),"Restart")){
				EditorSceneManager.LoadScene(0);

			}
		}
		
	}


}

