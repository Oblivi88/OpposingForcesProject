using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeLeft : MonoBehaviour
{
    // Script that controls Time Left in game, with the win/lose condition

    // values for time left text
    public float timeLeft;
    public float startTime;
    private TextMeshProUGUI tmp;
    public TextMeshProUGUI timeLeftTXT;

    // UI elements
    public Button restartButton;
    public GameObject endScreen;
    public TextMeshProUGUI endMessage;
    public TextMeshProUGUI tutorial;

    // loss condition
    private bool loss;

    // lights
    public Lightbulb lightLeft;
    public Lightbulb lightRight;
    public Lightbulb lightMain;
    void Start()
    {
        // at game start, set all values and set visibility of UI
        loss = false;
        startTime = 120;
        timeLeft = startTime;
        tmp = GetComponent<TextMeshProUGUI>();
        endScreen.SetActive(false);
        timeLeftTXT.gameObject.SetActive(true);
        tutorial.gameObject.SetActive(true);
    }

    void Update()
    {
        // display time left
        tmp.text = timeLeft.ToString("F0");
        // as long as player has not lost, count down time left
        if (!loss)
        {
            timeLeft -= Time.deltaTime;
            endMessage.text = "You Win!";
        }
        // if time left runs out (whether win or lose) set visibility of UI elements
        if (timeLeft <= 0)
        {
            endScreen.SetActive(true);
            timeLeftTXT.gameObject.SetActive(false);
            tutorial.gameObject.SetActive(false);
            
        }
        // if all three lights go out, player loses
        if (lightLeft.dimLevel >= 1 && lightRight.dimLevel >= 1 && lightMain.dimLevel >= 1)
        {
            loss = true;
        }
        // set text to display player loss
        if (loss)
        {
            timeLeft = 0;
            endMessage.text = "You Lose.";
        }
    }

    // called by reset button onClick
    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
