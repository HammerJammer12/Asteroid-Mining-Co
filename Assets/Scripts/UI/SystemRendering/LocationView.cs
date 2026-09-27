using System;
using UnityEngine;

public class LocationView : MonoBehaviour
{
    private Location location;
    private float x;
    private float y;
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
        sprite = _sprite;

        if (GetComponent<CircleCollider2D>() == null)
        {
            var collider = gameObject.AddComponent<CircleCollider2D>();
            collider.radius = 0.5f;
        }
    }

    private void OnMouseDown()
    {
        //TODO: setup an onClicked invoke event if this needs to get used for anything more than updating the camera
        CameraController.instance.CenterOnTarget(gameObject.transform);
    }

    public void UpdatePosition(float x, float y) => gameObject.transform.position = new Vector3(x, y, 0f);
}
