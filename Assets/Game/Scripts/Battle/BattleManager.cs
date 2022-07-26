using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public Transform playerPos;
    public Transform opponentPos;
    public BattleUI battleUI;

    private enum BattleState { BattleStart, PlayerTurnStart, PlayerTurn, PlayerTurnEnd, OpponentTurnStart, OpponentTurn }
    private BattleState battleState = BattleState.BattleStart;

    private Player player;
    private Opponent opponent;

    private float timer;

    public static BattleManager Instance;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        Init();
    }

    private void Update()
    {
        battleUI.SetPlayerHealthBar(player.GetCurrentHealthPercentage());
        battleUI.SetOpponentHealthBar(opponent.GetCurrentHealthPercentage());

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
            case BattleState.PlayerTurnEnd:
                PlayerTurnEnd();
                break;
            case BattleState.OpponentTurnStart:
                break;
            case BattleState.OpponentTurn:
                break;
        }
    }

    public void PlayerUseSkill(Skill skill)
    {
        if (battleState != BattleState.PlayerTurn)
        {
            Debug.LogError("Player Use Skill called not in player turn");
            return;
        }

        battleUI.HidePlayerSkillSelectionPanel();

        battleUI.SetTopPanelText("You used " + skill.skillName + "!");

        Damage rawDamage = player.CalculateSkillRawDamage(skill);
        float actualDamage = opponent.TakeDamage(rawDamage);
        
        battleUI.ShowOpponentTakeDamage(actualDamage);

        battleState = BattleState.PlayerTurnEnd;
        timer = 1.5f;
    }

    private void Init()
    {
        player = Instantiate(GameManager.Instance.playerPrefab);
        player.isInBattle = true;
        player.transform.position = playerPos.position;
        player.transform.rotation = playerPos.rotation;
        player.SetToFullHealth();

        battleUI.SetUpPlayerSkills(player.skills);

        int npcID = SaveSystem.LoadOpponentData().npcID;

        opponent = Instantiate(GameManager.Instance.OpponentRegistry.GetOpponentPrefab(npcID));
        opponent.transform.position = opponentPos.position;
        opponent.transform.rotation = opponentPos.rotation;
        opponent.SetToFullHealth();

        battleState = BattleState.BattleStart;
        timer = 1f;
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

    private void PlayerTurnEnd()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            battleState = BattleState.PlayerTurnStart;
        }
    }

    public void BattleEnds()
    {
        GameManager.Instance.BackToPreviousScene();
    }
}
