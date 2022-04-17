using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] TouchScript touchScript;
    [SerializeField] Canvas canvas;
    private Transform chasePosition;
    Camera cam;

    public void ChangeAccessibly(bool status)
    {
        enabled = status;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        touchScript.enabled = false;
        chasePosition = null;
    }

    public void OnDrag(PointerEventData eventData)
    {
        cam.transform.position += new Vector3(-eventData.delta.x / (canvas.scaleFactor * 15), 0, -eventData.delta.y / (canvas.scaleFactor * 15));
        cam.transform.position = new Vector3(Mathf.Clamp(cam.transform.position.x, 18, 31), cam.transform.position.y, Mathf.Clamp(cam.transform.position.z, 6, 31));
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        touchScript.enabled = true;
    }

    public void PointToCamera(Transform transform)
    {
        if (chasePosition != transform)
            chasePosition = transform;

        cam.transform.position = new Vector3(transform.position.x, cam.transform.position.y, transform.position.z - 7.5f);
    }
    private void Start()
    {
        cam = Camera.main;
    }
    private void Update()
    {
        if (chasePosition != null)
        {
            PointToCamera(chasePosition);
        }
    }
    private void OnDisable()
    {
        chasePosition = null;
    }


}
