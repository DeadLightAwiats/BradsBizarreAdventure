using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float remainingTime;
    private bool isTimerRunning = true;

    private void Update()
    {
        if (!isTimerRunning)
            return;

        remainingTime -= Time.deltaTime;
        if (remainingTime <= 0f)
        {
            remainingTime = 0f;
            isTimerRunning = false;
            timerText.text = "00:00";
            SceneManager.LoadSceneAsync(6);
            return;
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
