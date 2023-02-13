using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager
{
    private Character currentPlayer;

    public void SetPlayer(Character player)
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
