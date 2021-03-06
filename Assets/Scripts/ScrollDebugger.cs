﻿using UnityEngine;
using UnityEngine.UI;

public class ScrollDebugger : MonoBehaviour
{
    [SerializeField] private GameObject Item;

    void Start()
    {
        for (int i = 0; i < 100; i++) {
            GameObject button = Instantiate(Item);
            button.transform.SetParent(gameObject.transform);
            Text text = button.gameObject.GetComponentInChildren<Text>();
            text.text = "ボタン" + (i + 1);
        }
    }

    void Update()
    {
    }
}