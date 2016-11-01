//========================================================================
//
//  File Name:   Game.cpp
//
//  Author:  Stephen Enos
//
//  Course and Assignment:   SG440 HacknStab
//
//  Description:  Definition of the Game class
//
//========================================================================
#include "Game.h"

//------------------------------------------------------------------------
// Name:  Game::Game()
//
// Description: Class Constructor
//
// Arguments: none
//
// Modifies:  Sets up the game
// 
// Returns: none
//
//------------------------------------------------------------------------
Game::Game()
{

}// end Game
//------------------------------------------------------------------------
// Name:  Game::~Game()
//
// Description: Class Destructor
//
// Arguments: none
//
// Modifies:  
// 
// Returns: none
//
//------------------------------------------------------------------------
Game::~Game(void)
{

}// end ~Game
//------------------------------------------------------------------------
// Name: PlayGame()
//
// Description: creates players, checks for victory condition, calls PlayRound() and ProcessActions() 
//
// Arguments: PlayerType p1, PlayerType p2
//
// Modifies: none
// 
// Returns: winner
//
//------------------------------------------------------------------------
int Game::PlayGame(PlayerType p1, PlayerType p2)
{
    // create players 
    Player player1(p1, 10, 1, 0);
    Player player2(p2, 10, 1, 0);

    int winner;


    // begin the game loop
    while(1)
    {
	   // Check victory condition
	   if (player1.GetHealth() <= 0) // player 1 is dead
	   {
		  winner = 2; // player2 wins.....
		  // unless....
		  if (player2.GetHealth() <= 0) // player 2 is also dead
		  {
			 winner = 0; // both players lose
			 return winner;
		  }
		  return winner;
	   }
	   
	   else if (player2.GetHealth() <= 0) // player 1 is not dead and player 2 is dead
	   {
		  winner = 1; // player 1 wins 
		  return winner;
	   }
	   // end victory condition

	   // begin round
	   system("CLS"); // clear the screen
	   PlayRound(player1,player2); // play a new round
	   ProcessActions(player1,player2);// get the result of the round
	   // end round
    }
}// end PlayGame
//------------------------------------------------------------------------
// Name: PlayRound()
//
// Description: Checks player type and calls ether HumanTakeAction() or AITakeAction accordingly
//
// Arguments: Player &p1, Player &p2
//
// Modifies: none
// 
// Returns: none
//
//------------------------------------------------------------------------
void Game::PlayRound(Player &p1, Player &p2)
{
    int humanLastAction;

    // process player 1's turn
    if (p1.GetType() == HUMAN) // Player 1 is Human
    {
	   p1.SetAction(0); // set the players action to default
	   while (p1.GetAction() == 0) // while the players action is set to default
	   {
		  cout << endl << "==Player 1's turn==" << endl;
		  p1.SetAction(p1.HumanTakeAction(p1)); // ask player for action input(should be 1,2, or 3)
		  system("CLS"); // clear the screen
		  if (p1.GetAction() == 0)
		  {
			 cout << "!!!!Selected action was not understood!!!!";
		  } 
	   }
    }
    else if (p1.GetType() == AI) // player 1 is an AI
    {
	   p1.SetAction(p1.AITakeAction(p1, p2.GetHealth(), p1.GetLastAction(), p1.GetOpponentLastAction()));
    }

    // process player 2's turn
    if (p2.GetType() == HUMAN) // player 2 is Human
    {
	   p2.SetAction(0); // set the players action to default
	   while (p2.GetAction() == 0) // while the players action is set to default
	   {
		  cout << endl << "==Player 2's turn==" << endl;
		  p2.SetAction(p2.HumanTakeAction(p2)); // ask player for action input(should be 1,2, or 3)
		  system("CLS"); // clear the screen
		  if (p2.GetAction() == 0)
		  {
			 cout << "!!!!Selected action was not understood!!!!";
		  } 
	   }
    }
    else if (p2.GetType() == AI) // player 2 is an AI
    {
	   p2.SetAction(p2.AITakeAction(p2, p1.GetHealth(), p2.GetLastAction(), p2.GetOpponentLastAction()));
    }
}// end PlayRound
//------------------------------------------------------------------------
// Name: ProcessActions()
//
// Description: 
//
// Arguments: 
//
// Modifies:
// 
// Returns:
//
//------------------------------------------------------------------------
void Game::ProcessActions(Player &p1, Player &p2)
{
    int p1PrevHealth = p1.GetHealth();
    int p2PrevHealth = p2.GetHealth();

    // both players stab, 1x damage to each
    if (p1.GetAction() == 1 && p2.GetAction() == 1)
    {
	   cout << endl;
	   cout << "==Player 1: Stabs==" << endl;
	   cout << "==Player 2: Stabs==" << endl;
	   p1.LoseHealth(p2.GetAttack() - p1.GetDefense()); // 1x damage to player 1
	   p2.LoseHealth(p1.GetAttack() - p2.GetDefense()); // 1x damage to player 2
    }
    //player 1 stabs, player 2 blocks, 1x damage to player 2
    else if (p1.GetAction() == 1 && p2.GetAction() == 2)
    {
	   cout << endl;
	   cout << "==Player 1: Stabs==" << endl;
	   cout << "==Player 2: Blocks==" << endl;
	   
	   p2.LoseHealth(p1.GetAttack() - p2.GetDefense()); // 1x damage to player 2
    }
    //player 1 stabs, player 2 Slashes, 1x damage to player 1 and 3x damage player 2
    else if (p1.GetAction() == 1 && p2.GetAction() == 3)
    {
	   cout << endl;
	   cout << "==Player 1: Stabs==" << endl;
	   cout << "==Player 2: Slashes==" << endl;
	   p1.LoseHealth(p2.GetAttack() - p1.GetDefense()); // 1x damage to player 1
	   p2.LoseHealth(p1.GetAttack() * 3 - p2.GetDefense()); // 3x damage to player 2
    }
    //player 1 blocks, player 2 stabs, 1x damage to player 1
    else if (p1.GetAction() == 2 && p2.GetAction() == 1)
    {
	   cout << endl;
	   cout << "==Player 1: Blocks==" << endl;
	   cout << "==Player 2: Stabs==" << endl;
	   p1.LoseHealth(p2.GetAttack() - p1.GetDefense()); // 1x damage to player 1
	   
    }
    // both players block, 0 damages to each
    else if (p1.GetAction() == 2 && p2.GetAction() == 2)
    {
	   cout << endl;
	   cout << "==Player 1: Blocks==" << endl;
	   cout << "==Player 2: Blocks==" << endl;


    }
    //player 1 blocks, player 2 slashes, 1x damage to player 2
    else if (p1.GetAction() == 2 && p2.GetAction() == 3)
    {
	   cout << endl;
	   cout << "==Player 1: Blocks==" << endl;
	   cout << "==Player 2: Slashes==" << endl;
	   
	   p2.LoseHealth(p1.GetAttack() - p2.GetDefense()); // 1x damage to player 2
    }
    //player 1 slashes, player 2 stabs, 3x damage to player 1, 1x damage to player 2
    else if (p1.GetAction() == 3 && p2.GetAction() == 1)
    {
	   cout << endl;
	   cout << "==Player 1: Slashes==" << endl;
	   cout << "==Player 2: Stabs==" << endl;
	   p1.LoseHealth(p2.GetAttack() * 3 - p1.GetDefense()); // 3x damage to player 1
	   p2.LoseHealth(p1.GetAttack() - p2.GetDefense()); // 1x damage to player 2
    }
    //player 1 slashes, player 2 blocks, 1x damage to player 1
    else if (p1.GetAction() == 3 && p2.GetAction() == 2)
    {
	   cout << endl;
	   cout << "==Player 1: Slashes==" << endl;
	   cout << "==Player 2: Blocks==" << endl;
	   p1.LoseHealth(p2.GetAttack() - p1.GetDefense()); // 1x damage to player 1
	   
    }
    // both players slash, 3x damage to each
    else if (p1.GetAction() == 3 && p2.GetAction() == 3)
    {
	   cout << endl;
	   cout << "==Player 1: Slashes==" << endl;
	   cout << "==Player 2: Slashes==" << endl;
	   p1.LoseHealth(p2.GetAttack() * 3 - p1.GetDefense()); // 3x damage to player 1
	   p2.LoseHealth(p1.GetAttack() * 3 - p2.GetDefense()); // 3x damage to player 2
    }
    
    cout << endl;
    cout << "==Player 1 lost " << p1PrevHealth - p1.GetHealth() << " health==" << endl;
    cout << "==Player 2 lost " << p2PrevHealth - p2.GetHealth() << " health==" << endl;
    cin.ignore();
    cin.get();

    p1.SetLastAction(p1.GetAction()); // set the action to the last action for use during the next turn
    p2.SetLastAction(p2.GetAction()); // set the action to the last action for use during the next turn
    p1.SetOpponentLastAction(p2.GetAction()); // set the opponents action to opponents last action for use during the next turn 
    p2.SetOpponentLastAction(p1.GetAction()); // set the opponents action to opponents last action for use during the next turn 
    
    
}// end ProcessActions