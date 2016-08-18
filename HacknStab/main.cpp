//========================================================================
//
//  File Name:   main.cpp
//
//  Author:  Stephen Enos
//
//  Course and Assignment:   SG440 HacknStab
//
//  Description:  Main function
//
//========================================================================
#include <string>
#include "Game.h"

int main()
{
    string errorlog = "";
    int command = 0; // int to store the players input
    int winner;

    while(1)
    {
	   cout << errorlog << endl;
	   errorlog = ""; // reset error log
	   cout << "==(Play, Human vs Human(1),(Play, Human vs AI(2), Quit(9))" << endl;
	   cout << "==Enter Command==" << endl;
	   cin >> command;

	   switch(command)
	   {
	   case 1:
		  {
			 Game g1;
			 winner = g1.PlayGame(HUMAN,HUMAN);
			 break;
		  }
	   case 2:
		  {
			 Game g1;
			 winner = g1.PlayGame(HUMAN,AI);
			 break;
		  }
	   case 9:
		  {
			 return 0;
			 break;
		  }
	   default:
		  {
			 errorlog = "!!!!Command not Understood!!!!";
			 break;
		  }
	   }
	   if (winner == 1) // player 1 wins 
	   {
		 errorlog ="Player 1 won the game!";
	   }
	   else if (winner == 2) // player 2 wins
	   {
		 errorlog = "Player 2 won the game!";
	   }
	   else // both players lose
	   {
		  errorlog = "Both players lose!";
	   }
	   system("CLS"); // clear the screen
    }
}