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

    //received information from cDice
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
        cDefault.SetActive(true);
        cDice.SetActive(false);
        cLoot.SetActive(false);
    }

    //Shift from default canvas to dice assignment.
    public void DefaultToDice()
    {
        sixTallyB = 0;
        eightTallyB = 0;
        twelveTallyB = 0;
        sixTallyAt = 0;
        eightTallyAt = 0;
        twelveTallyAt = 0;
        sixTallyAb = 0;
        eightTallyAb = 0;
        twelveTallyAb = 0;
        cDefault.SetActive(false);
        cDice.SetActive(true);
        cDice.GetComponent<CanvasDice>().sixTallyB = 0;
        cDice.GetComponent<CanvasDice>().eightTallyB = 0;
        cDice.GetComponent<CanvasDice>().twelveTallyB = 0;
        cDice.GetComponent<CanvasDice>().sixTallyAt = 0;
        cDice.GetComponent<CanvasDice>().eightTallyAt = 0;
        cDice.GetComponent<CanvasDice>().twelveTallyAt = 0;
        cDice.GetComponent<CanvasDice>().sixTallyAb = 0;
        cDice.GetComponent<CanvasDice>().eightTallyAb = 0;
        cDice.GetComponent<CanvasDice>().twelveTallyAb = 0;
    }

    //Shift from dice assignment back to default.
    public void DiceToDefault ()
    {
        cDefault.SetActive(true);
        sixTallyB = cDice.GetComponent<CanvasDice>().sixTallyB;
        eightTallyB = cDice.GetComponent<CanvasDice>().eightTallyB;
        twelveTallyB = cDice.GetComponent<CanvasDice>().twelveTallyB;
        sixTallyAt = cDice.GetComponent<CanvasDice>().sixTallyAt;
        eightTallyAt = cDice.GetComponent<CanvasDice>().eightTallyAt;
        twelveTallyAt = cDice.GetComponent<CanvasDice>().twelveTallyAt;
        sixTallyAb = cDice.GetComponent<CanvasDice>().sixTallyAb;
        eightTallyAb = cDice.GetComponent<CanvasDice>().eightTallyAb;
        twelveTallyAb = cDice.GetComponent<CanvasDice>().twelveTallyAb;
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
