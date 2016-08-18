//========================================================================
//
//  File Name:   Game.h
//
//  Author:  Stephen Enos
//
//  Course and Assignment:   SG440 HacknStab
//
//  Description:  Declaration of the Game class
//
//========================================================================
#ifndef H_Game
#define H_Game

#include "Player.h"

class Game
{
public:

    Game();
    ~Game(void);

    int PlayGame(PlayerType player1, PlayerType player2 );
    void PlayRound(Player &player1, Player &player2);
    void ProcessActions(Player &player1, Player &player2); 

};

#endif