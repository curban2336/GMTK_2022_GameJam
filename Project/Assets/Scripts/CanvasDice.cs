using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasDice : MonoBehaviour
{
    //counts for each of the dice types
    [SerializeField] GameObject sixCount;
    [SerializeField] GameObject eightCount;
    [SerializeField] GameObject twelveCount;

    //action references for selection
    [SerializeField] GameObject block;
    [SerializeField] GameObject attack;
    [SerializeField] GameObject ability;

    //action dice tally references
    [SerializeField] GameObject tBlock;
    [SerializeField] GameObject tAttack;
    [SerializeField] GameObject tAbility;

    // player reference
    [SerializeField] GameObject player;

    [SerializeField] GameObject currentTally;

    //current number of dice left 
    [SerializeField] int sixNum;
    [SerializeField] int eightNum;
    [SerializeField] int twelveNum;

    //current number of dice in an action 
    public int sixTallyB = 0;
    public int eightTallyB = 0;
    public int twelveTallyB = 0;
    public int sixTallyAt = 0;
    public int eightTallyAt = 0;
    public int twelveTallyAt = 0;
    public int sixTallyAb = 0;
    public int eightTallyAb = 0;
    public int twelveTallyAb = 0;



    // Start is called before the first frame update
    void Start()
    {
        sixNum = player.GetComponent<Player>().TotalD6s;
        eightNum = player.GetComponent<Player>().TotalD8s;
        twelveNum = player.GetComponent<Player>().TotalD12s;
        sixCount.GetComponent<Text>().text = ($"{player.GetComponent<Player>().TotalD6s}");
        eightCount.GetComponent<Text>().text = ($"{player.GetComponent<Player>().TotalD8s}");
        twelveCount.GetComponent<Text>().text = ($"{player.GetComponent<Player>().TotalD12s}");
        currentTally = tBlock;
    }

    //add one d12 to the selected action
    public void AddSix()
    {
        if(sixNum <= 0)
        {

        }
        else
        {
            sixNum -= 1;
            if (currentTally == tBlock)
            {
                sixTallyB += 1;
                currentTally.GetComponent<Text>().text = ($"D6: {sixTallyB} D8: {eightTallyB} D12: {twelveTallyB}");
            }
            else if(currentTally == tAttack)
            {
                sixTallyAt += 1;
                currentTally.GetComponent<Text>().text = ($"D6: {sixTallyAt} D8: {eightTallyAt} D12: {twelveTallyAt}");
            }
            else
            {
                sixTallyAb += 1;
                currentTally.GetComponent<Text>().text = ($"D6: {sixTallyAb} D8: {eightTallyAb} D12: {twelveTallyAb}");
            }
        }
        sixCount.GetComponent<Text>().text = ($"{sixNum}");
    }

    //add one d12 to the selected action
    public void AddEight()
    {
        if(eightNum <= 0)
        {

        }
        else
        {
            eightNum -= 1;
            if (currentTally == tBlock)
            {
                eightTallyB += 1;
                currentTally.GetComponent<Text>().text = ($"D6: {sixTallyB} D8: {eightTallyB} D12: {twelveTallyB}");
            }
            else if (currentTally == tAttack)
            {
                eightTallyAt += 1;
                currentTally.GetComponent<Text>().text = ($"D6: {sixTallyAt} D8: {eightTallyAt} D12: {twelveTallyAt}");
            }
            else
            {
                eightTallyAb += 1;
                currentTally.GetComponent<Text>().text = ($"D6: {sixTallyAb} D8: {eightTallyAb} D12: {twelveTallyAb}");
            }
        }
        eightCount.GetComponent<Text>().text = ($"{eightNum}");
    }

    //add one d12 to the selected action
    public void AddTwelve()
    {
        if (twelveNum <= 0)
        {

        }
        else
        {
            twelveNum -= 1;
            if (currentTally == tBlock)
            {
                twelveTallyB += 1;
                currentTally.GetComponent<Text>().text = ($"D6: {sixTallyB} D8: {eightTallyB} D12: {twelveTallyB}");
            }
            else if (currentTally == tAttack)
            {
                twelveTallyAt += 1;
                currentTally.GetComponent<Text>().text = ($"D6: {sixTallyAt} D8: {eightTallyAt} D12: {twelveTallyAt}");
            }
            else
            {
                twelveTallyAb += 1;
                currentTally.GetComponent<Text>().text = ($"D6: {sixTallyAb} D8: {eightTallyAb} D12: {twelveTallyAb}");
            }
        }
        twelveCount.GetComponent<Text>().text = ($"{twelveNum}");
    }

    //remove one d6 to the selected action
    public void MinusSix()
    {
        if (sixNum >= player.GetComponent<Player>().TotalD6s)
        {

        }
        else
        {
            sixNum += 1;
            if (currentTally == tBlock)
            {
                sixTallyB -= 1;
                currentTally.GetComponent<Text>().text = ($"D6: {sixTallyB} D8: {eightTallyB} D12: {twelveTallyB}");
            }
            else if (currentTally == tAttack)
            {
                sixTallyAt -= 1;
                currentTally.GetComponent<Text>().text = ($"D6: {sixTallyAt} D8: {eightTallyAt} D12: {twelveTallyAt}");
            }
            else
            {
                sixTallyAb -= 1;
                currentTally.GetComponent<Text>().text = ($"D6: {sixTallyAb} D8: {eightTallyAb} D12: {twelveTallyAb}");
            }
        }
        sixCount.GetComponent<Text>().text = ($"{sixNum}");
    }

    //remove one d8 to the selected action
    public void MinusEight()
    {
        if (eightNum >= player.GetComponent<Player>().TotalD8s)
        {

        }
        else
        {
            eightNum += 1;
            if (currentTally == tBlock)
            {
                eightTallyB -= 1;
                currentTally.GetComponent<Text>().text = ($"D6: {sixTallyB} D8: {eightTallyB} D12: {twelveTallyB}");
            }
            else if (currentTally == tAttack)
            {
                eightTallyAt -= 1;
                currentTally.GetComponent<Text>().text = ($"D6: {sixTallyAt} D8: {eightTallyAt} D12: {twelveTallyAt}");
            }
            else
            {
                eightTallyAb -= 1;
                currentTally.GetComponent<Text>().text = ($"D6: {sixTallyAb} D8: {eightTallyAb} D12: {twelveTallyAb}");
            }
        }
        eightCount.GetComponent<Text>().text = ($"{eightNum}");
    }

    //remove one d12 to the selected action
    public void MinusTwelve()
    {
        if (twelveNum >= player.GetComponent<Player>().TotalD12s)
        {

        }
        else
        {
            twelveNum += 1;
            if (currentTally == tBlock)
            {
                twelveTallyB -= 1;
                currentTally.GetComponent<Text>().text = ($"D6: {sixTallyB} D8: {eightTallyB} D12: {twelveTallyB}");
            }
            else if (currentTally == tAttack)
            {
                twelveTallyAt -= 1;
                currentTally.GetComponent<Text>().text = ($"D6: {sixTallyAt} D8: {eightTallyAt} D12: {twelveTallyAt}");
            }
            else
            {
                twelveTallyAb -= 1;
                currentTally.GetComponent<Text>().text = ($"D6: {sixTallyAb} D8: {eightTallyAb} D12: {twelveTallyAb}");
            }
        }
        twelveCount.GetComponent<Text>().text = ($"{twelveNum}");
    }

    //when the block action is selected
    public void BlockSelect()
    {
        block.GetComponent<Text>().color = new Color(1f, 1f, 1f);
        attack.GetComponent<Text>().color = new Color(0f, 0f, 0f);
        ability.GetComponent<Text>().color = new Color(0f, 0f, 0f);
        currentTally = tBlock;
    }

    //when the attack action is selected
    public void AttackSelect()
    {
        block.GetComponent<Text>().color = new Color(0f, 0f, 0f);
        attack.GetComponent<Text>().color = new Color(1f, 1f, 1f);
        ability.GetComponent<Text>().color = new Color(0f, 0f, 0f);
        currentTally = tAttack;
    }

    //when the ability action is selected
    public void AbilitySelect()
    {
        block.GetComponent<Text>().color = new Color(0f, 0f, 0f);
        attack.GetComponent<Text>().color = new Color(0f, 0f, 0f);
        ability.GetComponent<Text>().color = new Color(1f, 1f, 1f);
        currentTally = tAbility;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
