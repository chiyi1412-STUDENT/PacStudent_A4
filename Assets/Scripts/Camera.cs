using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

[ExecuteAlways]
public class CameraAutoFit : MonoBehaviour
{
    public Transform root;
    public float padding = 1f;
    Camera cam;
    float lastAspect;

    void OnEnable() { cam = GetComponent<Camera>(); Fit(); }
    void Update() { if (cam && Mathf.Abs(cam.aspect - lastAspect) > 0.001f) Fit(); }
    public void Fit()
    {
        if (!cam) cam = GetComponent<Camera>();
        if (!cam) return;
        cam.orthographic = true;

        Renderer[] renderers;
        if (root) renderers = root.GetComponentsInChildren<Renderer>(true);
        else renderers = FindObjectsOfType<TilemapRenderer>().Cast<Renderer>().ToArray();
        if (renderers.Length == 0) return;

        Bounds b = renderers[0].bounds;
        for (int i = 1; i < renderers.Length; i++) b.Encapsulate(renderers[i].bounds);

        Vector3 c = b.center;
        transform.position = new Vector3(c.x, c.y, -10f);

        float sizeX = b.extents.x / cam.aspect;
        float sizeY = b.extents.y;
        cam.orthographicSize = Mathf.Max(sizeX, sizeY) + padding;

        lastAspect = cam.aspect;
    }
}
