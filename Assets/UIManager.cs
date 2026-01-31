using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button[] layerButtons;
    public static UIManager Instance;
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void DisableLayerButtons()
    {
        foreach (var button in layerButtons)
        {
            button.interactable = false;    
        }
    }
    public void EnableLayerButtons()
    {
        foreach(var button in layerButtons)
        {
            button.interactable = true;
        }
    }
}
