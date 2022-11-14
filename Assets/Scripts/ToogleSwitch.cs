using UnityEngine;
using UnityEngine.UI;

public class ToogleSwitch : MonoBehaviour
{
    [SerializeField] RectTransform uiHandleRectTransform;
    [SerializeField] Color backgroundActiveColor;

    Image   backgroundImage;
    Color   backgroundDefaultColor;
    Toggle  toggle;
    Vector2 handlePosition;

    void Awake()
    {
        toggle = GetComponent<Toggle>();
        handlePosition = uiHandleRectTransform.anchoredPosition;
        backgroundImage = uiHandleRectTransform.parent.GetComponent<Image>();
        backgroundDefaultColor = backgroundImage.color;
        toggle.onValueChanged.AddListener(OnSwitch);

        if (toggle.isOn)
            OnSwitch(true);
    }

    void OnSwitch(bool on)
    {
        uiHandleRectTransform.anchoredPosition = on ? handlePosition * -1 : handlePosition;
        backgroundImage.color = on ? backgroundActiveColor : backgroundDefaultColor;
    }

    void OnDestroy()
    {
        toggle.onValueChanged.RemoveListener(OnSwitch);
    }
}
