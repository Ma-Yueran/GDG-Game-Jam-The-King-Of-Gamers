using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentRegistry : MonoBehaviour
{
    public List<Opponent> opponentPrefabs;

    private Dictionary<int, Opponent> opponentDictionary = new Dictionary<int, Opponent>();
    private bool hasInit = false;

    private void Awake()
    {
        if (!hasInit)
        {
            opponentPrefabs.ForEach(x => opponentDictionary.Add(x.npcID, x));
            hasInit = true;
        }
    }

    public Opponent GetOpponentPrefab(int npcID)
    {
        return opponentDictionary[npcID];
    }
}
