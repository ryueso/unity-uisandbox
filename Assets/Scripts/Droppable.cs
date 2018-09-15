using UnityEngine;
using UnityEngine.EventSystems;

public class Droppable : MonoBehaviour, IDropHandler
{
    private DragController controller;

    void Start()
    {
        controller = gameObject.GetComponentInParent<DragController>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        controller.Drop(gameObject);
    }

}