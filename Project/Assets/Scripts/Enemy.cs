using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : BaseCharacter
{
    // Fields
    protected Type.Mood currentMood;
    protected int blockRoll;
    protected BaseCharacter player;

    // Properties
    public Type.Mood CurrentMood { get { return currentMood; } }

    // Start is called before the first frame update
    void Start()
    {
        // Enemies only have d8s and d6s
        totalD12s = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
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
                    break;
                }
            case Type.Mood.Block:
                {
                    // Roll All Dice and apply them to block
                    block = block + AllD8s();
                    block = block + AllD6s();
                    break;
                }
            case Type.Mood.BlockAttack:
                {
                    // Roll D6s for damage & d8s for block
                    attack = AllD6s();
                    block = block + AllD8s();
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
                    if(totalD8s > 10)
                    {
                        numOfD8 = 10 - numOfDice;
                    }
                    else
                    {
                        if((10 - numOfDice) >= totalD8s)
                        {
                            numOfD8 = totalD8s;
                        }
                        else
                        {
                            numOfD8 = 10 - numOfDice;
                        }
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
}
