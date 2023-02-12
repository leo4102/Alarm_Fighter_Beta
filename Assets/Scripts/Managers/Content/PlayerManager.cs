using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager
{
    private Player_Parent currentPlayer;

    public void SetPlayer(Player_Parent player)
    {
        this.currentPlayer = player;
    }
    public float GetCurrentPositionX()
    {
        return currentPlayer.transform.position.x;
    }
    public float GetCurrentPositionY()
    {
        return currentPlayer.transform.position.y;
    }
    public int GetCurrentX()
    {
        return currentPlayer.GetPlayerInd_X();
    }
    public int GetCurrentY()
    {
        return currentPlayer.GetPlayerInd_Y();
    }
}
