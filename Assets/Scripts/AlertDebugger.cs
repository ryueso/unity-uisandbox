using UnityEngine;

public class AlertDebugger : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
        if (Application.platform == RuntimePlatform.Android) {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                Application.Quit();
            }
        }
    }

    public void ShowAlert()
    {
        AlertContoller.Show(
            "タイトルなり",
            "だるまさんがころんだ。だるまさんがころんだ。だるまさんがころんだ。",
            () => { Debug.Log("ok"); },
            () => { Debug.Log("cancel"); }
        );
    }
}