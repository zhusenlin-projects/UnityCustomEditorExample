using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Range(0, 255)] public int BaseAttack;
    [Range(0, 99)] public int swordAttack;
    [Range(0, 99)] public int Defensive;

    public int ATTACK
    {
        get
        {
            int attack = BaseAttack + Mathf.FloorToInt(BaseAttack * (swordAttack - Defensive - 8) / 16);
            return attack < 0 ? 0 : attack;
        }
    }
}