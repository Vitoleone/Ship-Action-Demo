using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Ground : MonoBehaviour,IGround
{
    public void GroundHit(GameObject explosionParticle, Vector3 position)
    {
        Instantiate(explosionParticle, position, quaternion.identity);
    }
}
