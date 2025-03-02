using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
using UnityEngine.EventSystems; 

public class onMouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Vector3 scale; 

    void Start()
    {
        scale = gameObject.transform.localScale; 
    }

    
    IEnumerator ScaleOverTime(Vector3 targetScale, float duration)
    {
        Vector3 startScale = transform.localScale;
        float elapsed = 0;

        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(startScale, targetScale, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null; 
        }

        transform.localScale = targetScale; 
    }

    
    public void OnPointerEnter(PointerEventData eventData)
    {
        Vector3 newPos = new Vector3(scale.x + 0.05f, scale.y + 0.05f, 1);
        StartCoroutine(ScaleOverTime(newPos, 0.1f)); 
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        StartCoroutine(ScaleOverTime(scale, 0.1f)); 
    }
}
