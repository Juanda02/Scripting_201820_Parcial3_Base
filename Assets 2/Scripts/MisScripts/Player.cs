using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : Actor {

    private Vector3 goal;

    private MeshRenderer render;

    public NavMeshAgent myAgent;

    public Camera myCamera;

    private bool isTagged;


	// Use this for initialization
	void Start () {
        isTagged = false;
        render = GetComponent<MeshRenderer>();
        render.material.color = baseColor;
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButtonDown(0))
        {

            ShootRay();
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy"&&isTagged)
        {
            isTagged = false;
            render.material.color = baseColor;
            GameManager.Instance.NextTagged(id, other.gameObject.GetComponent<Actor>().id,other.gameObject);
            
        }
    }

    public void SetTagged()
    {
        isTagged = true;
        render.material.color = taggedColor;
    }



        private void ShootRay()
    {

        RaycastHit hit;
        Vector3 mouse = myCamera.ScreenToWorldPoint(Input.mousePosition);

       // Debug.Log(mouse);
        Ray ray =  myCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100f))
        {
            if (hit.transform.gameObject.tag == "floor")
            {

               goal = hit.point;
               StartPath();
            }
        }
        
    }

    private void StartPath()
    {
        myAgent.SetDestination(goal);
    }


    
}
