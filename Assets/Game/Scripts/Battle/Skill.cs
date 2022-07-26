using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skill", menuName = "ScriptableObjects/Skill")]
public class Skill : ScriptableObject
{
    public string skillName;
    public Sprite icon;
    public float strengthMultiplier;
    public float intelligenceMultiplier;
    public float luckMultiplier;
}
