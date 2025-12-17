using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Hunger Settings")]
    public float maxHunger = 10f;
    public float hungerDrainRate = 1f;
    public float hunger;

    [Header("UI References (World Space)")]
    public Image hungerFill;
    public TMP_Text scoreText;
    public GameObject winScreen;
    public GameObject loseScreen;
    public GameObject startScreen;

    [Header("Fish Tracking")]
    public int totalFish;
    private int fishRemaining;

    [Header("Player")]
    public Transform sharkPlayer;

    [Header("Spawning")]
    public BoidSpawner boidSpawner;
    public CoralSpawner coralSpawner;

    private void Start()
    {
        Time.timeScale = 0f;
        hunger = maxHunger;
        fishRemaining = totalFish;
        UpdateScore();

        // Setup VR button clicks
        SetupVRButtons();
    }

    private void Update()
    {
        hunger -= hungerDrainRate * Time.deltaTime;

        if (hungerFill != null)
            hungerFill.fillAmount = Mathf.Clamp01(hunger / maxHunger);

        if (hunger <= 0f)
            LoseGame();
    }

    public void FishEaten()
    {
        hunger = maxHunger;
        fishRemaining--;
        UpdateScore();

        if (fishRemaining <= 0)
            WinGame();
    }

    private void UpdateScore()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + (totalFish - fishRemaining);
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
        hunger = maxHunger;
        fishRemaining = totalFish;
        UpdateScore();

        if (loseScreen != null) loseScreen.SetActive(false);
        if (winScreen != null) winScreen.SetActive(false);

        if (sharkPlayer != null)
        {
            sharkPlayer.position = new Vector3(0f, -0.66144f, -1.874f);
            sharkPlayer.rotation = Quaternion.identity;
        }

        if (boidSpawner != null)
        {
            boidSpawner.ClearBoid();
            boidSpawner.SpawnBoid();
        }

        if (coralSpawner != null)
        {
            coralSpawner.ClearObstacles();
            coralSpawner.SpawnObstacles();
        }

        if (startScreen != null)
            startScreen.SetActive(true);
    }

    public void StartGame()
    {
        Time.timeScale = 1f;

        if (startScreen != null)
            startScreen.SetActive(false);

        if (boidSpawner != null)
            boidSpawner.SpawnBoid();

        if (coralSpawner != null)
            coralSpawner.SpawnObstacles();
    }

    /// <summary>
    /// Automatically assigns VR-compatible button listeners.
    /// </summary>
    private void SetupVRButtons()
    {
        Button[] buttons = FindObjectsByType<Button>(FindObjectsSortMode.None);
        foreach (Button btn in buttons)
        {
            // Clear existing listeners to avoid duplicate calls
            btn.onClick.RemoveAllListeners();

            // Add the appropriate action based on button name (optional)
            if (btn.name.ToLower().Contains("start"))
                btn.onClick.AddListener(StartGame);
            else if (btn.name.ToLower().Contains("restart"))
                btn.onClick.AddListener(RestartGame);

            // Debug logging
            btn.onClick.AddListener(() => Debug.Log("Button clicked: " + btn.name));
        }
    }
}
