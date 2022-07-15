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
    public string Name { get { return name; } }

    // Protected
    protected int health;
    protected int block;
    protected int attack;
    protected int totalD6s;
    protected int totalD8s;
    protected int totalD10s;
    protected string name;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// Used to attack and damage the targeted character
    /// </summary>
    /// <param name="target"> The character being attacked</param>
    protected void Strike(BaseCharacter target)
    {
        target.TakeDamage(attack);
    }

    /// <summary>
    /// Reduces health by the damage, checks if the character should die
    /// </summary>
    /// <param name="damage"> The ammount of damage taken</param>
    private void TakeDamage(int damage)
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

    protected void Death()
    {
        if(health <= 0)
        {
            // Destroys the object?
        }
    }
}
