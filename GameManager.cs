using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager managerInstance;

    private List<string> buttons = new List<string>();

    public Text pointText;

    public Text taskText;

    public GameObject menuScreen;

    public GameObject finalScreen;

    public GameObject invisibleDoor;

    private int points = 3;

    private bool computerIsOn = false;

    private void Awake()
    {
        managerInstance = this;

        Time.timeScale = 1f;
    }

    private void FixedUpdate()
    {
        points = PlayerPrefs.GetInt("Points");
        pointText.text = points.ToString();
        if (points == 2) SetTaskChange("Осмотрите своё жилище, неужели ноутбук заработал?");
        if (points == 1)
        {
            SetTaskChange("Найди выход в чем-то, что любит автор");
            SetActivateFinalQuestion();
        }
        
    }

    public void SetClickPowerButton()
    {
        if (!computerIsOn)
        {
            if (points == 3)
                taskText.text = "Осмотритесь и введите пароль от компьютера";
            computerIsOn = true;
        }
        else
        {
            if (points == 3)
                taskText.text = "Запустите компьютер";
            computerIsOn = false;
        }
    }

    public bool GetComputerIsOn()
    {
        return computerIsOn;
    }

    public void PointMinused()
    {
        points -= 1;
    }

    public int GetPoints()
    {
        return points;
    }

    public void SetTaskChange(string task)
    {
        taskText.text = task;
    }

    public void GetClicked(string color)
    {
        buttons.Add(color);
    }

    public bool QueueButtonsTrue()
    {
        if (buttons[0] == "blue")
            if (buttons[1] == "pink")
                if (buttons[2] == "yellow")
                    return true;
                else return false;
            else return false;
        else return false;
    }

    public void ClearButtons()
    {
        buttons.Clear();
    }

    public int GetCountClickedButtons()
    {
        buttons = buttons.Distinct().ToList();
        return buttons.Count;
    }

    public void LoadGame()
    {
        PlayerPrefs.SetInt("Points", points);
        SceneManager.LoadScene("Game");
    }

    public void LoadMainScene()
    {
        PlayerPrefs.SetInt("Points", points);
        SceneManager.LoadScene("Main");
    }

    public void SetActiveMenu()
    {
        menuScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void SetDeactiveMenu()
    {
        menuScreen.SetActive(false);
    }

    public void SetActiveFinalScreen()
    {
        PlayerPrefs.SetInt("Points", 3);
        finalScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void SetActivateFinalQuestion()
    {
        invisibleDoor.SetActive(true);
    }
}
