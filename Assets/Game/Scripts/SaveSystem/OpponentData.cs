using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class OpponentData
{
    public int npcID;

    public OpponentData(Opponent opponent)
    {
        npcID = opponent.npcID;
    }
}
