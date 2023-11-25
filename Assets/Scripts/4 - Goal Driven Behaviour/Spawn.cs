using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject patientPrefab;
    public int numPatents;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numPatents; i++)
        {
            Instantiate(patientPrefab, this.transform.position, Quaternion.identity);
        }
        Invoke("SpawnPatient", 5);
    }

    void SpawnPatient()
    {
        Instantiate(patientPrefab, this.transform.position, Quaternion.identity);
        Invoke("SpawnPatient", Random.Range(7, 16));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
