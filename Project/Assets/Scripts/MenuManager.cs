using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    //gameobjects to switch activeness
    [SerializeField] GameObject play;
    [SerializeField] GameObject instruct;
    [SerializeField] GameObject panel;
    [SerializeField] GameObject back;


    // Start is called before the first frame update
    void Start()
    {
        play.SetActive(true);
        instruct.SetActive(true);
        panel.SetActive(false);
        back.SetActive(false);
    }

    public void Instruction()
    {
        play.SetActive(false);
        instruct.SetActive(false);
        panel.SetActive(true);
        back.SetActive(true);
    }

    public void Back()
    {
        play.SetActive(true);
        instruct.SetActive(true);
        panel.SetActive(false);
        back.SetActive(false);
    }

    public void LoadScene(string sceneName)
    {
        if (sceneName == "Prototype")
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
