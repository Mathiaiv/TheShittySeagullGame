using System;
using UnityEngine;
using UnityEngine.InputSystem;

/**
 * Manages the pause state of the game.
 * - Emits `OnIsPausedChanged` when the pause state changes.
 * - Sets `Time.timeScale` to 0 when paused, and 1 when unpaused.
 * - Listens to the `Pause` action, and pauses when performed.
 */
public class PauseManager : MonoBehaviour
{
    [SerializeField] private InputActionReference pauseActionReference;

    private bool isPaused = false;

    public bool IsPaused => isPaused;
    public event Action<bool> OnIsPausedChanged;

    private InputAction pauseAction;
    
    private void OnEnable()
    {
        pauseAction = pauseActionReference.action.Clone();
            
        pauseAction.Enable();
        pauseAction.performed += OnClickPauseAction;
    }
        
    private void OnDisable()
    {
        pauseAction.performed -= OnClickPauseAction;
        pauseAction.Dispose();
    }

    private void OnClickPauseAction(InputAction.CallbackContext callbackContext)
    {
        ChangeIsPaused(!isPaused);
    }
    
    public void ChangeIsPaused(bool newIsPaused)
    {
        isPaused = newIsPaused;
            
        Time.timeScale = newIsPaused ? 0f : 1f;
        OnIsPausedChanged?.Invoke(newIsPaused);
    }
}
