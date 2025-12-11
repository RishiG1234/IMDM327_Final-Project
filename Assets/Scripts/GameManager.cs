using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Hunger Settings")]
    public float maxHunger = 10f;
    public float hungerDrainRate = 1f;
    public float hunger;

    [Header("UI References")]
    public Image hungerFill;
    public TMP_Text scoreText;
    public GameObject winScreen;
    public GameObject loseScreen;

    [Header("Fish Tracking")]
    public int totalFish;    // set this to number of fish in the scene
    private int fishRemaining;

    private void Start()
    {
        hunger = maxHunger;
        fishRemaining = totalFish;
        UpdateScore();
    }

    private void Update()
    {
        // drain hunger over time
        hunger -= hungerDrainRate * Time.deltaTime;

        // update hunger UI
        if (hungerFill != null)
            hungerFill.fillAmount = hunger / maxHunger;

        // check lose state
        if (hunger <= 0f)
            LoseGame();
    }

    public void FishEaten()
    {
        hunger = maxHunger;   // refill hunger
        fishRemaining--;      // reduce remaining fish count
        UpdateScore();

        if (fishRemaining <= 0)
            WinGame();
    }

    private void UpdateScore()
    {
        if (scoreText != null)
        {
            int score = totalFish - fishRemaining;
            scoreText.text = "Score: " + score;
        }
    }

    private void WinGame()
    {
        Time.timeScale = 0f;
        if (winScreen != null) winScreen.SetActive(true);
    }

    private void LoseGame()
    {
        Time.timeScale = 0f;
        if (loseScreen != null) loseScreen.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
