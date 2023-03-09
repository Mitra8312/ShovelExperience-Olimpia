using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleVaseHandler : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        gameManager.PointMinused();
        PlayerPrefs.SetInt("Points", gameManager.GetPoints());
        gameManager.LoadMainScene();
    }
}
