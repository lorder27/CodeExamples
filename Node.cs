using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// The Node.
/// </summary>
public class Node : MonoBehaviour
{
    public GameObject graph;
    public bool connect = false;
    /// <summary>
    /// The connections (neighbors).
    /// </summary>
    [SerializeField]
    protected List<Node> m_Connections = new List<Node>();

    private void Awake()
    {
        graph = GameObject.FindGameObjectWithTag("Graph");
        StartCoroutine(Oscilate());
        if(this.GetComponent<MeshRenderer>().enabled == true)
        {
            this.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    public void CoroutineStart()
    {

        StartCoroutine(Oscilate());
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Node" && other.gameObject != this.gameObject && graph.gameObject.GetComponent<Graph>().setConnections == true && other.GetComponent<Node>().isActiveAndEnabled)
        {

            connections.Add(other.GetComponent<Node>());
            //CheckNodesNeighbor();
        }
        
    }
    /*
    void CheckNodesNeighbor()
    {
        Collider[] hitColliders = Physics.OverlapBox(transform.position,(transform.GetComponent<BoxCollider>().extents /2 ));
        int i = 0;
        while (i < hitColliders.Length)
        {
            if (hitColliders[i].tag == "Node" && hitColliders[i].gameObject != this.gameObject)
            {
                connections.Add(hitColliders[i].GetComponent<Node>());
                i++;
            }
            
        }
    }
    */
    /// <summary>
    /// Gets the connections (neighbors).
    /// </summary>
    /// <value>The connections.</value>
    public virtual List<Node> connections
    {
        get
        {
            return m_Connections;
        }
    }

    public Node this[int index]
    {
        get
        {
            return m_Connections[index];
        }
    }

    void OnValidate()
    {

        // Removing duplicate elements
        m_Connections = m_Connections.Distinct().ToList();
    }

    
    public IEnumerator Oscilate()
    {
        yield return new WaitForSeconds(10);
        connect = false;
        StopCoroutine(Oscilate());
    }
    private void Update()
    {
        if (graph.gameObject.GetComponent<Graph>().setConnections == true && connect ==true)
        {
            this.gameObject.GetComponent<BoxCollider>().size = new Vector3(Mathf.Lerp(4.99f,5.02f,Mathf.PingPong(Time.time,5.02f)),2f, Mathf.Lerp(4.99f, 5.02f, Mathf.PingPong(Time.time, 5.02f)));
            
        }

    }
    

}
