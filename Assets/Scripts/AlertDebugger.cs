using UnityEngine;

public class AlertDebugger : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
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