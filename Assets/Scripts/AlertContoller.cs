using System;
using UnityEngine;
using UnityEngine.UI;

public class AlertContoller : MonoBehaviour
{
    [SerializeField] public Text title;
    [SerializeField] public Text message;

    private Action okDelegate;
    private Action cancelDelegate;

    public static void Show(
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
}