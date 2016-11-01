//========================================================================
//
//  File Name:   Player.cpp
//
//  Author:  Stephen Enos
//
//  Course and Assignment:   SG440 HacknStab
//
//  Description:  Definition of the Player class
//
//========================================================================
#include "Player.h"

//------------------------------------------------------------------------
// Name:  Player::Player()
//
// Description: Class Constructor
//
// Arguments: health, attack, defense
//
// Modifies:  Sets up the player
// 
// Returns: none
//
//------------------------------------------------------------------------
Player::Player(PlayerType playertype, int health, int attack, int defense)
{
    SetType(playertype);
    SetHealth(health);
    SetAttack(attack);
    SetDefense(defense);
    SetAction(0);
    SetLastAction(0);
    SetOpponentLastAction(0);
}// end Player
//------------------------------------------------------------------------
// Name:  Player::~Player()
//
// Description: Class Destructor
//
// Arguments: None
//
// Modifies: none 
// 
// Returns: none
//
//------------------------------------------------------------------------
Player::~Player(void)
{
}// end ~Player
//------------------------------------------------------------------------
// Name: SetType()
//
// Description: Sets the player type
//
// Arguments: PlayerType playertype
//
// Modifies: Player::type
// 
// Returns: none
//
//------------------------------------------------------------------------
void Player::SetType(PlayerType playertype)
{
    type = playertype;
}
//------------------------------------------------------------------------
// Name: SetHealth()
//
// Description: Sets the player health
//
// Arguments: int hth
//
// Modifies: Player::health
// 
// Returns: none
//
//------------------------------------------------------------------------
void Player::SetHealth(int hth)
{
    health = hth;
}// end SetHealth
//------------------------------------------------------------------------
// Name: SetAttack()
//
// Description: Sets the player attack
//
// Arguments: int atk
//
// Modifies: Player::attack
// 
// Returns: none
//
//------------------------------------------------------------------------
void Player::SetAttack(int att)
{
    attack = att;
}// end SetAttack
//------------------------------------------------------------------------
// Name: SetDefense()
//
// Description: Sets the player defense
//
// Arguments: int def
//
// Modifies: Player::defense
// 
// Returns: none
//
//------------------------------------------------------------------------
void Player::SetDefense(int def)
{
    defense = def;
}// end SetDefense
//------------------------------------------------------------------------
// Name: SetAction()
//
// Description: Sets the player action
//
// Arguments: int act
//
// Modifies: Player::action
// 
// Returns: none
//
//------------------------------------------------------------------------
void Player::SetAction(int act)
{
    if (act == 1 || act == 2 || act == 3) // check for a valid action
    {
	   action = act;
    }
    else
    {
	   action = 0;
    }
}// end SetAction
//------------------------------------------------------------------------
// Name: SetLastAction()
//
// Description: Sets player lastAction
//
// Arguments: int act
//
// Modifies: Player::lastAction
// 
// Returns: none
//
//------------------------------------------------------------------------
void Player::SetLastAction(int act)
{
    lastAction = act;
}// end SetLastAction
//------------------------------------------------------------------------
// Name: SetOpponentLastAction()
//
// Description: Sets the players opponentLastAction
//
// Arguments: int act
//
// Modifies: Player::opponentLastAction
// 
// Returns: none
//
//------------------------------------------------------------------------
void Player::SetOpponentLastAction(int act)
{
    opponentLastAction = act;
}// end SetOpponentLastAction
//------------------------------------------------------------------------
// Name: LoseHealth()
//
// Description: Subtracts a value from the players health
//
// Arguments: int damage
//
// Modifies: Player::health
// 
// Returns: none
//
//------------------------------------------------------------------------
void Player::LoseHealth(int damage)
{
    health -= damage;
}// end LoseHealth
//------------------------------------------------------------------------
// Name: GetType()
//
// Description: returns the player type
//
// Arguments: none
//
// Modifies: none
// 
// Returns: PlayerType Player::type
//
//------------------------------------------------------------------------
PlayerType Player::GetType()
{
    return type;
}
//------------------------------------------------------------------------
// Name: GetHealth()
//
// Description: returns the players health
//
// Arguments: none
//
// Modifies: none
// 
// Returns: int Player::health
//
//------------------------------------------------------------------------
int Player::GetHealth()
{
    return health;
}// end GetHealth
//------------------------------------------------------------------------
// Name: GetAttack()
//
// Description: returns the player attack
//
// Arguments: none
//
// Modifies: none
// 
// Returns: int Player::attack
//
//------------------------------------------------------------------------
int Player::GetAttack()
{
    return attack;
}// end GetAttack
//------------------------------------------------------------------------
// Name: GetDefense()
//
// Description: returns the player defense
//
// Arguments: none
//
// Modifies: none
// 
// Returns: int Player::defense
//
//------------------------------------------------------------------------
int Player::GetDefense()
{
    return defense;
}// end GetDefense
//------------------------------------------------------------------------
// Name: GetAction()
//
// Description: returns the player action
//
// Arguments: none
//
// Modifies: none
// 
// Returns: int Player::action
//
//------------------------------------------------------------------------
int Player::GetAction()
{
    return action;
}// end GetAction
//------------------------------------------------------------------------
// Name: GetLastaction()
// 
// Description: returns the player last action
//
// Arguments: none
// 
// Modifies: none
// 
// Returns: int Player::lastAction
//
//------------------------------------------------------------------------
int Player::GetLastAction()
{
    return lastAction;
}// end GetLastAction
//------------------------------------------------------------------------
// Name: GetOpponentLastAction()
//
// Description: returns the player opponentLastAction
//
// Arguments: none
//
// Modifies: none 
// 
// Returns: int Player::opponentLastAction
//
//------------------------------------------------------------------------
int Player::GetOpponentLastAction()
{
    return opponentLastAction;
}// end GetOpponentLastAction
//------------------------------------------------------------------------
// Name: HumanTakeAction()
//
// Description: Outputs UI and takes user input, modifies player action then returns player action 
//
// Arguments: Player player
//
// Modifies: Player::action
// 
// Returns: int Player::action
//
//------------------------------------------------------------------------
int Player::HumanTakeAction(Player player)
{
    int action = 0;

    cout << "==Your health: " << player.GetHealth() << "=="<< endl;
    switch(player.GetOpponentLastAction())
    {
    case 0:
	   {
		  cout << "==The opponent has not taken any actions yet==" << endl;
		  break;
	   }
    case 1:
	   {
		  cout << "==The opponents last action was a Stab==" << endl;
		  break;
	   }
    case 2:
	   {
		  cout << "==The opponents last action was a Block==" << endl;
		  break;
	   }
    case 3:
	   {
		  cout << "==The opponents last action was a Slash==" << endl;
		  break;
	   }
    default:
	   {
		  break;
	   }
    }
    cout << "==STAB(1),BLOCK(2),SLASH(3)==" << endl;
    cout << "==Enter Action==" << endl;
    cin >> action;
    return action;
}// end HumanTakeAction
//------------------------------------------------------------------------
// Name: AITakeAction()
//
// Description: runs through AI ruleset then returns player action
//
// Arguments: Player &player, int opponentHealth, int LastAct, int oppLastAct
//
// Modifies: Player::Action
// 
// Returns: int Player::action
//
//------------------------------------------------------------------------
// Comments: because of the rules of this assignment set the STAB action as overpowered, 
//		   and the fact that the AI should know as much as the human player, 
//		   the human player cannot win unless this sequece is followed 3,1,2,1,1,1,1.(EDIT 1,2x16 will also gain the human player a victory) 
//           The AI will always STAB on the first turn,
//		   because STAB is its best option. It knows that if the human player keeps taking the STAB action that ether both players
//		   will lose one health per round until both players are dead, or that if the player gains a lead and keeps choosing STAB
//		   the human player will win. Therefore whenever the human player stabs, the AI reacts by stabing on the next turn.
//------------------------------------------------------------------------
int Player::AITakeAction(Player &player, int opponentHealth, int lastAct, int oppLastAct)
{
    if (player.GetHealth() == 10) 
	   // player is at full health
    {
	   return 1; // stab, always stab on the first turn
    }
    else if (player.GetHealth() < 10 && player.GetHealth() > 5 && oppLastAct != 1) 
	   // if at less than full health but not at half health or below and the opponents last action was not stab
    {
	   if (player.GetHealth() - opponentHealth > 0 && lastAct != 3) 
		  // player health is more than opponents health and players last action was not SLASH
	   {
		  return 3; // Slash, take advantage of the lead
	   }
	   else if (player.GetHealth() - opponentHealth < 0) 
		  // opponent health is more than player health
	   {
		  return 2; // Block, be defensive
	   }
	   else // player health and opponent health are equal
	   {
		  return 1; // stab, greatest chance for damage, with the least chance for damage
	   }
    }
    else if (player.GetHealth() <= 5 && oppLastAct != 1 && oppLastAct != 1) 
	   // if half health or below and the opponents last action was not stab
    {
	   if (player.GetHealth() - opponentHealth < 0 && lastAct != 1) 
		  // player health is more than opponents health
	   {
		  return 1; // stab, greatest chance for damage, with the least chance for damage
	   }
	   else if (player.GetHealth() - opponentHealth < 0) 
		  // opponent health is more than player health
	   {
		  return 2; // Block, be defensive
	   }
	   else // player health and opponent health are equal
	   {
		  return 3; // Slash, all or nothing
	   }
    }
    else 
	   // opponents last action was stab
    {
	   return 1; // stab,
    }
    return 1;
}// end AITakeAction