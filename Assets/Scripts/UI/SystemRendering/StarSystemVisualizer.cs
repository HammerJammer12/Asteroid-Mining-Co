using System.Collections.Generic;
using UnityEngine;

public class StarSystemVisualizer : MonoBehaviour
{
    private StarSystem system;
    private Dictionary<Location, LocationView> _views;
    [SerializeField] private Sprite testSprite;

    public void Init(StarSystem _system)
    {
        system = _system;
        _views = BuildViews((List<Location>)system.Locations);
    }

    private Dictionary<Location, LocationView> BuildViews(List<Location> locations)
    {
        Dictionary<Location, LocationView> views = new Dictionary<Location, LocationView>();
        foreach (var location in locations)
        {
            GameObject gameObject = new GameObject(location.Name);
            gameObject.transform.SetParent(transform);

            SpriteRenderer spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = testSprite;

            float xPos;
            float yPos;

            if (location is IOrbitable orbitable)
            {
                xPos = orbitable.GetCurrentPosition(UniverseClock.universeStartEpoch.Hour).ToCartesian().x;
                yPos = orbitable.GetCurrentPosition(UniverseClock.universeStartEpoch.Hour).ToCartesian().y;
            }
            else
            {
                xPos = 0f;
                yPos = 0f;

            }

            LocationView locationView = new LocationView(location, xPos, yPos, gameObject, testSprite);
            
            spriteRenderer.sortingOrder = 10;
            views[location] = locationView;
        }

        return views;
    }

    public void UpdateViews(double elapsedEpoch)
    {
        
    }
    
}
