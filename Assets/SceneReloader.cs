using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReloader : MonoBehaviour
{
    // The key combination to reload the scene.
    public KeyCode reloadKey = KeyCode.R;

    void Update()
    {
        // Check if the reload key is pressed.
        if (Input.GetKeyDown(reloadKey))
        {
            // Reload the current scene.
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}