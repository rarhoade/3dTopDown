using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{

    public Camera cam;
    public NavMeshAgent agent;
    public LineRenderer previewLine;
    private NavMeshPath path;
    public bool previewing = true;
    public Vector3 destination;
    public int actionPointCost = 0;
    public GameObject actionPointDisplay;
    // Update is called once per frame
    void Start()
    {
        path = new NavMeshPath();
    }

    void Update()
    {
        actionPointCost = 0;
        if (transform.position.x == destination.x  && transform.position.z == destination.z && previewing == false)
        {
            previewing = true;
        }
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool hasHit = Physics.Raycast(ray, out hit);
        NavMesh.CalculatePath(transform.position, hit.point, NavMesh.AllAreas, path);
        for(int i = 0; i < path.corners.Length - 1; i++)
        {
            Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.red);
            actionPointCost += (int)Vector3.Distance(path.corners[i], path.corners[i + 1]);
        }
        if (previewing)
        {
            previewLine.positionCount = path.corners.Length;
            previewLine.SetPositions(path.corners);  
        }
        if (Input.GetMouseButtonDown(0))
        {
            if(hasHit && previewing)
            {
                //Move agent
                destination = hit.point;
                agent.SetDestination(hit.point);
                previewing = false;
            }
        }
        actionPointCost /= 10;
        actionPointDisplay.GetComponent<TextFollowMouse>().updateText(actionPointCost.ToString());
    }
}
