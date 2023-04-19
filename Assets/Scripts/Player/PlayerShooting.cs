using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Rocket rocketPrefab;
    private ObjectPool<Rocket> pooledRockets;

    void Start()
    {
        pooledRockets = new ObjectPool<Rocket>(() =>
            {
                return Instantiate(rocketPrefab); //When we ask the object this function will run.
            }, rocket =>
            {
                rocket.gameObject.SetActive(true); //When we get the object this function will run.
            },
            rocket =>
            {
                rocket.gameObject.SetActive(false); //When we are done with object this function will run.
            },
            rocket =>
            {
                Destroy(rocket.gameObject); //When we need to destroy an object this function will run.
            },false,10,20);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        var rocket = pooledRockets.Get();
        rocket.transform.position = transform.position + 2*Vector3.down;
        rocket.Init(ExplodeRocket);
    }

    void ExplodeRocket(Rocket rocket)
    {
        pooledRockets.Release(rocket);
        rocket.transform.position = transform.position + 2*Vector3.down;
    }
}