using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CS_Range
{
    public int minNum;
    public int maxNum;
}

public class Character : MonoBehaviour
{
    [Range(0, 255)] public int BaseAttack;
    [Range(0, 99)] public int swordAttack;
    [Range(0, 99)] public int Defensive;

    [HideInInspector] public int hp = 100;
    [HideInInspector] public int propsNum = 5;

    [HideInInspector] public CS_Range PowerNum;
    public int ATTACK
    {
        get
        {
            int attack = BaseAttack + Mathf.FloorToInt(BaseAttack * (swordAttack - Defensive - 8) / 16);
            return attack < 0 ? 0 : attack;
        }
    }
}