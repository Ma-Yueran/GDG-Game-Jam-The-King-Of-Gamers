using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveSystem
{
    private static PlayerData playerData;
    private static OpponentData opponentData;

    public static void SavePlayerData(Player player)
    {
        playerData = new PlayerData(player);
    }

    public static void LoadPlayerTransformData(Player player)
    {
        if (playerData == null)
        {
            return;
        }

        player.transform.position = new Vector3(playerData.position[0], playerData.position[1], playerData.position[2]);
        player.transform.rotation = new Quaternion(playerData.rotation[0], playerData.rotation[1], playerData.rotation[2], playerData.rotation[3]);
    }

    public static void SaveOpponentData(Opponent opponent)
    {
        opponentData = new OpponentData(opponent);
    }

    public static OpponentData LoadOpponentData()
    {
        return opponentData;
    }
}
