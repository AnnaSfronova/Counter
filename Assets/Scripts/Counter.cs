using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private WaitForSeconds _wait;
    private int _number;
    private float _delay;
    private bool _isMousePressed = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isMousePressed)
            {
                _isMousePressed = false;
                StopCoroutine(Increment());
            }
            else
            {
                _isMousePressed = true;
                StartCoroutine(Increment());
            }
        }
    }

    private IEnumerator Increment()
    {
        _delay = 0.5f;
        _wait = new WaitForSeconds(_delay);

        while (_isMousePressed)
        {
            _number++;
            DisplayNumber(_number);

            yield return _wait;
        }
    }

    private void DisplayNumber(int _number)
    {
        _text.text = _number.ToString();
    }
}
