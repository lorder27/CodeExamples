using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMarkers : MonoBehaviour
{
    public GameObject parent;
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Node") 
        {
            parent.GetComponent<Follower>().m_Start = other.gameObject.GetComponent<Node>();
        }
    }
}
