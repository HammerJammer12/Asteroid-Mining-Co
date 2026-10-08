using System;
using TMPro;
using UnityEngine;

public class SelectedLocationText : MonoBehaviour
{
    private TMP_Text text;

    void Awake()
    {
        text = GetComponent<TMP_Text>();
        if (text is null)
        {
            Debug.LogWarning("Selected Location Text TMP_Text Object Not Set");
        }
    }

    public void SetSelectedLocation(Location location)
    {
        text.text = location.Name;
    }

}
