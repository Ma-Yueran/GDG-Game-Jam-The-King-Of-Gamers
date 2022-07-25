using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatActivation : MonoBehaviour
{
    public GameObject chatPopUp;
    public NPCInteract interactUI;

    private bool overlapWithPlayer = false;

    private void Start()
    {
        chatPopUp.SetActive(false);
    }

    private void Update()
    {
        if (!overlapWithPlayer)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            interactUI.TurnOnInteractMenu();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();

        if (player != null)
        {
            chatPopUp.SetActive(true);
            overlapWithPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Player player = other.GetComponent<Player>();

        if (player != null)
        {
            chatPopUp.SetActive(false);
            overlapWithPlayer = false;
        }
    }
}
