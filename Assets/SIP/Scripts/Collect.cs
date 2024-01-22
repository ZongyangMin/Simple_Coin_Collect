using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    private Manager manager;
    public GameObject gameManager;
    public AudioClip collectCoinClip;
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
            col.GetComponent<Player>().PlaySound(collectCoinClip);
            col.GetComponent<Player>().createVFX();
            manager.countCoins++;
            Destroy(this.gameObject);
        }
    }
}
