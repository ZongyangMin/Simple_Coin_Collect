using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danger : MonoBehaviour
{
    private Manager manager;
    public GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        manager = gameManager.GetComponent<Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            manager.gameEnd = true;
        }
    }
}
