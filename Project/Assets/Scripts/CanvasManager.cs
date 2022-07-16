using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    //Serialized
    //canvas
    [SerializeField] GameObject cDefault;
    [SerializeField] GameObject cDice;
    [SerializeField] GameObject cLoot;



    // Start is called before the first frame update
    void Start()
    {
        cDefault.SetActive(true);
        cDice.SetActive(false);
        cLoot.SetActive(false);
    }

    //Shift from default canvas to dice assignment.
    public void DefaultToDice()
    {
        cDefault.SetActive(false);
        cDice.SetActive(true);
    }

    //Shift from dice assignment back to default.
    public void DiceToDefault ()
    {
        cDefault.SetActive(true);
        cDice.SetActive(false);
    }

    //Shift from default to loot assignment.
    public void DefaultToLoot()
    {
        cDefault.SetActive(false);
        cLoot.SetActive(true);
    }

    //Shift from loot assignment back to default.
    public void LootToDefault()
    {
        cDefault.SetActive(true);
        cLoot.SetActive(false);
    }
}
