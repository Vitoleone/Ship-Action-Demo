using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGround
{
    void GroundHit(GameObject explosionParticle,Vector3 position);
}
