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

    private void Awake()
    {
        button = GetComponent<Button>();
        icon = GetComponentInChildren<Image>();
        description = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetUpButtonVisual(string description, Sprite icon)
    {
        this.description.text = description;
        this.icon.sprite = icon;
    }
}
