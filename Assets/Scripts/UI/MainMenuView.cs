using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/**
 * View for main menu. Handles:
 * - Button events
 */
public class MainMenuView : MonoBehaviour
{
    [SerializeField] private string gameSceneName;
    
    [SerializeField] private Button playButton;
    [SerializeField] private Button scoreboardButton;
    [SerializeField] private Button exitButton;

    private void OnEnable()
    {
        playButton.onClick.AddListener(PlayGame);
        scoreboardButton.onClick.AddListener(ShowScoreboard);
        exitButton.onClick.AddListener(ExitGame);
    }

    private void OnDisable()
    {
        playButton.onClick.RemoveListener(PlayGame);
        scoreboardButton.onClick.RemoveListener(ShowScoreboard);
        exitButton.onClick.RemoveListener(ExitGame);
    }

    private void PlayGame()
    {
        SceneManager.LoadScene("FirstLevel");
    }

    private void ShowScoreboard()
    {
        // TODO
    }

    private void ExitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        
        Application.Quit();
    }
}
