using UnityEngine;

public class Drawing : MonoBehaviour
{
    public GameObject drawPrefab;
    private GameObject theTrail;
    
    private Plane planeObject;
    private Camera cam;
    private Transform camTransform;
    private Vector3 mousePosition;
    private Vector3 drawManagerPosition;
    private Ray ray;
    private Vector3 startPos;
    public TrailRenderer trailRenderer;
    private float hit;
    
    private void Start()
    {
        Debug.Log("Height: " + Screen.height + "Width: "+ Screen.width);
        trailRenderer.sortingOrder = 0;
        cam = Camera.main;
        if (cam != null)
        {
            camTransform = cam.transform;
            planeObject = new Plane(camTransform.forward * -1, transform.position);
        }
    }

    private void Update()
    {
        mousePosition = Input.mousePosition;
        transform.position = cam.ScreenToWorldPoint(mousePosition);
        float offset = 20f;
        if (mousePosition.y <= Screen.height + offset && mousePosition.y >= 0 - offset &&
            mousePosition.x <= Screen.width + offset && mousePosition.x >= 0 - offset)
        {
            Debug.Log(mousePosition);
            if (Input.GetMouseButtonDown(0))
            {
                trailRenderer.sortingOrder += 1;
                theTrail = Instantiate(drawPrefab, transform.position, Quaternion.identity);
                RayStuff();
            }
            else if (Input.GetMouseButton(0))
            {
                RayStuff();
            }
        }
    }

    private void RayStuff()
    {
        ray = cam.ScreenPointToRay(mousePosition);
        if (planeObject.Raycast(ray, out hit))
        {
            theTrail.transform.position = ray.GetPoint(hit);
        }
    }
    
    
    /*float DistanceToLastPoint(Vector3 point)
    {
        if (!points.Any())
            return Mathf.Infinity;

        float distance = Vector3.Distance(points.Last(), point);
        return distance;
    }

    void Raycasting()
    {
        ray = camera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray,out hit))
        {
            if (hit.transform.CompareTag("Ground") && DistanceToLastPoint(hit.point) > .25f)
            {
                Vector3 point = new Vector3(hit.point.x, 1.1f, hit.point.z);
                points.Add(point);
                lineRenderer.positionCount = points.Count;
                lineRenderer.SetPositions(points.ToArray());
            }
        }
    }*/
    
    
    /*[SerializeField] Camera camera;
    [SerializeField] Material lineMaterial;

    // Drawing
    LineRenderer lineRenderer;
    List<Vector3> points = new List<Vector3>();
    
    // Raycasting
    Ray ray;
    RaycastHit hit;

    #endregion

    #region MonoBehaviour Callbacks

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.material = lineMaterial;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!GameManager.Instance.isGameStarted)
                GameManager.Instance.StartGame();
            points.Clear();
            lineRenderer.enabled = true;
        }
        if (Input.GetMouseButton(0))
            Raycasting();
        else if (Input.GetMouseButtonUp(0))
        {
            OnNewPathCreated(points);
            PathManager.Instance.NextPathDrawing();
        }
    }*/
}
