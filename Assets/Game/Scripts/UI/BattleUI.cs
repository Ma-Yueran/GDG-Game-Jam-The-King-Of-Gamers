using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour
{
    public TextMeshProUGUI topPanelText;
    public GameObject playerSkillSelectionPanel;
    
    public Slider playerHealthBar;
    public Slider opponentHealthBar;

    private SkillButton[] skillButtons;
    private DamageReport damageReport;

    private void Awake()
    {
        skillButtons = playerSkillSelectionPanel.GetComponentsInChildren<SkillButton>();
        foreach (SkillButton skillButton in skillButtons)
        {
            skillButton.gameObject.SetActive(false);
        }
        playerSkillSelectionPanel.SetActive(false);

        damageReport = GetComponentInChildren<DamageReport>();
    }

    public void SetUpPlayerSkills(List<Skill> skills)
    {
        for (int i = 0; i < skills.Count; i++)
        {
            skillButtons[i].BindSkill(skills[i]);
            skillButtons[i].gameObject.SetActive(true);
        }
    }

    public void SetTopPanelText(string text)
    {
        topPanelText.text = text;
    }

    public void ShowPlayerSkillSelectionPanel()
    {
        playerSkillSelectionPanel.SetActive(true);
    }

    public void HidePlayerSkillSelectionPanel()
    {
        playerSkillSelectionPanel.SetActive(false);
    }

    public void ShowOpponentTakeDamage(float damage)
    {
        string damageText = "Opponent Takes " + damage + " Damage!";
        damageReport.ShowDamageReport(damageText, 1.5f);
    }

    public void SetPlayerHealthBar(float value)
    {
        playerHealthBar.value = value;
    }

    public void SetOpponentHealthBar(float value)
    {
        opponentHealthBar.value = value;
    }
}
