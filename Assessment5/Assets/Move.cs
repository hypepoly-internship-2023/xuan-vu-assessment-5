using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Move : MonoBehaviour
{
    [SerializeField] protected float raylength;
    [SerializeField] protected LayerMask layerMask;
    [SerializeField] protected Rigidbody rb;
    [SerializeField] public float speed = 2f;
   
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = GetPosition();
            rb.velocity = new Vector3(pos.x -transform.position.x, pos.y - transform.position.y, pos.z - transform.position.z) * speed;
        }
    }

    protected virtual Vector3 GetPosition()
    {
        Vector3 obsPos = new Vector3();
        RaycastHit hit;
        Ray rayCast = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(rayCast, out hit, raylength, layerMask))
        {
            obsPos = hit.collider.transform.position;
        }
        return obsPos;
    }    
}
