using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Dan.Main;

public class ScoreSubmissionController : MonoBehaviour
{
    [Header("UI References")]
    public TMP_Text level1KillsText;
    public TMP_Text level2KillsText;
    public TMP_Text level3KillsText;
    public TMP_Text totalKillsText;
    public TMP_InputField playerNameInput;
    public GameObject submitButton;
    public GameObject skipButton;

    [Header("Leaderboard Settings")]
    private string publicLeaderboardKey = "f991ceb445661f9bbcbdc325d6a103dc94be6dde813d2346b826ad87c914a0dd";

    private int level1Kills;
    private int level2Kills;
    private int level3Kills;
    private int totalKills;

    private bool scoreSubmitted = false;

    void Start()
    {
        LoadPlayerProgress();
        UpdateUI();

        if (submitButton != null)
            submitButton.SetActive(true);
        
        if (skipButton != null)
            skipButton.SetActive(true);
    }

    void LoadPlayerProgress()
    {
        if (PlayerProgressManager.Instance != null)
        {
            level1Kills = PlayerProgressManager.Instance.GetLevelKills(1);
            level2Kills = PlayerProgressManager.Instance.GetLevelKills(2);
            level3Kills = PlayerProgressManager.Instance.GetLevelKills(3);
            totalKills = PlayerProgressManager.Instance.GetTotalKills();
        }
        else
        {
            Debug.LogError("PlayerProgressManager não encontrado! Usando valores de teste.");
            level1Kills = 0;
            level2Kills = 0;
            level3Kills = 0;
            totalKills = 0;
        }
    }

    void UpdateUI()
    {
        if (level1KillsText != null)
            level1KillsText.text = $"Level 1: {level1Kills} kills";

        if (level2KillsText != null)
            level2KillsText.text = $"Level 2: {level2Kills} kills";

        if (level3KillsText != null)
            level3KillsText.text = $"Level 3: {level3Kills} kills";

        if (totalKillsText != null)
            totalKillsText.text = $"TOTAL: {totalKills} kills";
    }

    public void SubmitScore()
    {
        if (scoreSubmitted)
        {
            Debug.Log("Score já foi enviado!");
            return;
        }

        string playerName = playerNameInput.text.Trim();

        if (string.IsNullOrEmpty(playerName))
        {
            Debug.Log("Digite seu nome!");
            return;
        }

        if (playerName.Length < 2)
        {
            Debug.Log("Nome muito curto!");
            return;
        }

        if (playerName.Length > 20)
        {
            Debug.Log("Nome muito longo!");
            return;
        }

        if (totalKills <= 0)
        {
            Debug.LogWarning("Nenhuma kill registrada! Não há score para enviar.");
            ReturnToMenu();
            return;
        }

        if (submitButton != null)
            submitButton.SetActive(false);

        if (skipButton != null)
            skipButton.SetActive(false);

        Debug.Log($"Enviando score: {playerName} - {totalKills} kills");

        LeaderboardCreator.UploadNewEntry(
            publicLeaderboardKey, 
            playerName, 
            totalKills,
            (success) =>
            {
                if (success)
                {
                    scoreSubmitted = true;
                    Debug.Log("Score enviado com sucesso!");

                    if (PlayerProgressManager.Instance != null)
                        PlayerProgressManager.Instance.ResetProgress();

                    Invoke(nameof(ReturnToMenu), 2f);
                }
                else
                {
                    Debug.LogError("Erro ao enviar score!");
                    if (submitButton != null)
                        submitButton.SetActive(true);
                    if (skipButton != null)
                        skipButton.SetActive(true);
                }
            },
            (error) =>
            {
                Debug.LogError($"Erro: {error}");
                if (submitButton != null)
                    submitButton.SetActive(true);
                if (skipButton != null)
                    skipButton.SetActive(true);
            }
        );
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}