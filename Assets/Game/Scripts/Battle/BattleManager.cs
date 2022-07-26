using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public Transform playerPos;
    public Transform opponentPos;
    public BattleUI battleUI;

    private enum BattleState { BattleStart, PlayerTurnStart, PlayerTurn, OpponentTurnStart, OpponentTurn }
    private BattleState battleState = BattleState.BattleStart;

    private Player player;
    private Opponent opponent;

    private float timer;

    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        switch (battleState)
        {
            case BattleState.BattleStart:
                BattleStart();
                break;
            case BattleState.PlayerTurnStart:
                PlayerTurnStart();
                break;
            case BattleState.PlayerTurn:
                break;
            case BattleState.OpponentTurnStart:
                break;
            case BattleState.OpponentTurn:
                break;
        }
    }

    public void BattleEnds()
    {
        GameManager.Instance.BackToPreviousScene();
    }

    private void Init()
    {
        player = Instantiate(GameManager.Instance.playerPrefab);
        player.isInBattle = true;
        player.transform.position = playerPos.position;
        player.transform.rotation = playerPos.rotation;

        battleUI.SetUpPlayerSkills(player.skills);

        int npcID = SaveSystem.LoadOpponentData().npcID;

        opponent = Instantiate(GameManager.Instance.OpponentRegistry.GetOpponentPrefab(npcID));
        opponent.transform.position = opponentPos.position;
        opponent.transform.rotation = opponentPos.rotation;

        battleState = BattleState.BattleStart;
        timer = 1.5f;
    }

    private void BattleStart()
    {
        battleUI.SetTopPanelText("Battle Start!");
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            battleState = BattleState.PlayerTurnStart;
        }
    }

    private void PlayerTurnStart()
    {
        battleUI.SetTopPanelText("Your Turn!");
        battleUI.ShowPlayerSkillSelectionPanel();
        battleState = BattleState.PlayerTurn;
    }
}
