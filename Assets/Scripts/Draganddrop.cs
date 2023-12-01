using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Screen = UnityEngine.Device.Screen;

[RequireComponent(typeof(Image))]
public class DragAndDrop : MonoBehaviour, IDragHandler, IBeginDragHandler,IEndDragHandler
{
    public void OnBeginDrag(PointerEventData eventData)
    {
        var image = eventData.pointerDrag.GetComponent<Image>();
        image.raycastTarget = false;
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        eventData.pointerDrag.transform.localPosition =
            (eventData.position - new Vector2(Screen.width/2,Screen.height/2)) /108;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        var image = eventData.pointerDrag.GetComponent<Image>();
        image.raycastTarget = true;
    }
    
   
    
   
}