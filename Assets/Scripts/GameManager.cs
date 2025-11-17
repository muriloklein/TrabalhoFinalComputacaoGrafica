using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float timeLimit = 60f;
    public int enemiesToDestroy = 5;

    private float timer;
    private int enemiesDestroyed = 0;
    private bool gameEnded = false;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else 
            Destroy(gameObject);
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
        SceneManager.LoadScene("MainMenu");
    }

    public void GameOver()
    {
        gameEnded = true;
        Debug.Log("GAME OVER");
        SceneManager.LoadScene("MainMenu");
    }

    public float GetTimer() => timer;
    public int GetDestroyed() => enemiesDestroyed;
}
