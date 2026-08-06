using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfoPanel : MonoBehaviour, ICardReceiver
{
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _currentText;

    public void Receive(Information information)
    {
        Debug.Log("$" + information);
        _currentText.text = information.text;

        // Если есть картинка
        // _image.sprite = information.sprite;
    }
}