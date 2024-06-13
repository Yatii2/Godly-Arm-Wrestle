using UnityEngine;
using UnityEngine.UI;

public class ArmWrestlingGame : MonoBehaviour
{
    public Slider armPositionSlider;
    public Button clickButton;
    public float playerStrength = 0.1f;
    public float botStrength = 0.05f;
    public float matchTime = 10f;
    public GameObject winImage;
    public GameObject loseImage;

    private float timer;
    private bool gameActive;

    void Start()
    {
        timer = matchTime;
        gameActive = true;
        armPositionSlider.value = 0.5f; // Start at the middle position
        clickButton.onClick.AddListener(OnPlayerClick);
        winImage.SetActive(false); // Hide win image initially
        loseImage.SetActive(false); // Hide lose image initially
    }

    void Update()
    {
        if (gameActive)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                EndGame("draw");
            }

            UpdateBotStrength();
            UpdateArmPosition();
        }
    }

    void OnPlayerClick()
    {
        if (gameActive)
        {
            armPositionSlider.value += playerStrength;
            CheckWinCondition();
        }
    }

    void UpdateBotStrength()
    {
        armPositionSlider.value -= botStrength * Time.deltaTime;
        CheckWinCondition();
    }

    void UpdateArmPosition()
    {
        armPositionSlider.value = Mathf.Clamp(armPositionSlider.value, 0, 1);
    }

    void CheckWinCondition()
    {
        if (armPositionSlider.value <= 0)
        {
            EndGame("lose");
        }
        else if (armPositionSlider.value >= 1)
        {
            EndGame("win");
        }
    }

    void EndGame(string result)
    {
        gameActive = false;
        if (result == "win")
        {
            winImage.SetActive(true);
        }
        else if (result == "lose")
        {
            loseImage.SetActive(true);
        }
        else
        {
            Debug.Log("Time's up! It's a draw!");
        }
    }
}
