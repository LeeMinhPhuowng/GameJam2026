using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject settings;
    [SerializeField] GameObject home;
    [SerializeField] GameObject completed;
    [SerializeField] GameObject end;
    public static GameManager Instance;

    const string UNLOCKED_LEVEL = "UnlockedLevel";

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        if (!PlayerPrefs.HasKey(UNLOCKED_LEVEL))
        {
            PlayerPrefs.SetInt(UNLOCKED_LEVEL, 1);
            PlayerPrefs.Save();
        }
    }

    private void Start()
    {
        menu.SetActive(false);
        settings.SetActive(false);
        home.SetActive(true);
        completed.SetActive(false);
        end.SetActive(false);
        UIManager.Instance.DisableLayerButtons();
    }
    public void OnHomeButtonClicked()
    {       
        SceneManager.LoadScene("MainMenu");
        UIManager.Instance.DisableLayerButtons();
        home.SetActive(true);
        menu.SetActive(false);
    }

    public void OnMenuButtonClicked()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0) { return; }
        menu.SetActive(!menu.activeSelf);
    }

    public void OnSettingsButtonClicked()
    {
        settings.SetActive(!settings.gameObject.activeSelf);
    }

    public void OnPlayButtonClicked()
    {
        menu.SetActive(true);
        home.SetActive(false);
    }

    public void LoadLevel(int buildIndex)
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(buildIndex);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        LayerManager.Instance.InitLayers();
        UIManager.Instance.EnableLayerButtons();
        home.SetActive(false);
        settings.SetActive(false);
        menu.SetActive(false);
        completed.SetActive(false);
        end.SetActive(false);
    }

    public void CompleteLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            end.SetActive(true);
            return;
        }
        int unlocked = PlayerPrefs.GetInt("UnlockedLevel", 1);
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        if (currentLevel >= unlocked)
        {
            PlayerPrefs.SetInt("UnlockedLevel", currentLevel + 1);
            PlayerPrefs.Save();
        }
        completed.SetActive(true);
    }

    public void OnNextButtonClicked()
    {
        int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
        completed.SetActive(false);
        LoadLevel(nextIndex);
    }
    public void OnReplayButtonClicked()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
