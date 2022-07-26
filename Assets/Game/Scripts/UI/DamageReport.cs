using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageReport : MonoBehaviour
{
    public GameObject reportUI;

    private TextMeshProUGUI text;
    private float timer = 0f;

    private void Awake()
    {
        text = reportUI.GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            reportUI.SetActive(false);
        }
    }

    public void ShowDamageReport(string text, float duration)
    {
        this.text.text = text;
        timer = duration;
        reportUI.SetActive(true);
    }
}
