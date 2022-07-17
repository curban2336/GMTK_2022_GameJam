using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BaseCharacter
{
    // Fields
    private int damage;
    private int defense;
    private int healing;
    public List<BaseCharacter> enemyList;

    public PlayerSounds sounds;

    public BaseCharacter target;
    public EnemyManager manager;

    // Properties
    public int Damage { set { damage = value; } }
    public int Blocking { set { defense = value; } }
    public int Healing { set { healing = value; } }

    private void Awake()
    {
        totalD12s = 1;
        totalD8s = 1;
        totalD6s = 1;
        health = 100;
        title = "Pachyderm";
    }

    // Start is called before the first frame update
    void Start()
    {
        target = enemyList[0];
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TakeTurn()
    {
        sounds.Roar();
        // Call the actions in a specific order, Block, Attack, Abilitiy
        Defense(defense);
        HeadButt(target, damage);
        Special(healing);

        manager.eTurn = true;
    }
    private void HeadButt(BaseCharacter target, int damage)
    {
        sounds.Attack();
        self.GetComponent<Animator>().Play("Armature|Pachycephalasurus_HeadbuttCharged", 0, 0f);
        // We strike the enemy
        Strike(target, damage);
        
    }

    private void Defense(int defense)
    {
        sounds.Roar();
        block += defense;
    }

    private void Special(int healing)
    {
        sounds.Roar();
        //Player can't go above 100 in health
        health += healing;
        if(health > 100) { health = 100; }
        
    }
    protected override void TakeDamage(int damage)
    {
        // Call the Animation
        self.GetComponent<Animator>().Play("Armature|Pachycephalasaurus_IdleA 0 1 0 1", 0, 0f);
        base.TakeDamage(damage);
    }

    protected override void Death()
    {
        sounds.Death();
        // Call Death Animation
        base.Death();
    }
}
