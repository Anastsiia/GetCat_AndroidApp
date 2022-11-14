using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatInfo
{
    public string   name;
    public string   description;
    public string   color;
    public bool     enable;
    public string   qr_code;

    public static CatInfo CreatedFromJSON(string responce)
    {
        return JsonUtility.FromJson<CatInfo>(responce);
    }
}


