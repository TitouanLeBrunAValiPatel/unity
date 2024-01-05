using UnityEngine;

public class BlockDestroyer : MonoBehaviour
{
    private Camera _mainCamera;
    private float destroyDistance = 10f;

    void Start()
    {
        _mainCamera = Camera.current;
    }

    void OnBecameInvisible()
    {
        if (IsObjectFarFromCamera())
        {
            Destroy(gameObject);
        }
    }

    bool IsObjectFarFromCamera()
    {
        if (_mainCamera == null) return false;

        float distanceToCamera = Vector3.Distance(transform.position, _mainCamera.transform.position);

        return distanceToCamera > (_mainCamera.farClipPlane + destroyDistance);
    }
}