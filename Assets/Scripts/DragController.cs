using UnityEngine;

public class DragController : MonoBehaviour
{
    private GameObject dragItem;
    private Vector3 savedPos;
    private bool dropped;

    void Update()
    {
    }

    public void SetItem(GameObject item)
    {
        dragItem = item;
        savedPos = dragItem.transform.position;
        dropped = false;
    }

    public void Drop(GameObject dropArea)
    {
        dragItem.transform.position = dropArea.transform.position;
        dropped = true;
    }

    public void DragEnd()
    {
        if (!dropped) {
            dragItem.transform.position = savedPos;
        }
    }

}