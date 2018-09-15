using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector2 diff;
    private DragController controller;

    void Start()
    {
        controller = gameObject.GetComponentInParent<DragController>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // transform.SetAsLastSibling();
        controller.SetItem(gameObject);
        diff = new Vector2(transform.position.x, transform.position.y) - eventData.pressPosition;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position + diff;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        controller.DragEnd();
    }

}