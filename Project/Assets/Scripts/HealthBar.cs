using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public int currentHealth = 100;
    public int maxHealth = 100;

    public string designator;

    [SerializeField] GameObject character;

    void Start()
    {
        if (designator == "Player")
        {
            currentHealth = character.GetComponent<Player>().Health;
            Debug.Log(character.GetComponent<Player>().Health);
            maxHealth = character.GetComponent<Player>().Health;
        }
        if (designator == "Enemy")
        {
            currentHealth = character.GetComponent<Enemy>().Health;
            maxHealth = character.GetComponent<Enemy>().Health;
        }
        SetHealth(maxHealth);
        SetMaxHealth(maxHealth);
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    void Update()
    {
        if (designator == "Player")
        {
            if (currentHealth != character.GetComponent<Player>().Health)
            {
                currentHealth = character.GetComponent<Player>().Health;
                Debug.Log(currentHealth);
                SetHealth(currentHealth);
            }
        }
        if (designator == "Enemy")
        {
            if (currentHealth != character.GetComponent<Enemy>().Health)
            {
                currentHealth = character.GetComponent<Enemy>().Health;
                SetHealth(currentHealth);
            }
        }
    }
}
