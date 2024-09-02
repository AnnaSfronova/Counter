using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private WaitForSeconds _wait;
    private int _number;
    private float _delay;
    private Coroutine _coroutine;

    public event Action<int> Changed;

    private void Start()
    {
        _delay = 0.5f;
        _wait = new WaitForSeconds(_delay);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) == false)
            return;

        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(Increment());
        }
        else
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private IEnumerator Increment()
    {
        while (true)
        {
            _number++;
            Changed?.Invoke(_number);

            yield return _wait;
        }
    }
}
