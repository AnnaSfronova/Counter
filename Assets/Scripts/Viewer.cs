using TMPro;
using UnityEngine;

public class Viewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Counter _counter;


    private void OnEnable()
    {
        _counter.Changed += DisplayNumber;
    }

    private void OnDisable()
    {
        _counter.Changed -= DisplayNumber;
    }

    private void DisplayNumber(int number)
    {
        _text.text = number.ToString();
    }
}
