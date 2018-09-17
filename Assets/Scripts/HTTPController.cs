using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class HTTPController : MonoBehaviour
{
    [SerializeField]
    private Text urlText;
    [SerializeField]
    private Text resultText;

    private AlertContoller alert;

    void Start()
    {
    }

    void Update()
    {
    }

    public void OnClick()
    {
        alert = AlertContoller.Show(
            "通信中",
            "しばらくお待ちください"
        );
        StartCoroutine(SendRequest());
    }


    private IEnumerator SendRequest()
    {
        resultText.text = "";

        UnityWebRequest request = UnityWebRequest.Get(urlText.text);
        yield return request.SendWebRequest();

        if (request.isHttpError) {
            resultText.color = Color.red;
            resultText.text =
                "HTTP Error\nStatus code:" +
                request.responseCode + "\n" +
                request.error;
        } else if (request.isNetworkError) {
            resultText.color = Color.red;
            resultText.text = "Network Error\n" + request.error;
        } else {
            resultText.color = Color.black;
            resultText.text = request.downloadHandler.text;
        }

        alert.Dismiss();
    }

}