using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PPlayerHealth : MonoBehaviour
{
    public int health; // keeps track of the player's current health
    public int maxHealth = 10;
    public Slider healthSlider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = health;
    }

    public void TakeDamage(int amount) //This function will be called anytime the player takes damage
    {
        health -= amount;
        healthSlider.value = health;
       

        if (health <= 0)
        {
            Destroy(gameObject); //If the damage takes the player down to zero (or below), then the player will be destroyed 

            Object.FindAnyObjectByType<GameManager>().TriggerGameOver();
        }
    }
}
