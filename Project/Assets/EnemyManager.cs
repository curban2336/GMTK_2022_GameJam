using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<BaseCharacter> enemies;

    [SerializeField] Player player;

    // Start is called before the first frame update
    void Start()
    {
        player.enemyList = enemies;
    }

    public void TakeTurn()
    {
        foreach(Enemy giga in enemies){
            giga.TakeTurn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
