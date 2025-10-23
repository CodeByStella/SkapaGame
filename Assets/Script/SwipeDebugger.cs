using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class SwipeDebugger : MonoBehaviour
{
    [SerializeField]
    public bool _logging;

    [SerializeField]
    public bool _drawSwipe;

    private LineRenderer _lineRenderer;

    private float _zOffset = 10;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();

        SwipeDetector.OnSwipe += DrawSwipe;
        SwipeDetector.OnSwipe += LogSwipee;
    }

    private void DrawSwipe(SwipeData data)
    {
        if (_drawSwipe)
        {
            Vector3[] positions = new Vector3[2];
            positions[0] = Camera.main.ScreenToWorldPoint(new Vector3(data.StartPosition.x, data.StartPosition.y, _zOffset));
            positions[1] = Camera.main.ScreenToWorldPoint(new Vector3(data.EndPosition.x, data.EndPosition.y, _zOffset));
            _lineRenderer.positionCount = 2;
            _lineRenderer.SetPositions(positions);
        }
    }

    private void LogSwipee(SwipeData data)
    {
        if (_logging)
            Debug.Log("Swipe in Direction: " + data.Direction);
    }
}