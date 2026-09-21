using System.Collections.Generic;
using UnityEngine;

public class StarSystemVisualizer : MonoBehaviour
{
    private StarSystem system;
    private Dictionary<Location, LocationView> _views;
    [SerializeField] private Sprite testSprite;
    [SerializeField] private static float scaleDownFactor = 500f;

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

            Vector2 position = GetVisualPosition(location, elapsedTime);
            LocationView locationView =  gameObject.AddComponent<LocationView>();
            locationView.UpdateData(location, position.x, position.y, gameObject, testSprite);
                
            views[location] = locationView;
        }

        return views;
    }

    private Vector2 GetVisualPosition(Location location, float elapsedTime)
    {
        if (location is IOrbitable orbitable)
        {
            Vector2 simPosition = orbitable.GetCurrentPosition(elapsedTime).ToCartesian();
            return simPosition / scaleDownFactor;
        }

        return Vector2.zero;
    }

    public void UpdateViews(float elapsedTime)
    {
        foreach (var (location, view) in _views)
        {
            if (location is IOrbitable orbitable)
            {
                Vector2 position = GetVisualPosition(location, elapsedTime);
                view.UpdatePosition(position.x, position.y);
            }
        }
    }
    
}
