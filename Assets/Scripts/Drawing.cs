using System;
using System.Collections.Generic;
using UnityEngine;

public class Drawing : MonoBehaviour
{
    [SerializeField] Vector3[] LRPositions = { };
    LineRenderer lineRenderer;
    [SerializeField] GameObject colliderPF;
    [SerializeField] private Material material;
    [SerializeField] private Camera cam2; //for drawing

    private Transform arm;
    private GameObject leg;
    public List<Vector3> drawPositions;
    private Vector3 lastMousePos;
    private Vector3 currentMousePos;
    public static Action DrawingEndedAction;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Start()
    {
        arm = GameObject.Find("Arm").transform;
    }


    void Update()
    {
        currentMousePos = Input.mousePosition;
        currentMousePos.z = 30;
        currentMousePos = Camera.main.ScreenToWorldPoint(currentMousePos);

        DrawLine();
    }
    void DrawLine()
    {

        if (Input.GetMouseButtonDown(0))
        {
            lineRenderer.positionCount = 0;
            drawPositions.Clear();
            lastMousePos = currentMousePos;
            drawPositions.Add(currentMousePos);
            lineRenderer.positionCount = drawPositions.Count;
            lineRenderer.SetPositions(drawPositions.ToArray());

        }
        else if (Input.GetMouseButton(0))
        {
            float distance = Vector2.Distance(currentMousePos, lastMousePos);

            if (distance > .2f)
            {
                Debug.Log(distance);
                lastMousePos = currentMousePos;

                drawPositions.Add(lastMousePos);
                lineRenderer.positionCount = drawPositions.Count;

                lineRenderer.SetPositions(drawPositions.ToArray());


            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            ClearLeg();
            GetLineRendererPositions();
            CreateColliders();
            CreateLegComponents();

            DrawingEndedAction?.Invoke();

            //lineRenderer.enabled = false;
        }
    }

    void ClearLeg()
    {
        Destroy(leg);
    }

    void GetLineRendererPositions()
    {
        //Debug.Log(lineRenderer.positionCount);
        LRPositions = new Vector3[lineRenderer.positionCount];
        lineRenderer.GetPositions(LRPositions);

        //Get the distance from zero
        // Substract and make it relative to the point zero.
        float deltaX = LRPositions[0].x;
        float deltaY = LRPositions[0].y;

        for (int i = 0; i < LRPositions.Length; i++)
        {
            Vector3 position = LRPositions[i];
            Vector3 newPosition = new Vector3(position.x - deltaX, position.y - deltaY, 0);

            LRPositions[i] = newPosition;
        }

    }

    void CreateColliders()
    {
        leg = new GameObject();
        leg.name = "Leg";
        Vector3 currentPos = new Vector3(-50, -50, -50);
        float distance = 0.5f;

        foreach (Vector3 position in LRPositions)
        {

            if (currentPos != new Vector3(-50, -50, -50))
            {
                distance = Vector3.Distance(position, currentPos);
            }
            if (distance > .25f)
            {

                position.Set(position.x, position.y, 0);
                Instantiate(colliderPF, position, Quaternion.identity, leg.transform);
                currentPos = position;
            }
        }

        //Set them as childs of the arm slots
        leg.transform.parent = arm;

        leg.transform.localScale = new Vector3(1, 1, 1);


        //Legs position
        leg.transform.localPosition = new Vector3(0.2f, 0.2f, 0.2f);



    }

    void CreateLegComponents()
    {
        leg.AddComponent<LineRenderer>().positionCount = lineRenderer.positionCount;
        leg.GetComponent<LineRenderer>().useWorldSpace = false;
        leg.GetComponent<LineRenderer>().SetPositions(LRPositions);
        leg.GetComponent<LineRenderer>().startWidth = .2f;
        leg.GetComponent<LineRenderer>().endWidth = .2f;
        leg.GetComponent<LineRenderer>().material = material;

    }


}
