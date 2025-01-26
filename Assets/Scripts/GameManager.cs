using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int currentDay = 1;
    public int totalOrdersCompleted = 0;
    public int ordersPerDay = 2;
    public int maxDays = 5;

    // TMP UI Elements
    public TMP_Text dayText;
    public TMP_Text orderStatusText;
    public TMP_Text order1Text;
    public TMP_Text order2Text;
    public TMP_Text resultText; // Text for displaying win/lose messages

    // Win/Lose Panels
    public GameObject resultPanel;

    // List of dishes
    private Recipe[] dishes;
    private List<Recipe> dailyOrders = new List<Recipe>();
    public Recipe curActive;

    // Singleton
    public static GameManager instance;

    private void Awake()
    {

        dishes = Resources.LoadAll<Recipe>("Recipes");
    }

    private void OnLevelWasLoaded(int level)
    {
        StartCoroutine(WaitForSceneLoad());
    }

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        if (instance == null)
        {
            instance = this;

            UpdateDayUI();
            UpdateOrderStatusUI();

            resultPanel.SetActive(false);

            GenerateDailyOrders();
        }
        else
        {
            Destroy(this);
        }
    }

    private void OnDestroy()
    {
        if (instance == this) { instance = null; }
    }

    void GenerateDailyOrders()
    {
        dailyOrders.Clear();
        List<Recipe> availableDishes = new List<Recipe>(dishes);

        for (int i = 0; i < ordersPerDay; i++)
        {
            int randomIndex = Random.Range(0, availableDishes.Count);
            dailyOrders.Add(availableDishes[randomIndex]);
            availableDishes.RemoveAt(randomIndex);
        }

        order1Text.text = "Order 1: " + dailyOrders[0].rName;
        order1Text.gameObject.SetActive(true);
        order2Text.text = "Order 2: " + dailyOrders[1].rName;
        order2Text.gameObject.SetActive(true);
    }

    public void SelectOrder()
    {
        if (dailyOrders.Count <= 0) { return; }
        curActive = dailyOrders[0];

        SceneManager.LoadScene("Minigame");
    }

    public void CompleteOrder(bool successful)
    {
        SceneManager.LoadScene("MainScene");

        if (successful)
        {
            totalOrdersCompleted++;
            ShowResultMessage("You Win! Dish Complete!");
        }
        else
        {
            ShowResultMessage("You Lose!");
        }
    }

    void ShowResultMessage(string message)
    {
        resultText.text = message;
        resultPanel.SetActive(true);
        Invoke(nameof(HideResultPanel), 2f); // Hide the panel after 2 seconds
    }

    void HideResultPanel()
    {
        resultPanel.SetActive(false);
    }

    void AdvanceDay()
    {
        currentDay++;
        UpdateDayUI();

        if (currentDay <= maxDays)
        {
            GenerateDailyOrders();
        }
    }

    void UpdateDayUI()
    {
        dayText.text = $"Day {currentDay}";
    }

    void UpdateOrderStatusUI(int ordersToday = 0)
    {
        orderStatusText.text = $"Orders Today: {ordersToday}/{ordersPerDay}";
    }

    void WinGame()
    {
        Debug.Log("You win! All orders are complete!");
        resultPanel.SetActive(true);
        resultText.text = "Congratulations! You completed all dishes!";
        Time.timeScale = 0;
    }

    void LoseGame()
    {
        Debug.Log("You lose! You couldn't complete all orders.");
        resultPanel.SetActive(true);
        resultText.text = "Game Over! You couldn't complete the orders.";
        Time.timeScale = 0;
    }

    public System.Collections.IEnumerator WaitForSceneLoad()
    {
        yield return new WaitForEndOfFrame();
        if (SceneManager.GetActiveScene().name == "MainScene")
        {
            dayText = MainSceneUIManager.Instance.dayText;
            orderStatusText = MainSceneUIManager.Instance.orderStatusText;
            order1Text = MainSceneUIManager.Instance.order1Text;
            order2Text = MainSceneUIManager.Instance.order2Text;
            resultPanel = MainSceneUIManager.Instance.resultPanel;
            resultText = MainSceneUIManager.Instance.resultText;

            int orderIndex = ordersPerDay - dailyOrders.Count;

            if (orderIndex == 0 && order1Text.gameObject.activeSelf)
            {
                order1Text.gameObject.SetActive(false);
            }
            else if (orderIndex == 1 && order2Text.gameObject.activeSelf)
            {
                order2Text.gameObject.SetActive(false);
            }

            if (dailyOrders.Count > 0)
            {
                dailyOrders.RemoveAt(0);
            }

            int ordersToday = dailyOrders.Count;
            UpdateOrderStatusUI(ordersToday);

            if (ordersToday == 0)
            {
                AdvanceDay();
            }

            if (currentDay >= maxDays)
            {
                if (totalOrdersCompleted == ordersPerDay * maxDays)
                {
                    WinGame();
                }
                else
                {
                    LoseGame();
                }
            }
        }
    }
}
