using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Gameplay Settings")]
    public float timeLimit = 60f;
    public int enemiesToDestroy = 5;

    [Header("UI Panels")]
    public GameObject gameOverPanel;
    public GameObject winPanel;

    private float timer;
    private int enemiesDestroyed = 0;
    private bool gameEnded = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        Time.timeScale = 1f;
    }

    void Start()
    {
        timer = timeLimit;
    }

    void Update()
    {
        if (gameEnded) return;

        timer -= Time.deltaTime;

        if (timer <= 0)
            GameOver();
    }

    public void AddEnemyDestroyed()
    {
        enemiesDestroyed++;

        if (enemiesDestroyed >= enemiesToDestroy)
            WinGame();
    }

    void WinGame()
    {
        gameEnded = true;
        Debug.Log("YOU WIN!");

        if (winPanel != null)
            winPanel.SetActive(true);

        Time.timeScale = 0f;
    }

    public void GameOver()
    {
        gameEnded = true;
        Debug.Log("GAME OVER");

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public float GetTimer() => timer;
    public int GetDestroyed() => enemiesDestroyed;
}
