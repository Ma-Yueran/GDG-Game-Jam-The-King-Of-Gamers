using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteract : MonoBehaviour
{
    private void Awake()
    {
        TurnOffInteractMenu();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TurnOffInteractMenu();
        }
    }

    public void TurnOnInteractMenu()
    {
        Time.timeScale = 0f;
        gameObject.SetActive(true);
    }

    public void TurnOffInteractMenu()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }

    public void ChallengeNPC()
    {
        GameManager.Instance.StartBattle();
    }
}
