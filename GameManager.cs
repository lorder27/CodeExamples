using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject[] floor1Nodes;
    public GameObject[] floor1Tiles;
    public GameObject[] KeyMarkers;
    public GameObject exitDoor;
    public GameObject KeyText;
    public GameObject gameOverText;
    public GameObject startText;
    public bool exit = false;
    public int keyCount = 0;
    private int number = 0;
    private int rgn;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i<KeyMarkers.Length; i++)
        {
            if (KeyMarkers[i].GetComponent<MarkerNumber>().awardable == true)
            {
                keyCount++;
                Debug.Log(KeyMarkers[i].GetComponent<MarkerNumber>().awardable);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.PageDown))
        {
            for (int i = 0; i < floor1Nodes.Length; i++)
                floor1Nodes[i].layer = 2;

            for (int i = 0; i < floor1Tiles.Length; i++)
                floor1Tiles[i].SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.PageUp))
        {
            for (int i = 0; i < floor1Nodes.Length; i++)
                floor1Nodes[i].layer = 0;

            for (int i = 0; i < floor1Tiles.Length; i++)
                floor1Tiles[i].SetActive(true);
        }
        if (keyCount == 0)
        {
            exit = true;
        }
        if (exit == true)
        {
            exitDoor.SetActive(true);
        }
        KeyText.GetComponent<UnityEngine.UI.Text>().text = "Keys remaining: " +keyCount.ToString();
        if (Input.GetKeyDown(KeyCode.F10))
        {
            SceneManager.LoadScene("Main2");
        }
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.F))
        {
            startText.SetActive(false);
        }
    }
    
}
