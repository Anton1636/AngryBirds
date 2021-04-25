using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static Dictionary<string, Player> players = new Dictionary<string, Player>();
    private const string PLAYER_ID = "Player";

    public static void RegisterPlayer(string netID, Player player)
    {
        string playerID = PLAYER_ID + netID;

        players.Add(playerID, player);
        player.transform.name = playerID;
    }

    internal static void UnRegisterPlayer(string playerID)
    {
        players.Remove(playerID);
    }

    public static Player GetPlayer(string playerID)
    {
        return players[playerID];
    }
}
