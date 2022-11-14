using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using TMPro;

public class GetCatMethod : MonoBehaviour
{
    TMP_InputField  descriptionArea;
    Text            nameArea;
    Toggle          isEnable;
    Image           colorArea;
    Image           QRCodeArea;
    string          responce;

    void Start()
    {
        descriptionArea = GameObject.Find("Description").GetComponent<TMP_InputField>();
        nameArea = GameObject.Find("NameTitle").GetComponent<Text>();
        isEnable = GameObject.Find("ToggleSwitch").GetComponent<Toggle>();
        colorArea = GameObject.Find("ColorButton").GetComponent<Image>();
        QRCodeArea = GameObject.Find("QRCode").GetComponent<Image>();

        GameObject.Find("GetCatButton").GetComponent<Button>().onClick.AddListener(PostData);
    }

    void PostData() => StartCoroutine(PostData_Coroutine());

    IEnumerator PostData_Coroutine()
    {
        //sending POST request
        string uri = "https://pusbkbbia3.execute-api.us-east-1.amazonaws.com/default/get_cat?name=Anastasiia";
        WWWForm form = new WWWForm();
        using (UnityWebRequest request = UnityWebRequest.Post(uri, form))
        {
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
                Debug.Log(request.error);
            else
                responce = request.downloadHandler.text;
        }

        //responce processing
        CatInfo obj = CatInfo.CreatedFromJSON(responce);
        descriptionArea.text = obj.description;
        nameArea.text = obj.name;
        isEnable.isOn = obj.enable;
        if (ColorUtility.TryParseHtmlString("#" + obj.color, out Color requestColor))
            colorArea.color = requestColor;

        //building QRCode block
        GameObject.Find("QRCodeTitle").SetActive(false);
        QRCodeArea.color = Color.white;
        byte[] imageBytes = Convert.FromBase64String(obj.qr_code);
        Texture2D tex = new Texture2D(2, 2);
        tex.LoadImage(imageBytes);
        QRCodeArea.sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);

    }

}
