using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int score;
    private TMP_Text display;
    private void Start()
    {
        score = 0;
        display = GetComponent<TMP_Text>();
        DisplayInt();
    }

    private void DisplayInt()
    {
        display.text = "" + score;
    }

    public void Update()
    {
        DisplayInt();
    }

    public void addScore(int points)
    {
        score += points;
    }
}