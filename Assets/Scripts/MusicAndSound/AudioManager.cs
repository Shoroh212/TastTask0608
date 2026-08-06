using System;
using UnityEngine;
using Zenject;

public class AudioManager : MonoBehaviour
{
    [Inject]
    [SerializeField] CardScript _cardScript;

    private void OnEnable()
    {
        //_cardScript.PlayClickSound += PlayClick;
    }
    private void OnDisable()
    {
        //_cardScript.PlayClickSound -= PlayClick;
    }

    public void PlayClick()
    {
        Debug.Log("Play Click Sound"); // Здесь можно добавить код для воспроизведения звука клика
    }
}
