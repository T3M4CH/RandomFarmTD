using System;
using UnityEngine;
using UnityEngine.EventSystems;
[RequireComponent(typeof(CameraController))]

public class TouchScript : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Highlighter highlighter;
    [SerializeField] private VectorEventChannelSO vectorEventChannel;
    [SerializeField] private CircleController circleController;
    [SerializeField] private IntComplicatedChannel complicatedChannel;
    private bool _awaitingChoice;
    private CameraController cameraController;

    private void Start()
    {
        complicatedChannel.AddRequestListener(() => _awaitingChoice = true);
        cameraController = GetComponent<CameraController>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        GetPoint();
    }
    private void GetPoint()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, layerMask))
        {
            if (raycastHit.transform.TryGetComponent(out IClickable click))
            {
                if (_awaitingChoice)
                {
                    highlighter.DeHighlight();
                    complicatedChannel.RespondRaise(click.GetType(), raycastHit.transform);
                    cameraController.PointToCamera(raycastHit.transform);
                    _awaitingChoice = false;
                    return;
                }
                if (click.GetType() < 3)
                {
                    circleController.MakeCircle(raycastHit.transform.gameObject, true);
                    cameraController.PointToCamera(raycastHit.transform);
                }
                highlighter.Highlight(click);
            }
            else
            {
                if (_awaitingChoice)
                {
                    complicatedChannel.RespondRaise(-1, null);
                    _awaitingChoice = false;
                }
                circleController.ClearCircle();
                highlighter.DeHighlight();
                vectorEventChannel.CallEvent(raycastHit.point);
            }
        }
    }
    private void OnDisable()
    {
        circleController.ClearCircle();
        highlighter.DeHighlight();
    }
}
