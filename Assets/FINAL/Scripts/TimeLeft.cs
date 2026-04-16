using TMPro;
using UnityEngine;

public class TimeLeft : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float timeLeft;
    public float startTime;
    private TextMeshProUGUI tmp;
    void Start()
    {
        startTime = 120;
        timeLeft = startTime;
        tmp = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        tmp.text = timeLeft.ToString("F0");
        timeLeft -= Time.deltaTime;
    }
}
