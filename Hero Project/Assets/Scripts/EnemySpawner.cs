using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject [] planePrefab;

    // Start is called before the first frame update
    void Start()
    {
        // planePrefab = new GameObject [10];

        for(int i = 0; i < 10; i++){

            Instantiate(planePrefab[i], new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6f), 0), new Quaternion(0, 0, 0, 1));
        
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
