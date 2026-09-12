using TMPro;
using UnityEngine;

public class ShipNumber : MonoBehaviour
{
    private TMP_Text _text;
    public void UpdateText(int number)
    {
        if (_text is null)
        {
            _text = GetComponent<TMP_Text>();
        }

        _text.text = $"{number} : ";
    }
}