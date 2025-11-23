using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dan.Main;

public class Leaderboard : MonoBehaviour 
{
    [Header("Text References")]
    [SerializeField]
    private List<TextMeshProUGUI> names;

    [SerializeField]
    private List<TextMeshProUGUI> scores;

    [SerializeField]
    private TextMeshProUGUI loadingText;

    [Header("Settings")]
    [SerializeField]
    private bool useTopThreeColors = true;

    [Header("Top 3 Colors")]
    [SerializeField]
    private Color goldColor = new Color(1f, 0.84f, 0f);
    
    [SerializeField]
    private Color silverColor = new Color(0.75f, 0.75f, 0.75f);
    
    [SerializeField]
    private Color bronzeColor = new Color(0.8f, 0.5f, 0.2f);
    
    [SerializeField]
    private Color normalColor = Color.white;

    private string publicLeaderboardKey = "f991ceb445661f9bbcbdc325d6a103dc94be6dde813d2346b826ad87c914a0dd";

    private void Start() 
    {
        GetLeaderboard();
    }

    public void GetLeaderboard() 
    {
        if (loadingText != null)
        {
            loadingText.text = "Carregando...";
            loadingText.gameObject.SetActive(true);
        }

        LeaderboardCreator.GetLeaderboard(publicLeaderboardKey, (msg) => 
        {
            if (loadingText != null)
                loadingText.gameObject.SetActive(false);

            int loopLength = Mathf.Min(msg.Length, names.Count);

            for (int i = 0; i < loopLength; i++) 
            {
                names[i].text = $"{i + 1}. {msg[i].Username}";
                scores[i].text = $"{msg[i].Score} kills";

                if (useTopThreeColors)
                {
                    Color rankColor = GetRankColor(i);
                    names[i].color = rankColor;
                    scores[i].color = rankColor;
                }
            }

            for (int i = loopLength; i < names.Count; i++) 
            {
                names[i].text = $"{i + 1}. ---";
                scores[i].text = "---";
                names[i].color = normalColor;
                scores[i].color = normalColor;
            }
        },
        (error) =>
        {
            if (loadingText != null)
            {
                loadingText.text = "Erro ao carregar!";
            }
            Debug.LogError($"Erro ao carregar leaderboard: {error}");
        });
    }

    private Color GetRankColor(int rank)
    {
        switch (rank)
        {
            case 0: return goldColor;
            case 1: return silverColor;
            case 2: return bronzeColor;
            default: return normalColor;
        }
    }

    public void RefreshLeaderboard()
    {
        GetLeaderboard();
    }
}