using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    //bools to help handle rotations
    [SerializeField] bool sixRoll = false;
    [SerializeField] bool eightRoll = false;
    [SerializeField] bool twelveRoll = false;

    //counts for the total roll results per action
    public int blockCount = 0;
    public int attackCount = 0;
    public int abilityCount = 0;

    //reference to canvas manager
    [SerializeField] GameObject manager;

    //reference to canvas manager
    [SerializeField] GameObject player;

    //halos
    [SerializeField] Behaviour haloB;
    [SerializeField] Behaviour haloAt;
    [SerializeField] Behaviour haloAb;

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

        dSixText.GetComponent<Text>().text = " ";
        dEightText.GetComponent<Text>().text = " ";
        dTwelveText.GetComponent<Text>().text = " ";

        StartCoroutine(Results());
    }

    private IEnumerator Results()
    {
        int sixCount = 0;
        int eightCount = 0;
        int twelveCount = 0;

        int rollNum = 0;

        //haloB.enabled = true;
        Debug.Log("halo on");

        sixCount = manager.GetComponent<CanvasManager>().sixTallyB;
        eightCount = manager.GetComponent<CanvasManager>().eightTallyB;
        twelveCount = manager.GetComponent<CanvasManager>().twelveTallyB;

        Debug.Log("Problem test");
        yield return new WaitForSecondsRealtime(1);
        Debug.Log("Problem test");

        for(int i = 0; i < sixCount; i++)
        {
            rollNum = player.GetComponent<Player>().RollD6s();
            blockCount += rollNum;
            sixRoll = true;
            yield return new WaitForSecondsRealtime(1);
            sixRoll = false;
            dSixText.GetComponent<Text>().text = $"{rollNum}";
            yield return new WaitForSecondsRealtime(0);
            blockText.GetComponent<Text>().text = $"Block: {blockCount}";
        }
        Debug.Log("d6s");

        for (int i = 0; i < eightCount; i++)
        {
            rollNum = player.GetComponent<Player>().RollD8s();
            blockCount += rollNum;
            eightRoll = true;
            yield return new WaitForSecondsRealtime(1);
            eightRoll = false;
            Debug.Log("Stop Rolling");
            dEightText.GetComponent<Text>().text = $"{rollNum}";
            yield return new WaitForSecondsRealtime(0);
            blockText.GetComponent<Text>().text = $"Block: {blockCount}";
        }
        Debug.Log("d8s");

        for (int i = 0; i < twelveCount; i++)
        {
            rollNum = player.GetComponent<Player>().RollD12s();
            blockCount += rollNum;
            twelveRoll = true;
            yield return new WaitForSecondsRealtime(1);
            twelveRoll = false;
            dTwelveText.GetComponent<Text>().text = $"{rollNum}";
            yield return new WaitForSecondsRealtime(0);
            blockText.GetComponent<Text>().text = $"Block: {blockCount}";
        }
        Debug.Log("d12s");

        //haloB.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        while (sixRoll)
        {
            Debug.Log("Start roll");
            dSix.transform.rotation = Quaternion.Slerp(dSix.transform.rotation, new Quaternion(0, 0, 360, 0), 0.2f);
            Debug.Log("Rolling!!!");
            if(dSix.transform.rotation.z >= 360)
            {
                dSix.transform.rotation = new Quaternion(0, 0, 0, 0);
            }
        }
        dSix.transform.rotation = new Quaternion(0, 0, 0, 0);

        while (eightRoll)
        {
            dEight.transform.rotation = Quaternion.Slerp(dEight.transform.rotation, new Quaternion(0, 0, 360, 0), 0.2f);
            if (dEight.transform.rotation.z >= 360)
            {
                dEight.transform.rotation = new Quaternion(0, 0, 0, 0);
            }
        }
        dEight.transform.rotation = new Quaternion(0, 0, 0, 0);

        while (twelveRoll)
        {
            dTwelve.transform.rotation = Quaternion.Slerp(dTwelve.transform.rotation, new Quaternion(0, 0, 360, 0), 0.2f);
            if (dTwelve.transform.rotation.z >= 360)
            {
                dTwelve.transform.rotation = new Quaternion(0, 0, 0, 0);
            }
        }
        dTwelve.transform.rotation = new Quaternion(0, 0, 0, 0);
    }
}
