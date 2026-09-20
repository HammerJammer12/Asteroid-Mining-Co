using System.Collections.Generic;
using UnityEngine;

public class StarSystemVisualizer : MonoBehaviour
{
    private StarSystem system;
    private Dictionary<Location, LocationView> _views;
    [SerializeField] private Sprite testSprite;

    public void Init(StarSystem _system, float elapsedTime)
    {
        system = _system;
        _views = BuildViews(system.Locations, elapsedTime);
    }

    private Dictionary<Location, LocationView> BuildViews(IReadOnlyList<Location> locations, float elapsedTime)
    {
        Dictionary<Location, LocationView> views = new Dictionary<Location, LocationView>();
        foreach (var location in locations)
        {
            GameObject gameObject = new GameObject(location.Name);
            gameObject.transform.SetParent(transform);

            SpriteRenderer spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = testSprite;
            spriteRenderer.sortingOrder = 10;

            Vector2 position = location is IOrbitable orbitable
            ? orbitable.GetCurrentPosition(elapsedTime).ToCartesian()
            : Vector2.zero;

            LocationView locationView =  gameObject.AddComponent<LocationView>();
            locationView.UpdateData(location, position.x, position.y, gameObject, testSprite);
                
            views[location] = locationView;
        }

        return views;
    }

    public void UpdateViews(float elapsedTime)
    {
        foreach (var (location, view) in _views)
        {
            if (location is IOrbitable orbitable)
            {
                Vector2 position = orbitable.GetCurrentPosition(elapsedTime).ToCartesian();
                view.UpdatePosition(position.x, position.y);
            }
        }
    }
    
}
