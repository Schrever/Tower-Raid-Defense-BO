using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class HelperClose : MonoBehaviour
{
    public GameObject Popup;
    public TextMeshProUGUI Text;

    void Close()
    {
        Popup.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Close();
        }
    }

    public void Open()
    {
        Popup.SetActive(true);
    }

    public void UpdateText(string changeAmount)
    {
        Text.text = changeAmount;
    }
}
