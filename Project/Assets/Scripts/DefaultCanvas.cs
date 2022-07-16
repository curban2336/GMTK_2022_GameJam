using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultCanvas : MonoBehaviour
{
    //standard buttons
    [SerializeField] GameObject aDice;
    [SerializeField] GameObject eTurn;
    
    //references for dice roll results
    [SerializeField] GameObject dSix;
    [SerializeField] GameObject dSixText;
    [SerializeField] GameObject dEight;
    [SerializeField] GameObject dEightText;
    [SerializeField] GameObject dTwelve;
    [SerializeField] GameObject dTwelveText;
    [SerializeField] GameObject block;
    [SerializeField] GameObject blockText;
    [SerializeField] GameObject attack;
    [SerializeField] GameObject attackText;
    [SerializeField] GameObject ability;
    [SerializeField] GameObject abilityText;

    //reference to canvas manager
    [SerializeField] GameObject manager;

    //reference to canvas manager
    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        dSix.SetActive(false);
        dSixText.SetActive(false);
        dEight.SetActive(false);
        dEightText.SetActive(false);
        dTwelve.SetActive(false);
        dTwelveText.SetActive(false);
        block.SetActive(false);
        blockText.SetActive(false);
        attack.SetActive(false);
        attackText.SetActive(false);
        ability.SetActive(false);
        abilityText.SetActive(false);

        aDice.SetActive(true);
        eTurn.SetActive(true);
    }

    //End turn and begin dice roll result procedure
    public void EndTurn()
    {
        dSix.SetActive(true);
        dSixText.SetActive(true);
        dEight.SetActive(true);
        dEightText.SetActive(true);
        dTwelve.SetActive(true);
        dTwelveText.SetActive(true);
        block.SetActive(true);
        blockText.SetActive(true);
        attack.SetActive(true);
        attackText.SetActive(true);
        ability.SetActive(true);
        abilityText.SetActive(true);

        aDice.SetActive(false);
        eTurn.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
