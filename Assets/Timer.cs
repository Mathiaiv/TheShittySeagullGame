using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    private TMP_Text display;
    [SerializeField] private float timeRemaining; //the time before the level ends in seconds 
    private bool running;
    
    // Start is called before the first frame update
    void Start()
    {
        display = GetComponent<TMP_Text>();
        running = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (running)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Times up!");
                running = false;
                timeRemaining = 0;
                SceneManager.LoadScene("MainMenu");
            }
        }

        display.text = DisplayString();
    }

    private string DisplayString()
    {
        float minutes = Mathf.FloorToInt(timeRemaining / 60);
        float seconds = Mathf.FloorToInt(timeRemaining % 60);
        float hundredsSec = Mathf.FloorToInt((timeRemaining - minutes * 60 - seconds) * 100);
        return $"{minutes:00}:{seconds:00}.{hundredsSec:00}";
    }
}
