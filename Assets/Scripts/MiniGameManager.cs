using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    public string activeOrder; 

    public void StartMiniGame(string order)
    {
        activeOrder = order; 
        Debug.Log("Mini-game started for: " + activeOrder);

    
    }

    public void CompleteMiniGame(int orderIndex)
    {
        Debug.Log("Mini-game completed for: " + activeOrder);

       
        FindObjectOfType<GameManager>().CompleteOrder(orderIndex);
    }
}
