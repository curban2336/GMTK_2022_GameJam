using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{

    // This is the base class for all characters, Player & Enemies

    // Public
    public int Health { get { return health; } }
    public int Block { get { return block; } }
    public int Attack { get { return attack; } }
    public string Name { get { return title; } }
    public int TotalD6s { get { return totalD6s; } }
    public int TotalD8s { get { return totalD8s; } }
    public int TotalD12s { get { return totalD12s; } }


    // Protected
    protected int health;
    protected int block;
    protected int attack;
    protected int totalD6s;
    protected int totalD8s;
    protected int totalD12s;
    protected string title;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// Used to attack target character
    /// </summary>
    /// <param name="target"> The character being hit</param>
    /// <param name="damage"> Damage applied, Players apply attack, enemies vary on mood</param>
    protected void Strike(BaseCharacter target, int damage)
    {
        target.TakeDamage(damage);
    }

    /// <summary>
    /// Reduces health by the damage, checks if the character should die
    /// </summary>
    /// <param name="damage"> The ammount of damage taken</param>
    protected void TakeDamage(int damage)
    {
        if(block > 0)
        {
            // Reduce the amount of damage by the block amount
            damage = damage - block;
            if(damage < 0)
            {
                damage = 0;
            }

            // Reduce block by the damage prevented, set to 0 if negative
            block = block - damage;
            if(block < 0)
            {
                block = 0;
            }
        }

        // Block is resolved now deal with any over flow
        health = health - damage;

        if(health <= 0)
        {
            Death();
        }
    }

    protected void CleanUp()
    {
        // At the end of the round do some clean up to make sure everything is good
        // Reset attack value
        attack = 0;

        // Block stays between rounds
        // Check health
        if(health <= 0)
        {
            Death();
        }
    }

    protected void Death()
    {
        if(health <= 0)
        {
            // Destroys the object?
        }
    }

    public int RollD6s()
    {
        return Random.Range(1, 7);
    }
    public int RollD8s()
    {
        return Random.Range(1, 9);
    }
    public int RollD12s()
    {
        return Random.Range(1, 13);
    }
}
