//========================================================================
//
//  File Name:   Player.h
//
//  Author:  Stephen Enos
//
//  Course and Assignment:   SG440 HacknStab
//
//  Description:  Declaration of the Player class
//
//========================================================================
#ifndef H_Player
#define H_Player

#include <iostream>
using namespace std;

enum PlayerType { HUMAN, AI } ;

class Player
{
public:

    Player(PlayerType playertype, int health, int attack, int defense);
    ~Player(void);

    void SetType(PlayerType playertype);
    void SetHealth(int hth);
    void SetAttack(int att);
    void SetDefense(int def);
    void SetAction(int act);
    void SetLastAction(int act);
    void SetOpponentLastAction(int act);

    void LoseHealth(int damage);

    PlayerType GetType();
    int GetHealth();
    int GetAttack();
    int GetDefense();
    int GetAction();
    int GetLastAction();
    int GetOpponentLastAction();

    int HumanTakeAction(Player player);
    int AITakeAction(Player &player, int oppontentHealth, int lastAct, int oppLastAct);

private:
    PlayerType type;
    int health;
    int attack;
    int defense;
    int action;
    int lastAction;
    int opponentLastAction;
};

#endif