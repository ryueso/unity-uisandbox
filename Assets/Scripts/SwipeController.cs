using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwipeController : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public float speed = 0.2f;
    private ScrollRect scroll;
    private GridLayoutGroup grid;
    private bool moving = false;
    private float startX;
    private float targetX;
    private float itemWidth;
    private float maxPosX;

    void Start()
    {
        scroll = GetComponent<ScrollRect>();
        grid = scroll.content.GetComponent<GridLayoutGroup>();
        itemWidth = grid.cellSize.x + grid.spacing.x;
        maxPosX = -(grid.transform.childCount - 1) * itemWidth;
    }

    void Update()
    {
        if (Application.platform == RuntimePlatform.Android) {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                Application.Quit();
            }
        }

        if (moving) {
            float distance = targetX - scroll.content.anchoredPosition.x;
            float moveTo = scroll.content.anchoredPosition.x + distance * speed;

            if (Mathf.Abs(distance) < 0.01f) {
                moveTo = targetX;
                moving = false;
            }

            scroll.content.anchoredPosition = new Vector2(
                moveTo,
                scroll.content.anchoredPosition.y
            );
        }

    }

    public void OnDrag(PointerEventData eventData)
    {
        if (scroll.content.anchoredPosition.x > 0) {
            scroll.content.anchoredPosition = new Vector2(
                0,
                scroll.content.anchoredPosition.y
            );
        } else if (scroll.content.anchoredPosition.x < maxPosX) {
            scroll.content.anchoredPosition = new Vector2(
                maxPosX,
                scroll.content.anchoredPosition.y
            );
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startX = scroll.content.anchoredPosition.x;
        moving = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        scroll.StopMovement();

        float checkedX;
        if (startX > scroll.content.anchoredPosition.x) {
            // left
            checkedX = -scroll.content.anchoredPosition.x + itemWidth / 5 * 4;
        } else {
            // right
            checkedX = -scroll.content.anchoredPosition.x + itemWidth / 5;
        }

        int index = Mathf.FloorToInt(checkedX / itemWidth);

        if (index < 0) {
            index = 0;
        } else if (index > grid.transform.childCount - 1) {
            index = grid.transform.childCount - 1;
        }

        targetX = -(index * itemWidth);
        moving = true;
    }

}