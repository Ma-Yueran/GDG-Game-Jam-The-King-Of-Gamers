using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillButton : MonoBehaviour
{
    private Button button;
    private Image icon;
    private TextMeshProUGUI description;

    private Skill skill;

    private void Awake()
    {
        button = GetComponent<Button>();
        icon = GetComponentInChildren<Image>();
        description = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void BindSkill(Skill skill)
    {
        this.skill = skill;

        description.text = skill.skillName;
        icon.sprite = skill.icon;
        button.onClick.AddListener(delegate { UseSkill(); });
    }

    public void UseSkill()
    {
        BattleManager.Instance.PlayerUseSkill(skill);
    }
}
