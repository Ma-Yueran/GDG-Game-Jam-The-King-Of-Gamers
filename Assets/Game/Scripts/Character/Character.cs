using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage
{
    public float strengthDamage;
    public float intelligenceDamage;
    public float luckDamage;

    public Damage(float strengthDamage, float intelligenceDamage, float luckDamage)
    {
        this.strengthDamage = strengthDamage;
        this.intelligenceDamage = intelligenceDamage;
        this.luckDamage = luckDamage;
    }
}

public class Character : MonoBehaviour
{
    public float strength;
    public float intelligence;
    public float luck;
    public float maxHealth;
    public float resistence;
    public List<Skill> skills;

    private float currentHealth;

    public void SetToFullHealth()
    {
        currentHealth = maxHealth;
    }

    public Damage CalculateSkillRawDamage(Skill skill)
    {
        return new Damage(
            skill.strengthMultiplier * strength, 
            skill.intelligenceMultiplier * intelligence, 
            skill.luckMultiplier * luck
            );
    }

    public float TakeDamage(Damage rawDamage)
    {
        float strengthDamage = Mathf.Max(1, rawDamage.strengthDamage - strength * resistence);
        float intelligenceDamage = Mathf.Max(1, rawDamage.intelligenceDamage - intelligence * resistence);
        float luckDamage = Mathf.Max(1, rawDamage.luckDamage - luck * resistence);

        float actualDamage = strengthDamage + intelligenceDamage + luckDamage;
        currentHealth -= actualDamage;

        return actualDamage;
    }

    public float GetCurrentHealthPercentage()
    {
        return Mathf.Clamp01(currentHealth / maxHealth);
    }
}
