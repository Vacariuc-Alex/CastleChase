using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static int numberOfCoins;
    public TextMeshProUGUI numberOfCoinsText;

    public static int currentHealth = 100;
    public Slider healthBar;

    public static bool gameOver;
    public GameObject gameOverPanel;

    void Start()
    {
        numberOfCoins = 0;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Display the number of Coins
        numberOfCoinsText.text = "Münzen : " + numberOfCoins;

        //Update the slider value
        healthBar.value = currentHealth;

        //GameOver
        if(currentHealth <= 0)
        {
            gameOver = true;
            this.gameOverPanel.SetActive(true);
            currentHealth = 100;
        }
    }
}
