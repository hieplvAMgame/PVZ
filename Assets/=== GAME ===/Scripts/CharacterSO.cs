using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Create Data Character", fileName = "New CharacterSO")]
public class CharacterSO : ScriptableObject
{
    public bool canAttack = false;
    public int hp;
    [ShowIf(nameof(canAttack))]
    public CharacterInfo info;

    int currentHP = 0;

    public void Init() => currentHP = hp;
    Action onDie = null;

    public void OnDie(Action onDie) => this.onDie = onDie;
    public void MinusHp(int value)
    {
        currentHP -= value;
        if (currentHP <= 0)
        {
            currentHP = 0;
            onDie?.Invoke();
        }
    }

}
[System.Serializable]
public class CharacterInfo
{
    public int damage;
    public float radiusAttack;
    public float moveSpeed;
}