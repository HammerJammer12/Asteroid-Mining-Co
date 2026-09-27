using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    private Camera camera;
    private Transform target;

    [Header("Zoom Settings")]
    [Tooltip("How fast the camera zooms in and out.")]
    public float zoomSensitivity = 0.05f;
    
    [Tooltip("The closest the camera can get.")]
    public float minZoom = 2f;
    
    [Tooltip("The furthest the camera can back away.")]
    public float maxZoom = 20f;

    void Awake()
    {
        instance = this;
        camera = GetComponent<Camera>();
    }

    public void CenterOnTarget(Transform _target)
    {
        target = _target;
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    }

    void Update()
    {
        Vector2 scrollDelta = Mouse.current.scroll.ReadValue();
        if (scrollDelta.y != 0)
        {
            float targetZoom = camera.orthographicSize - (scrollDelta.y * zoomSensitivity);
            camera.orthographicSize = Mathf.Clamp(targetZoom, minZoom, maxZoom);
        }

        if (target != null)
        {
            CenterOnTarget(target);
        }
    }
}
