using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeLeft : MonoBehaviour
{
    public float timeLeft;
    public float startTime;
    public Button restartButton;
    private TextMeshProUGUI tmp;
    public GameObject endScreen;
    private bool loss;
    public TextMeshProUGUI endMessage;
    public TextMeshProUGUI tutorial;
    public TextMeshProUGUI timeLeftTXT;

    public Lightbulb lightLeft;
    public Lightbulb lightRight;
    public Lightbulb lightMain;
    void Start()
    {
        loss = false;
        startTime = 120;
        timeLeft = startTime;
        tmp = GetComponent<TextMeshProUGUI>();
        endScreen.SetActive(false);
        timeLeftTXT.gameObject.SetActive(true);
        tutorial.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        tmp.text = timeLeft.ToString("F0");
        if (!loss)
        {
            timeLeft -= Time.deltaTime;
            endMessage.text = "You Win!";
        }

        if (timeLeft <= 0)
        {
            endScreen.SetActive(true);
            timeLeftTXT.gameObject.SetActive(false);
            tutorial.gameObject.SetActive(false);
            
        }

        if (lightLeft.dimLevel >= 1 && lightRight.dimLevel >= 1 && lightMain.dimLevel >= 1)
        {
            loss = true;
        }
        
        if (loss)
        {
            timeLeft = 0;
            endMessage.text = "You Lose.";
        }
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
