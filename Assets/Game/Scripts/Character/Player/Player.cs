using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public static Player Instance { get; private set; }

    public bool isInBattle = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (!isInBattle)
        {
            SaveSystem.LoadPlayerTransformData(this);
        }
    }
}
