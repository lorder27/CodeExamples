using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableNode : MonoBehaviour
{
    private bool setConnectionsBool = false;
    public GameObject[] Nodes;




    void OnTriggerEnter(Collider theCollision)
    {
        if(theCollision != this)
        {
            if (theCollision.tag == "Obstacle" || theCollision.tag == "Building")

            {
                gameObject.GetComponent<Node>().connections.Clear();
                gameObject.GetComponent<Node>().enabled = false;
                
            }
            if (theCollision.tag == "Node")
            {
                gameObject.GetComponent<Node>().connections.Add(theCollision.gameObject.GetComponent<Node>());
            }
        }

        else
        {
            if (theCollision.tag == "Node")
            {
                theCollision.gameObject.SetActive(false);
                Debug.Log("Disabled");
            }
        }
        
        
    }

    void OnTriggerExit(Collider theCollision)
    {

        if (theCollision.tag == "Obstacle" || theCollision.tag == "Building")

        {
            gameObject.GetComponent<Node>().enabled = true;
            gameObject.GetComponent<Node>().connect = true;
            gameObject.GetComponent<Node>().CoroutineStart();

        }
    }
}
