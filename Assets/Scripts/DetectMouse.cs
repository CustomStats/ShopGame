using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectMouse : MonoBehaviour
{
    public Camera myCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;

            Ray myRay = myCamera.ScreenPointToRay(mousePosition);
            RaycastHit raycastHit;
            bool hitSomething = Physics.Raycast(myRay, out raycastHit);

            if (hitSomething)
            {
                Debug.Log(raycastHit.transform.name);
                raycastHit.transform.GetComponent<MeshRenderer>().material.color = Color.yellow;
            }
            else
            {
                Debug.Log("We didn't hit");
            }
        }
    }
}
