using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;

    public float minX, maxX, interval, speed;
    void Start()
    {
        InvokeRepeating("spawn", interval, interval); 
    }

    
    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime; 
    }

    private void spawn()
    {
        GameObject newPlat = Instantiate(prefab);
        newPlat.transform.position = new Vector2(
            Random.Range(minX, maxX),
            transform.position.y + (Random.Range(0.5f, 1f)));
    }
}
