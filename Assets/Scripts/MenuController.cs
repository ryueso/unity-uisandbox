using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private float speed = 0.2f;
    [SerializeField] private Button opener;
    [SerializeField] private Button background;
    [SerializeField] private GameObject items;
    [SerializeField] private Button baseItem;
    private float targetX;
    private bool moving;

    private void MoveMenu(float posx)
    {
        targetX = posx;
        moving = true;
    }

    private void CloseMenu()
    {
        MoveMenu(-400);
        background.GetComponent<Image>().raycastTarget = false;
    }

    public void AddMenu(String text, Action action)
    {
        Button clone = Instantiate(baseItem);
        clone.gameObject.SetActive(true);
        clone.onClick.AddListener((() =>
        {
            action.Invoke();
            CloseMenu();
        }));
        clone.GetComponentInChildren<Text>().text = text;
        clone.transform.SetParent(items.transform);
    }

    void Start()
    {
        opener.onClick.AddListener((() =>
        {
            background.GetComponent<Image>().raycastTarget = true;
            MoveMenu(0);
        }));
        background.onClick.AddListener((() => { CloseMenu(); }));

        AddMenu("アラート", (() => { SceneManager.LoadScene("Alert"); }));
        AddMenu("ドラッグ＆ドロップ", (() => { SceneManager.LoadScene("Drag"); }));
        AddMenu("スクロール", (() => { SceneManager.LoadScene("Scroll"); }));
        AddMenu("スワイプ", (() => { SceneManager.LoadScene("Swipe"); }));
        AddMenu("タブバー", (() => { SceneManager.LoadScene("Tab"); }));
    }

    void Update()
    {
        if (Application.platform == RuntimePlatform.Android) {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                Application.Quit();
            }
        }

        if (moving) {
            float distance = targetX - gameObject.transform.position.x;
            float moveTo = gameObject.transform.position.x + distance * speed;

            if (Mathf.Abs(distance) < 0.01f) {
                moveTo = targetX;
                moving = false;
            }

            Vector3 pos = gameObject.transform.position;
            pos.x = moveTo;
            gameObject.transform.position = pos;
        }
    }

}