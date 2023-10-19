using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : PointsManager
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            Destroy(gameObject);
            points += 1;
            Debug.Log(points + " points");
        }
    }
}
