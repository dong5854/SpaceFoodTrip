using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using TMPro;

public class LoginData {
    public string email;
    public string pw;
}

public class LoginManager : MonoBehaviour
{
    public TMP_InputField loginEmail;
    public TMP_InputField loginPw;

    public void SendRequestOnClick()
    {
        Debug.Log("clicked");
        string loginEmailValue = loginEmail.text;
        string loginPwValue = loginPw.text;

        LoginData loginData = new LoginData();
        loginData.email = loginEmailValue;
        loginData.pw = loginPwValue;

        string url = "http://localhost:8080/user/login";

        StartCoroutine(LoginPost(url, JsonUtility.ToJson(loginData)));
    }

    IEnumerator LoginPost(string url, string jsonString)
    {
        Debug.Log("jsonString" + jsonString);
        UnityWebRequest request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonString);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string jwtAuthToken = request.GetResponseHeader("Authorization");
            string message = request.downloadHandler.text;
            Debug.Log("메시지: " + message);
            Debug.Log("토큰 값: " + jwtAuthToken);
        }
    }
}
