using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApplyColor : MonoBehaviour
{
    public FlexibleColorPicker  fcp;
    public GameObject           colorPickerPanel;
    private Image               button;

    private void Start()
    {
        button = GameObject.Find("ColorButton").GetComponent<Image>();
        fcp.color = button.color;
        GameObject.Find("ColorButton").GetComponent<Button>().onClick.AddListener(OnColorButtonClick);
        GameObject.Find("GetCatButton").GetComponent<Button>().onClick.AddListener(OnGetCatButtonClick);
    }

    private void Update()
    {
        if (colorPickerPanel.activeSelf == true)
            button.color = fcp.color;
    }

    void OnColorButtonClick()
    {
        if (colorPickerPanel.activeSelf == false)
            colorPickerPanel.SetActive(true);
        else
            colorPickerPanel.SetActive(false);
    }

    void OnGetCatButtonClick()
    {
        if (colorPickerPanel.activeSelf == true)
            colorPickerPanel.SetActive(false);
    }
}
