using TMPro;
using UnityEngine;

public class ShipStatusText : MonoBehaviour
{
    private TMP_Text _text;
    public void UpdateText(string statusText)
    {
        if (_text is null)
        {
            _text = GetComponent<TMP_Text>();
        }

        _text.text = statusText;
    }
}
