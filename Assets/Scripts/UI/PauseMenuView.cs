using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/**
 * View for pause menu. Handles:
 * - Showing/hiding the pause menu
 * - Button events
 */
public class PauseMenuView : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;

    [SerializeField] private string mainMenuSceneName;

    [SerializeField] private Button resumeButton;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button exitButton;

    private PauseManager pauseManager;

    private void Awake()
    {
        pauseManager = FindObjectOfType<PauseManager>();
    }

    private void OnEnable()
    {
        pauseManager.OnIsPausedChanged += OnIsPausedChanged;

        resumeButton.onClick.AddListener(ResumeGame);
        mainMenuButton.onClick.AddListener(GoToMainMenu);
        exitButton.onClick.AddListener(ExitGame);
    }

    private void OnDisable()
    {
        pauseManager.OnIsPausedChanged -= OnIsPausedChanged;

        resumeButton.onClick.RemoveListener(ResumeGame);
        mainMenuButton.onClick.RemoveListener(GoToMainMenu);
        exitButton.onClick.RemoveListener(ExitGame);
    }

    private void Start()
    {
        canvasGroup.interactable = false;
        canvasGroup.alpha = 0f;
    }

    private void OnIsPausedChanged(bool isPaused)
    {
        canvasGroup.interactable = isPaused;
        
        canvasGroup
            .DOFade(isPaused ? 1f : 0f, 0.2f)
            .SetUpdate(true); // Independent from Time.timeScale
    }

    private void ResumeGame()
    {
        pauseManager.ChangeIsPaused(false);
    }

    private void GoToMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }

    private void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

        Application.Quit();
    }
}