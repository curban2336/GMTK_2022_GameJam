using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasLoot : MonoBehaviour
{
    //loot buttons
    [SerializeField] GameObject lootOne;
    [SerializeField] GameObject lootTwo;
    [SerializeField] GameObject lootOneText;
    [SerializeField] GameObject lootTwoText;

    //reference to player
    [SerializeField] GameObject player;

    //list of dice images
    [SerializeField] List<Sprite> dice;

    //chance for better dice so odds can improve as time goes on
    public int sixChance;
    public int eightChance;
    public int twelveCount;

    //checks to prevent repeat dice loot
    private bool dSix = false;
    private bool dEight = false;
    private bool dTwelve = false;

    private int num1;
    private int num2;

    // Start is called before the first frame update
    void Start()
    {
        sixChance = 6;
        eightChance = 10;
        twelveCount = 1;
        num1 = 0;
        num2 = 0;
    }

    //generates loot for victory in combat
    public void LootGenerator()
    {
        //what kind of die
        int chance = Random.Range(1,10);

        if(chance <= sixChance)
        {
            num1 = Random.Range(1,4);
            lootOne.GetComponent<Image>().sprite = dice[0];
            lootOneText.GetComponent<Text>().text = ($"{num1} D6");
            dSix = true;
        }
        else if(chance <= eightChance)
        {
            num1 = Random.Range(1,2);
            lootOne.GetComponent<Image>().sprite = dice[1];
            lootOneText.GetComponent<Text>().text = ($"{num1} D8");
            dEight = true;
        }
        else
        {
            num1 = twelveCount;
            lootOne.GetComponent<Image>().sprite = dice[2];
            lootOneText.GetComponent<Text>().text = ($"{num1} D12");
            dTwelve = true;
        }

        chance = Random.Range(1, 10);
        if (chance <= sixChance - 3 && dSix == false)
        {
            num2 = Random.Range(1,4);
            lootTwo.GetComponent<Image>().sprite = dice[0];
            lootTwoText.GetComponent<Text>().text = ($"{num2} D6");
        }
        else if (chance <= eightChance - 2 && dEight == false)
        {
            num2 = Random.Range(1,2);
            lootTwo.GetComponent<Image>().sprite = dice[1];
            lootTwoText.GetComponent<Text>().text = ($"{num2} D8");
        }
        else
        {
            if (dTwelve == false)
            {
                num2 = twelveCount;
                lootTwo.GetComponent<Image>().sprite = dice[2];
                lootTwoText.GetComponent<Text>().text = ($"{num2} D12");
            }
            else
            {
                LootGenerator();
            }
        }
        dTwelve = false;
        dSix = false;
        dEight = false;

    }

    //add choice one to the players total for that dice type
    public void AddOne()
    {
        if(lootOne.GetComponent<Image>().sprite = dice[0])
        {
            player.GetComponent<Player>().totalD6s += num1;
        }
        else if (lootOne.GetComponent<Image>().sprite = dice[1])
        {
            player.GetComponent<Player>().totalD8s += num1;
        }
        else if (lootOne.GetComponent<Image>().sprite = dice[2])
        {
            player.GetComponent<Player>().totalD12s += num1;
        }
    }

    //add choice two to the players total for that dice type
    public void AddTwo()
    {
        if (lootTwo.GetComponent<Image>().sprite = dice[0])
        {
            player.GetComponent<Player>().totalD6s += num1;
        }
        else if (lootTwo.GetComponent<Image>().sprite = dice[1])
        {
            player.GetComponent<Player>().totalD8s += num1;
        }
        else if (lootTwo.GetComponent<Image>().sprite = dice[2])
        {
            player.GetComponent<Player>().totalD12s += num1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
