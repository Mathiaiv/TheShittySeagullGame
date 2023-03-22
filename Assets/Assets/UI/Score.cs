using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Score : MonoBehaviour
{
    public int score;
    private TMP_Text display;
    private void Start()
    {
        score = 0;
        display = GetComponent<TMP_Text>();
        DisplayInt();
    }

    private void DisplayInt()
    {
        display.text = score;
    }

    public void Update()
    {
        DisplayInt();
    }

}