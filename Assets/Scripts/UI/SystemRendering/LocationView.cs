using UnityEngine;

public class LocationView : MonoBehaviour
{
    private Location location;
    private float x;
    private float y;
    private GameObject gameobject;
    private Sprite sprite;

    public void UpdateData(
        Location _location, 
        float startingX, 
        float startingY, 
        GameObject _gameObject,
        Sprite _sprite
        )
    {
        location = _location;
        x = startingX;
        y = startingY;
        gameobject = _gameObject;
        sprite = _sprite;
    }

    public void UpdatePosition(float x, float y) => gameObject.transform.position = new Vector3(x, y, 0f);
}
