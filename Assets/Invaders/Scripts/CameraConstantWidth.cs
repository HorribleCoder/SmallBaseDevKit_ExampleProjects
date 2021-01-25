using UnityEngine;

/// <summary>
/// Взят из репозитории - https://gist.github.com/Glavak/ada99b57023db3c941c5caebe42a70c5
/// </summary>
public class CameraConstantWidth : MonoBehaviour
{
    public Vector2 DefaultResolution = new Vector2(720, 1280);
    [Range(0f, 1f)] public float WidthOrHeight = 0;

    private Camera componentCamera;

    private float initialSize;
    private float targetAspect;

    private float initialFov;
    private float horizontalFov = 120f;

    private void Start()
    {
        componentCamera = GetComponent<Camera>();
        initialSize = componentCamera.orthographicSize;

        targetAspect = DefaultResolution.x / DefaultResolution.y;

        initialFov = componentCamera.fieldOfView;
        horizontalFov = CalcVerticalFov(initialFov, 1 / targetAspect);
    }

    private void Update()
    {
        if (componentCamera.orthographic)
        {
            float constantWidthSize = initialSize * (targetAspect / componentCamera.aspect);
            componentCamera.orthographicSize = Mathf.Lerp(constantWidthSize, initialSize, WidthOrHeight);
        }
        else
        {
            float constantWidthFov = CalcVerticalFov(horizontalFov, componentCamera.aspect);
            componentCamera.fieldOfView = Mathf.Lerp(constantWidthFov, initialFov, WidthOrHeight);
        }
    }

    private float CalcVerticalFov(float hFovInDeg, float aspectRatio)
    {
        float hFovInRads = hFovInDeg * Mathf.Deg2Rad;

        float vFovInRads = 2 * Mathf.Atan(Mathf.Tan(hFovInRads / 2) / aspectRatio);

        return vFovInRads * Mathf.Rad2Deg;
    }
}
