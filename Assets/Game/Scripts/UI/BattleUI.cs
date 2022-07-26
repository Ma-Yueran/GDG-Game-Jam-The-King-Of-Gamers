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

    private void Awake()
    {
        skillButtons = playerSkillSelectionPanel.GetComponentsInChildren<SkillButton>();
        foreach (SkillButton skillButton in skillButtons)
        {
            skillButton.gameObject.SetActive(false);
        }
        playerSkillSelectionPanel.SetActive(false);
    }

    public void SetUpPlayerSkills(List<Skill> skills)
    {
        for (int i = 0; i < skills.Count; i++)
        {
            skillButtons[i].SetUpButtonVisual(skills[i].skillName, skills[i].icon);
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

    public void SetPlayerHealthBar(float value)
    {
        playerHealthBar.value = value;
    }

    public void SetOpponentHealthBar(float value)
    {
        opponentHealthBar.value = value;
    }
}
