using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTime : MonoBehaviour
{
    private static int time = 2;
    private Text pointsText;
    // Start is called before the first frame update
    void Start()
    {
        pointsText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        ShowScore();
    }

    private void ShowScore()
    {
        pointsText.text = time.ToString();
    }

    public static int GetScore()
    {
        return time;
    }

    public static void RestartScore()
    {
        time = 2;
    }

    public static void AddPoints(int points)
    {
        time += points;
    }

    public static void SubstractPoints(int points)
    {
        time -= points;
    }
}
