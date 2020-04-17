using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTime : MonoBehaviour
{
    public static PlayerTime instance;
    [SerializeField] private int startingTime = 2;
    private Text pointsText;
    private int time;

    private void Awake()
    {
        if (instance != null) Destroy(gameObject);
        else instance = this;
    }

    void Start()
    {
        RestartScore();
        pointsText = GetComponent<Text>();
    }
    
    void Update()
    {
        ShowScore();
    }

    private void ShowScore()
    {
        pointsText.text = time.ToString();
    }

    public int GetScore()
    {
        return time;
    }

    public void RestartScore()
    {
        time = startingTime;
    }

    public void AddPoints(int points)
    {
        time += points;
        Debug.Log("Added " + points + " to time, now: " + time);
    }

    public void SubstractPoints(int points)
    {
        time -= points;
        Debug.Log("Substracted " + points + " to time, now: " + time);
    }
}
