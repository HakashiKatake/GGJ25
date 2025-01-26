using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int currentDay = 1;               
    public int totalOrdersCompleted = 0;       
    public int ordersPerDay = 2;               
    public int maxDays = 5;                  
    
    public TMP_Text dayText;                 
    public TMP_Text orderStatusText;         

  
    public GameObject winPanel;              
    public GameObject losePanel;               

    void Start()
    {
        UpdateDayUI();                         
        UpdateOrderStatusUI();             
       
        winPanel.SetActive(false);
        losePanel.SetActive(false);
    }

    public void CompleteOrder()
    {
        totalOrdersCompleted++;

        
        int ordersToday = totalOrdersCompleted % ordersPerDay;
        UpdateOrderStatusUI(ordersToday);

       
        if (ordersToday == 0)
        {
            AdvanceDay();
        }

     
        if (currentDay > maxDays)
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
    }

    void UpdateDayUI()
    {
        dayText.text = $"Day {currentDay}";   
    }

    void UpdateOrderStatusUI(int ordersToday = 0)
    {
        orderStatusText.text = $"Orders Today: {ordersToday}/{ordersPerDay}";  // Update TMP order progress
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
