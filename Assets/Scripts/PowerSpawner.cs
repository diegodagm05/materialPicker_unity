using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSpawner : MonoBehaviour
{
    public GameObject powers;
    public float xPos, yPos;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PowerSpawn());
    }

    IEnumerator PowerSpawn()
    {
        while (true)
        {
                                                       
            xPos = Random.Range(-8, 8);
            yPos = 6;
            
            Instantiate(powers, new Vector3(xPos, yPos, 0), Quaternion.identity);
                            
            yield return new WaitForSeconds(15);
        }
    }
}