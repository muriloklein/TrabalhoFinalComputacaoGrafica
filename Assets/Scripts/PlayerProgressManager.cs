using UnityEngine;

public class PlayerProgressManager : MonoBehaviour
{
    public static PlayerProgressManager Instance;

    private const string LEVEL1_KILLS_KEY = "Level1Kills";
    private const string LEVEL2_KILLS_KEY = "Level2Kills";
    private const string LEVEL3_KILLS_KEY = "Level3Kills";
    private const string TOTAL_KILLS_KEY = "TotalKills";

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveLevelKills(int levelNumber, int kills)
    {
        string key = GetKeyForLevel(levelNumber);
        PlayerPrefs.SetInt(key, kills);
        PlayerPrefs.Save();

        Debug.Log($"Salvou {kills} kills no Level {levelNumber}");
    }

    public int GetLevelKills(int levelNumber)
    {
        string key = GetKeyForLevel(levelNumber);
        return PlayerPrefs.GetInt(key, 0);
    }

    public int GetTotalKills()
    {
        int total = 0;
        total += PlayerPrefs.GetInt(LEVEL1_KILLS_KEY, 0);
        total += PlayerPrefs.GetInt(LEVEL2_KILLS_KEY, 0);
        total += PlayerPrefs.GetInt(LEVEL3_KILLS_KEY, 0);
        return total;
    }

    public void ResetProgress()
    {
        PlayerPrefs.DeleteKey(LEVEL1_KILLS_KEY);
        PlayerPrefs.DeleteKey(LEVEL2_KILLS_KEY);
        PlayerPrefs.DeleteKey(LEVEL3_KILLS_KEY);
        PlayerPrefs.DeleteKey(TOTAL_KILLS_KEY);
        PlayerPrefs.Save();

        Debug.Log("Progresso resetado!");
    }

    public bool AllLevelsCompleted()
    {
        return GetLevelKills(1) > 0 && 
               GetLevelKills(2) > 0 && 
               GetLevelKills(3) > 0;
    }

    private string GetKeyForLevel(int levelNumber)
    {
        switch (levelNumber)
        {
            case 1: return LEVEL1_KILLS_KEY;
            case 2: return LEVEL2_KILLS_KEY;
            case 3: return LEVEL3_KILLS_KEY;
            default: return LEVEL1_KILLS_KEY;
        }
    }
}