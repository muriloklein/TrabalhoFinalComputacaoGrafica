using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dan.Main;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> names;
    [SerializeField] private List<TextMeshProUGUI> scores;

    private string publicLeaderboardKey =
        "07674850522ac9864da2ac25f7a9eeb2a66a392b189bf16ddd2ea2c6b44d3c00";

    private void Start()
    {
        if (GameManager.lastScore > 0)
        {
            SetLeaderboardEntry("Player", GameManager.lastScore);
            GameManager.lastScore = 0;
        }
    }

    public void GetLeaderboard()
    {
        LeaderboardCreator.GetLeaderboard(publicLeaderboardKey, (msg) =>
        {
            int loopLength = Mathf.Min(msg.Length, names.Count);

            for (int i = 0; i < loopLength; i++)
            {
                names[i].text = msg[i].Username;
                scores[i].text = msg[i].Score.ToString();
            }

            for (int i = loopLength; i < names.Count; i++)
            {
                names[i].text = "-";
                scores[i].text = "-";
            }
        });
    }

    public void SetLeaderboardEntry(string username, int score)
    {
        if (string.IsNullOrEmpty(username))
            username = "Player";

        LeaderboardCreator.UploadNewEntry(publicLeaderboardKey, username, score, (msg) =>
        {
            Debug.Log("Score enviado!");
            GetLeaderboard();
        });
    }
}
