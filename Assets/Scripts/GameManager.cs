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
    public GameObject gameWinPanel;

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

    public void WinGame()
    {
        Time.timeScale = 0f;
        gameWinPanel.SetActive(true);

        var text = gameWinPanel.transform.Find("GameOverText");
        if (text != null)
            text.GetComponent<TMPro.TMP_Text>().text = "YOU WIN!";

        var nextButton = gameWinPanel.transform.Find("NextLevelButton");
        if (nextButton != null)
            nextButton.gameObject.SetActive(true);

        Debug.Log("YOU WIN!");
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

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuScene");
    }

    public void LoadNextLevel()
    {
        Time.timeScale = 1f;

        int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextIndex);
        }
        else
        {
            Debug.Log("Não há próxima fase configurada!");
        }
    }


    public float GetTimer() => timer;
    public int GetDestroyed() => enemiesDestroyed;
}
