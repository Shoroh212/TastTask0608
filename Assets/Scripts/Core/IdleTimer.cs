using System;
using UnityEngine;

public class IdleTimer : MonoBehaviour
{
    [SerializeField] private float _idleTime = 30f;

    public float _timer;

    

    private void Awake()
    {
        ResetTimer();
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _idleTime)
        {
            _timer = 0f;
            
        }

        if (Input.GetMouseButton(0))   // ѕровер€ем, была ли нажата лева€ кнопка мыши (не очень по производительности, но дл€ примера сойдет)
        {
            ResetTimer();
        }

    }


    public void ResetTimer()
    {
        _timer = 0f;
    }
}
