using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float rate;
    [Range(0, 1)]
    public float chance;
    public GameObject[] objects;

	void Start()
    {
        Invoke("Spawn", rate);
	}
	
	void Spawn()
    {
        if (Random.value <= chance)
            Instantiate(objects[Random.Range(0, objects.Length)], transform.position, Quaternion.identity);

        Invoke("Spawn", rate);
    }
}
