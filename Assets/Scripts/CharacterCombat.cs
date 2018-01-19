﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharStats))]
public class CharacterCombat : MonoBehaviour {
    public float attackSpeed = 1f;
    private float attackCooldown = 0f;
    CharStats myStats;
    public float attackDelay = 0.5f;

    public event System.Action OnAttack;


    private void Start()
    {
        myStats = GetComponent<CharStats>();
    }

    private void Update()
    {
        attackCooldown = Time.deltaTime;
    }

    public void Attack(CharStats targetStats)
    {
        if (attackCooldown <= 0f)
        {
            StartCoroutine(DoDamage(targetStats, attackDelay));

            if (OnAttack != null)
            {
                OnAttack();
            }

            attackCooldown = 1f / attackSpeed; 

        }
    }

    IEnumerator DoDamage(CharStats stats, float delay)
    {
        yield return new WaitForSeconds(delay);
        stats.TakeDamage(myStats.damage.GetValue());
    }
}
