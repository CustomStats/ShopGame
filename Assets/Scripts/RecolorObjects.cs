using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecolorObjects : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer counter = GameObject.Find("Counter").GetComponent<MeshRenderer>();
        MeshRenderer counterTop = GameObject.Find("CounterTop").GetComponent<MeshRenderer>();
        MeshRenderer floor = GameObject.Find("Floor").GetComponent<MeshRenderer>();
        counter.material.color = Color.grey;
        counterTop.material.color = Color.red;
        floor.material.color = Color.green;
        //transform.GetComponent<MeshRenderer>().material.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
