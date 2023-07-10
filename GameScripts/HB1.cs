using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HB1 : MonoBehaviour
{
    public Image healthBar;
    public FTmover playerHealth;
    public float maxHealth = 100f;

    private void Start()
    {
        // Update the initial health bar fill
        UpdateHealthBar();
    }

    private void Update()
    {


        UpdateHealthBar();

    }

    private void UpdateHealthBar()
    {
        // Calculate the fill amount based on the current health
        float fillAmount = playerHealth.health / maxHealth;

        // Update the health bar's fill amount
        healthBar.fillAmount = fillAmount;
        healthBar.color = Color.Lerp(Color.red, Color.green, fillAmount);
    }



}
