using System;
using UnityEngine;
using UnityEngine.UI;

public class AlertContoller : MonoBehaviour
{
    [SerializeField] public Text title;
    [SerializeField] public Text message;
    [SerializeField] public GameObject buttons;
    [SerializeField] public Button okButton;
    [SerializeField] public Button cancelButton;

    private Action okDelegate;
    private Action cancelDelegate;

    public static AlertContoller Show(
        String title,
        String message,
        Action okDelegate = null,
        Action cancelDelegate = null
    )
    {
        GameObject prefab = Resources.Load("Alert") as GameObject;
        GameObject alert = Instantiate(prefab);
        AlertContoller controller = alert.GetComponent<AlertContoller>();
        controller.SetValues(title, message, okDelegate, cancelDelegate);

        return controller;
    }

    public void SetValues(
        String title,
        String message,
        Action okDelegate,
        Action cancelDelegate
    )
    {
        this.title.text = title;
        this.message.text = message;
        this.okDelegate = okDelegate;
        this.cancelDelegate = cancelDelegate;

        if (okDelegate == null && cancelDelegate == null) {
            buttons.gameObject.SetActive(false);
        } else {
            if (okDelegate == null) {
                okButton.gameObject.SetActive(false);
            }

            if (cancelDelegate == null) {
                cancelButton.gameObject.SetActive(false);
            }
        }
    }

    public void OnOK()
    {
        if (okDelegate != null) {
            okDelegate.Invoke();
        }

        Destroy(gameObject);
    }

    public void OnCancel()
    {
        if (cancelDelegate != null) {
            cancelDelegate.Invoke();
        }

        Destroy(gameObject);
    }

    public void Dismiss()
    {
        Destroy(gameObject);
    }

}