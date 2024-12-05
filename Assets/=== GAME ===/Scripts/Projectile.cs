using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    CharacterSO dataOwner;
    float moveSpeed;
    Vector2 dir;
    public void Setup(Vector2 direction, float speed, CharacterSO data)
    {
        dir = direction;
        moveSpeed = speed;
        dataOwner = data;
    }
    private void Update()
    {
        transform.Translate(dir * moveSpeed * Time.deltaTime);
    }
    public int GetDamage => dataOwner.info.damage;
}
