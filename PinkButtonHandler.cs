using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkButtonHandler : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        gameManager.GetClicked("pink");
    }
}
