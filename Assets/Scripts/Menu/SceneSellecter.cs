﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSellecter : MonoBehaviour
{
    public static List<Color> winners = new List<Color>();
    public Image winnerPrefab;
    public Transform winnerParent;
    public float timeToNext;
    public float fadeTime;
    public Image image;
    private float time;
    private Color c;

    void Start()
    {
        while (winners.Count > 10) winners.RemoveAt(0);

        foreach (Color color in winners)
        {
            Image winner = Instantiate(winnerPrefab, winnerParent);
            winner.color = color;
        }
        time = timeToNext;
        c = image.color;
    }

    void Update()
    {
        if (time > fadeTime && Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            Waypoints.Instance.StartGame();
            Destroy(gameObject);
            return;
        }

        time -= Time.deltaTime;

        c.a = 2 - (Mathf.Min(fadeTime, timeToNext - time) + Mathf.Min(fadeTime, time)) / fadeTime;
        image.color = c;
        if (time > 0) return;

        time = timeToNext;
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCount);
    }
}
