using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerHandler : MonoBehaviour
{
    private GameManager gameManager;

    public GameObject BlockScreen;

    public GameObject GameScreen;

    public Light light;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        light.enabled = false;
        BlockScreen.SetActive(false);
        GameScreen.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (gameManager.GetComputerIsOn())
        {
            light.enabled = true;
            BlockScreen.SetActive(true);

            if (gameManager.GetCountClickedButtons() == 3)
            {
                if (gameManager.QueueButtonsTrue())
                {
                    GameScreen.SetActive(true);
                    BlockScreen.SetActive(false);
                    light.color = Color.green;
                }
                else
                {
                    light.color = Color.red;
                    gameManager.ClearButtons();
                }
            }
        }
        else
        {
            light.enabled = false;
            gameManager.ClearButtons();
            GameScreen.SetActive(false);
            BlockScreen.SetActive(false);
        }
    }
}
