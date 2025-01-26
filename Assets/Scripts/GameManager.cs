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

    // Win/Lose Panels
    public GameObject winPanel;
    public GameObject losePanel;

    // List of dishes
    private Recipe[] dishes;
    private List<Recipe> dailyOrders = new List<Recipe>();
    public Recipe curActive;

    //Singleton
    public static GameManager instance;

    private void Awake()
    {
        dishes = Resources.LoadAll<Recipe>("Recipes");
    }
    private void OnLevelWasLoaded(int level)
    {
        if (SceneManager.GetSceneAt(level).name == "MainScene")
        {
            dayText = MainSceneUIManager.Instance.dayText;
            orderStatusText = MainSceneUIManager.Instance.orderStatusText;
            order1Text = MainSceneUIManager.Instance.order1Text;
            order2Text = MainSceneUIManager.Instance.order2Text;
            winPanel = MainSceneUIManager.Instance.winPanel;
            losePanel = MainSceneUIManager.Instance.losePanel;
        }
    }
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        UpdateDayUI();
        UpdateOrderStatusUI();


        winPanel.SetActive(false);
        losePanel.SetActive(false);

        GenerateDailyOrders();
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

    public void SelectOrder(int orderIndex)
    {
        if (orderIndex < 0 || orderIndex >= dailyOrders.Count)
            return;


        curActive = dailyOrders[orderIndex];
    }

    public void CompleteOrder(bool Successful)
    {

        int orderIndex = ordersPerDay - dailyOrders.Count;
        totalOrdersCompleted++;


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

        if (Successful)
        {
            totalOrdersCompleted++;
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
        winPanel.SetActive(true);
        Time.timeScale = 0;
    }

    void LoseGame()
    {
        Debug.Log("You lose! You couldn't complete all orders.");
        losePanel.SetActive(true);
        Time.timeScale = 0;
    }
}

