using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public static HealthManager Instance;

    public int health = 100;
    public int Ehealth = 100;
    public TextMeshProUGUI HealthTxt;
    public TextMeshProUGUI EHealthTxt;
    public GameObject Health;
    public GameObject EHealth;
    public GameObject GameOverUI;
    public TextMeshProUGUI GameOverUIText;

    void Awake()
    {
        Instance = this;
    }

    public void UpdateHealth(int changeAmount)
    {
        health += changeAmount;

        HealthTxt.text = health.ToString();

        if(health <= 0)
        {
            GameOverUI.SetActive(true);
            GameOverUIText.text = "You lose";
        }
    }

    public void UpdateEHealth(int changeAmount)
    {
        Ehealth += changeAmount;

        EHealthTxt.text = Ehealth.ToString();

        if(Ehealth <= 0)
        {
            GameOverUI.SetActive(true);
            GameOverUIText.text = "You win";
        }
    }

    public void swapvisibility()
    {
        Health.SetActive(false);
        EHealth.SetActive(true);
    }

    
}