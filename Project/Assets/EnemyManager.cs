using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<BaseCharacter> enemies;

    [SerializeField] List<GameObject> enemyPos;

    [SerializeField] GameObject enemy;
    [SerializeField] GameObject e1Health;
    [SerializeField] GameObject e2Health;
    [SerializeField] GameObject e3Health;
    [SerializeField] Transform pos1;
    [SerializeField] Transform pos2;
    [SerializeField] Transform pos3;

    [SerializeField] private bool walkUpOne = false;
    private bool walkUpTwo = false;
    public bool eTurn = false;

    [SerializeField] Player player;

    public DefaultCanvas canvas;

    public GameObject victory;

    void Awake()
    {
        player.enemyList = enemies;
        e1Health.SetActive(false);
        e2Health.SetActive(false);
        e3Health.SetActive(false);
    }

    void Start()
    {
        EncounterOne();
    }

    public void EncounterOne()
    {
        walkUpOne = true;
        e1Health.SetActive(true);
    }

    public void EncounterTwo()
    {
        walkUpTwo = true;
        e2Health.SetActive(true);
        e3Health.SetActive(true);
        e1Health.SetActive(false);
    }

    public void TakeTurn()
    {
        foreach(Enemy giga in enemies){
            giga.TakeTurn();
        }
        eTurn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (walkUpOne)
        {
            if (enemyPos[0].transform.position.x >= pos1.position.x+0.01)
            {
                enemyPos[0].transform.position = Vector3.Lerp(enemyPos[0].transform.position, pos1.position, 1f * Time.deltaTime);
            }
            else
            {
                walkUpOne = false;
            }
        }
        if (walkUpTwo)
        {
            if (enemyPos[1].transform.position.x >= pos2.position.x + 0.01)
            {
                enemyPos[1].transform.position = Vector3.Lerp(enemyPos[1].transform.position, pos2.position, 1f * Time.deltaTime);
                enemyPos[2].transform.position = Vector3.Lerp(enemyPos[2].transform.position, pos3.position, 1.5f * Time.deltaTime);
            }
            else
            {
                walkUpTwo = false;
            }
            
        }

        if (eTurn)
        {
            TakeTurn();
        }

        if (enemies[0].dead)
        {
            EncounterTwo();
            player.target = player.enemyList[1];
        }
        if (enemies[1].dead)
        {
            player.target = player.enemyList[2];
        }
        if (enemies[1].dead && enemies[2].dead)
        {
            victory.SetActive(true);
            canvas.victory = true;
        }

    }
}
