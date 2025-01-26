using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    public Recipe activeOrder;
    
    private void Start()
    {
        
    }
    public void StartMiniGame(Recipe order)
    {
        activeOrder = order; 
        Debug.Log("Mini-game started for: " + activeOrder.rName);

    
    }

    public void CompleteMiniGame(int orderIndex)
    {
        Debug.Log("Mini-game completed for: " + activeOrder.rName);

       
        GameManager.instance.CompleteOrder(orderIndex);
    }
}
