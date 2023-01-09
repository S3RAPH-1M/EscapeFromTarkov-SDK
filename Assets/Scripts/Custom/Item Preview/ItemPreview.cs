using System.Linq;
using UnityEngine;

public class ItemPreview : MonoBehaviour
{
    public Camera previewCamera;
    public Transform previewPivot;
    [SerializeField] private Transform rotator;
    [SerializeField] private GameObject itemPreviewLights;
    [SerializeField] private GameObject iconGeneratorLights;
    private float float_0;
    private float float_1;
    
    public static Bounds GetBounds(GameObject item)
    {
        var bounds = item.GetComponentsInChildren<Renderer>(false)
            .Where(r => !r.name.Contains("linza") && r.name != "MuzzleJetCombinedMesh").Select(r => r.bounds)
            .Where(b => b.extents != Vector3.zero);
        var boundsArray = bounds as Bounds[] ?? bounds.ToArray();
        return !boundsArray.Any() ? default : boundsArray.Aggregate(Encapsulate);
    }
    
    private static Bounds Encapsulate(Bounds current, Bounds next)
    {
        current.Encapsulate(next);
        return current;
    }

    public void ChangeLights()
    {
        itemPreviewLights.SetActive(!itemPreviewLights.activeSelf);
        iconGeneratorLights.SetActive(!iconGeneratorLights.activeSelf);
    }
    
    public void ResetRotator(float defaultZ)
    {
        if (previewCamera == null)
        {
            return;
        }
        rotator.localRotation = Quaternion.identity;
        Transform transform = this.previewCamera.transform;
        Vector3 position = transform.position;
        position = new Vector3(position.x, position.y, 0f);
        transform.position = position;
        Vector3 localPosition = transform.localPosition;
        localPosition.z = defaultZ;
        transform.localPosition = localPosition;
        float_0 = 0f;
        float_1 = 0f;
    }

    public void Rotate(float angle, float tilt = 0f, float minTilt = -30f, float maxTilt = 30f)
    {
        if (rotator == null)
        {
            return;
        }
        float_0 -= angle * 0.3f;
        if (float_0 >= 360f)
        {
            float_0 -= 360f;
        }
        else if (float_0 < -360f)
        {
            float_0 += 360f;
        }
        int num = Mathf.Cos(0.0174532924f * this.float_0) >= 0f ? 1 : -1;
        float_1 += tilt * 0.3f * num;
        if (Mathf.Abs(minTilt) > Mathf.Epsilon && Mathf.Abs(maxTilt) > Mathf.Epsilon)
        {
            float_1 = Mathf.Clamp(float_1, minTilt, maxTilt);
        }
        rotator.localRotation = Quaternion.Euler(float_1, float_0, 0f);
    }

    public void Zoom(float zoom)
    {
        Transform transform = previewCamera.transform;
        transform.Translate(new Vector3(0f, 0f, zoom));
        if (zoom > 0f)
        {
            transform.Translate(new Vector3(0f, 0f, -0.01f));
        }
        Vector3 localPosition = transform.localPosition;
        localPosition.z = Mathf.Clamp(localPosition.z, -2.7f, -0.45f);
        transform.localPosition = localPosition;
    }

}
