using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager
{
    private Character currentPlayer;

    public void SetPlayer(Character player)
    {
        this.currentPlayer = player;
    }
    public Transform GetCurrentTransform() { return currentPlayer.transform; }
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
        return currentPlayer.GetCharacterInd_X();
    }
    public int GetCurrentY()
    {
        return currentPlayer.GetCharacterInd_Y();
    }
    public void IsLeft() { currentPlayer.IsLeft(); }
    public void IsRight() { currentPlayer.IsRight(); }
    public void IsUp() { currentPlayer.IsUp(); }
    public void IsDown() { currentPlayer.IsDown(); }
}
