using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public Button[] levelButtons;

    public static LevelLoader Instance;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = (i + 1 <= unlockedLevel);
        }
    }

    public void LoadLevel(int levelIndex)
    {
        GameManager.Instance.LoadLevel(levelIndex);
    }

}
