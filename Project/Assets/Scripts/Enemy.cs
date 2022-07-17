using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : BaseCharacter
{
    // Fields
    protected Type.Mood currentMood;
    protected int blockRoll;
    protected Player player;

    // Properties
    public Type.Mood CurrentMood { get { return currentMood; } }

    private void Awake()
    {
        // Initializing fields
        totalD6s = 3;
        totalD8s = 2;

        // Enemies only have d8s and d6s
        totalD12s = 0;
        // Player starts with 1 of each die, so in a perfect full attack they will one shot one robot per round
        health = 28;
        title = "Gigabyte";
        // Decide the starting mood
        currentMood = ChangeMood();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Start of the turn it will clear it's attack
        attack = 0;
        // On the enemies turn it will Fight based off of mood, then it will change mood
        Fight();
        Animations();
        currentMood = ChangeMood();
    }

    protected void Fight()
    {
        // Determine action based on mood
        switch (currentMood)
        {
            case Type.Mood.MediumAttack:
                {
                    // Roll all the d8s to deal damage
                    attack = AllD8s();
                    Strike(player, attack);
                    break;
                }
            case Type.Mood.BigAttack:
                {
                    // Roll all Dice and add them together
                    attack = AllD6s();
                    attack = attack + AllD8s();
                    Strike(player, attack);
                    break;
                }
            case Type.Mood.Block:
                {
                    // Roll All Dice and apply them to block
                    block += AllD8s();
                    block += AllD6s();
                    break;
                }
            case Type.Mood.BlockAttack:
                {
                    // Roll D6s for damage & d8s for block
                    attack = AllD6s();
                    block += AllD8s();
                    Strike(player, attack);
                    break;
                }
            case Type.Mood.MultiAttack:
                {
                    // Max amount is 10 dice in an attack
                    int numOfDice = 10;
                    int numOfD6 = 0;
                    int numOfD8 = 0;
                    // Make sure you can't get more than 10 of either die
                    if(totalD6s > 10)
                    {
                        numOfD6 = Random.Range(1, 11);
                        numOfDice = numOfDice - numOfD6;
                    }
                    else
                    {
                        // Less than 10 for d6s
                        numOfD6 = Random.Range(1, totalD6s+1);
                        numOfDice = numOfDice - numOfD6;
                    }

                    //Then decide How many d8s it will roll
                    if(totalD8s < numOfDice)
                    {
                        numOfD8 = totalD8s;
                    }
                    else
                    {
                        numOfD8 = numOfDice;
                    }

                    // Strike the target for the d6s and d8s
                    for(int i = 0; i < numOfD6; i++)
                    {
                        Strike(player, RollD6s());
                    }

                    // Strike for the D8s
                    for(int i = 0; i < numOfD8; i++)
                    {
                        Strike(player, RollD8s());
                    }

                    break;
                }
                
        }
    }

    private Type.Mood ChangeMood()
    {
        // The probablities change based on the quarter of health it has
        int choice = Random.Range(1, 21);
        // 75% or more health
        if (health >= 21)
        {
            
            if (choice < 19 && choice > 16)
            {
                // Block
                return Type.Mood.Block;
            }
            else if(choice >= 19)
            {
                //Block Attack
                return Type.Mood.BlockAttack;
            }
            else if(choice >= 9 && choice < 17)
            {
                // Medium Attack
                return Type.Mood.MediumAttack;
            }
            else if(choice > 2 && choice <= 8)
            {
                // Multi Attack
                return Type.Mood.MultiAttack;
            }
            else
            {
                // Big Attack
                return Type.Mood.BigAttack;
            }
        }
        else if(health >= 14 && health < 21)
        {
            if(choice >= 17)
            {
                //Block
                return Type.Mood.Block;
            }
            else if (choice >= 13 && choice < 17)
            {
                return Type.Mood.BlockAttack;
            }
            else if (choice >= 7 && choice < 13)
            {
                return Type.Mood.MediumAttack;
            }
            else if(choice >= 3 && choice < 7)
            {
                return Type.Mood.MultiAttack;
            }
            else
            {
                return Type.Mood.BigAttack;
            }
        }
        else if(health >= 7 && health < 14)
        {
            if(choice >= 16)
            {
                return Type.Mood.Block;
            }
            else if(choice >= 11 && choice < 16)
            {
                return Type.Mood.BlockAttack;
            }
            else if(choice >= 6 && choice < 11)
            {
                return Type.Mood.MediumAttack;
            }
            else if(choice >= 3 && choice < 6)
            {
                return Type.Mood.MultiAttack;
            }
            else
            {
                return Type.Mood.BigAttack;
            }
        }
        else
        {
            if (choice >= 15)
            {
                return Type.Mood.Block;
            }
            else if(choice >= 9 && choice < 15)
            {
                return Type.Mood.BlockAttack;
            }
            else if(choice >= 5 && choice < 9)
            {
                return Type.Mood.MediumAttack;
            }
            else if(choice >= 3 && choice < 5)
            {
                return Type.Mood.MultiAttack;
            }
            else
            {
                return Type.Mood.BigAttack;
            }
        }
    }

    /// <summary>
    /// Rolls all the D6s and adds the total
    /// </summary>
    /// <returns> total of the dice roll</returns>
    protected int AllD6s()
    {
        int value = 0;
        for(int i = 0; i < totalD6s; i++)
        {
            value = value + RollD6s();
        }
        return value;
    }
    protected int AllD8s()
    {
        int value = 0;
        for(int i = 0; i < totalD8s; i++)
        {
            value = value + RollD8s();
        }
        return value;
    }

    protected void Animations()
    {
        // Checks what mood the Enemy is in and then calls animations based on the mood
        switch (currentMood)
        {
            case Type.Mood.BigAttack:
            {
                    BigAttackAnimation();
                break;
            }
            case Type.Mood.Block:
            {
                    BlockAnimation();
                break;
            }
            case Type.Mood.MediumAttack:
            {
                    MediumAttackAnimation();
                break;
            }
            case Type.Mood.BlockAttack:
            {
                    BlockAttackAnimation();
                break;
            }
            case Type.Mood.MultiAttack:
            {
                    MultiAttackAnimation();
                break;
            }
        }
    }
    protected void BlockAnimation()
    {
        // Call the Animation for Block
        self.GetComponent<Animator>().Play("Idle_Ducking_AR", 0, 0f);
    }
    protected void BlockAttackAnimation()
    {
        // Call the Animation (probaby Idle Shoot)
        self.GetComponent<Animator>().Play("Idle_Ducking_AR", 0, 0f);
        self.GetComponent<Animator>().Play("Shoot_SingleShot_AR", 0, 0f);
    }
    protected void MediumAttackAnimation()
    {
        // Call The Animation
        self.GetComponent<Animator>().Play("Shoot_SingleShot_AR", 0, 0f);
    }
    protected void BigAttackAnimation()
    {
        self.GetComponent<Animator>().Play("Shoot_BurstShot_AR", 0, 0f);
    }
    protected void MultiAttackAnimation()
    {
        self.GetComponent<Animator>().Play("Shoot_Autoshot_AR", 0, 0f);
    }

    protected override void Death()
    {
        // Call the Death Animation
        self.GetComponent<Animator>().Play("Die", 0, 0f);
        base.Death();
        
    }
    protected override void TakeDamage(int damage)
    {
        self.GetComponent<Animator>().Play("Die", 0, 0f);
        base.TakeDamage(damage);
    }
}
