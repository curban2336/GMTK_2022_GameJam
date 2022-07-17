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
        int sixCount = 0;
        int eightCount = 0;
        int twelveCount = 0;

        int rollNum = 0;

        //haloB.enabled = true;

        sixCount = manager.GetComponent<CanvasManager>().sixTallyB;
        eightCount = manager.GetComponent<CanvasManager>().eightTallyB;
        twelveCount = manager.GetComponent<CanvasManager>().twelveTallyB;

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


        sixCount = manager.GetComponent<CanvasManager>().sixTallyB;
        eightCount = manager.GetComponent<CanvasManager>().eightTallyB;
        twelveCount = manager.GetComponent<CanvasManager>().twelveTallyB;

        blockText.GetComponent<Text>().color = new Color(1f, 1f, 1f);
        attackText.GetComponent<Text>().color = new Color(0f, 0f, 0f);
        abilityText.GetComponent<Text>().color = new Color(0f, 0f, 0f);

        Debug.Log(player.GetComponent<Player>().RollD6s());
        yield return new WaitForSeconds(1);

        for (int i = 0; i <= sixCount - 1; i++)
        {
            yield return StartCoroutine(Roll6b(rollNum));
        }

        for (int i = 0; i <= eightCount - 1; i++)
        {
            yield return StartCoroutine(Roll8b(rollNum));
        }

        for (int i = 0; i <= twelveCount - 1; i++)
        {
            yield return StartCoroutine(Roll12b(rollNum));
        }

        sixCount = manager.GetComponent<CanvasManager>().sixTallyAt;
        eightCount = manager.GetComponent<CanvasManager>().eightTallyAt;
        twelveCount = manager.GetComponent<CanvasManager>().twelveTallyAt;

        blockText.GetComponent<Text>().color = new Color(0f, 0f, 0f);
        attackText.GetComponent<Text>().color = new Color(1f, 1f, 1f);
        abilityText.GetComponent<Text>().color = new Color(0f, 0f, 0f);

        yield return new WaitForSeconds(1);

        for (int i = 0; i <= sixCount - 1; i++)
        {
            yield return StartCoroutine(Roll6At(rollNum));
        }

        for (int i = 0; i <= eightCount - 1; i++)
        {
            yield return StartCoroutine(Roll8At(rollNum));
        }

        for (int i = 0; i <= twelveCount - 1; i++)
        {
            yield return StartCoroutine(Roll12At(rollNum));
        }

        sixCount = manager.GetComponent<CanvasManager>().sixTallyAb;
        eightCount = manager.GetComponent<CanvasManager>().eightTallyAb;
        twelveCount = manager.GetComponent<CanvasManager>().twelveTallyAb;

        blockText.GetComponent<Text>().color = new Color(0f, 0f, 0f);
        attackText.GetComponent<Text>().color = new Color(0f, 0f, 0f);
        abilityText.GetComponent<Text>().color = new Color(1f, 1f, 1f);

        yield return new WaitForSeconds(1);

        for (int i = 0; i <= sixCount - 1; i++)
        {
            yield return StartCoroutine(Roll6Ab(rollNum));
        }

        for (int i = 0; i <= eightCount - 1; i++)
        {
            yield return StartCoroutine(Roll8Ab(rollNum));
        }

        for (int i = 0; i <= twelveCount - 1; i++)
        {
            yield return StartCoroutine(Roll12Ab(rollNum));
        }

        yield return new WaitForSeconds(1);

        player.GetComponent<Player>().Damage = attackCount;
        player.GetComponent<Player>().Blocking = blockCount;
        player.GetComponent<Player>().Healing = abilityCount;

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

    private IEnumerator Roll6b(int rollNum)
    {
        rollNum = player.GetComponent<Player>().RollD6s();
        blockCount += rollNum;
        dSix.GetComponent<Animator>().Play("Rotate", 0, 0f);
        yield return new WaitForSeconds(1);
        dSixText.GetComponent<Text>().text = $"{rollNum}";
        blockText.GetComponent<Text>().text = $"Block: {blockCount}";
        yield return new WaitForSeconds(0.5f);
    }

    private IEnumerator Roll8b(int rollNum)
    {
        rollNum = player.GetComponent<Player>().RollD8s();
        blockCount += rollNum;
        dEight.GetComponent<Animator>().Play("Rotate", 0, 0f);
        yield return new WaitForSeconds(1);
        dEightText.GetComponent<Text>().text = $"{rollNum}";
        blockText.GetComponent<Text>().text = $"Block: {blockCount}";
        yield return new WaitForSeconds(0.5f);
    }

    private IEnumerator Roll12b(int rollNum)
    {
        rollNum = player.GetComponent<Player>().RollD12s();
        blockCount += rollNum;
        dTwelve.GetComponent<Animator>().Play("Rotate", 0, 0f);
        yield return new WaitForSeconds(1);
        dTwelveText.GetComponent<Text>().text = $"{rollNum}";
        blockText.GetComponent<Text>().text = $"Block: {blockCount}";
        yield return new WaitForSeconds(0.5f);
    }

    private IEnumerator Roll6At(int rollNum)
    {
        rollNum = player.GetComponent<Player>().RollD6s();
        attackCount += rollNum;
        dSix.GetComponent<Animator>().Play("Rotate", 0, 0f);
        yield return new WaitForSeconds(1);
        dSixText.GetComponent<Text>().text = $"{rollNum}";
        attackText.GetComponent<Text>().text = $"Attack: {attackCount}";
        yield return new WaitForSeconds(0.5f);
    }

    private IEnumerator Roll8At(int rollNum)
    {
        rollNum = player.GetComponent<Player>().RollD8s();
        attackCount += rollNum;
        dEight.GetComponent<Animator>().Play("Rotate", 0, 0f);
        yield return new WaitForSeconds(1);
        dEightText.GetComponent<Text>().text = $"{rollNum}";
        attackText.GetComponent<Text>().text = $"Attack: {attackCount}";
        yield return new WaitForSeconds(0.5f);
    }

    private IEnumerator Roll12At(int rollNum)
    {
        rollNum = player.GetComponent<Player>().RollD12s();
        attackCount += rollNum;
        dTwelve.GetComponent<Animator>().Play("Rotate", 0, 0f);
        yield return new WaitForSeconds(1);
        dTwelveText.GetComponent<Text>().text = $"{rollNum}";
        attackText.GetComponent<Text>().text = $"Attack: {attackCount}";
        yield return new WaitForSeconds(0.5f);
    }

    private IEnumerator Roll6Ab(int rollNum)
    {
        rollNum = player.GetComponent<Player>().RollD6s();
        abilityCount += rollNum;
        dSix.GetComponent<Animator>().Play("Rotate", 0, 0f);
        yield return new WaitForSeconds(1);
        dSixText.GetComponent<Text>().text = $"{rollNum}";
        abilityText.GetComponent<Text>().text = $"Heal: {abilityCount}";
        yield return new WaitForSeconds(0.5f);
    }

    private IEnumerator Roll8Ab(int rollNum)
    {
        rollNum = player.GetComponent<Player>().RollD8s();
        abilityCount += rollNum;
        dEight.GetComponent<Animator>().Play("Rotate", 0, 0f);
        yield return new WaitForSeconds(1);
        dEightText.GetComponent<Text>().text = $"{rollNum}";
        abilityText.GetComponent<Text>().text = $"Heal: {abilityCount}";
        yield return new WaitForSeconds(0.5f);
    }

    private IEnumerator Roll12Ab(int rollNum)
    {
        rollNum = player.GetComponent<Player>().RollD12s();
        abilityCount += rollNum;
        dTwelve.GetComponent<Animator>().Play("Rotate", 0, 0f);
        yield return new WaitForSeconds(1);
        dTwelveText.GetComponent<Text>().text = $"{rollNum}";
        abilityText.GetComponent<Text>().text = $"Heal: {abilityCount}";
        yield return new WaitForSeconds(0.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
