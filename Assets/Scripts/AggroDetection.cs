using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AggroDetection : MonoBehaviour
{
    public event Action<Transform> OnAggro = delegate{};
    private void OnTriggerEnter(Collider target)
    {
        var player = target.GetComponent<PlayerMovement>();

        if(player!=null)
        {
            OnAggro(player.transform);
            
        }
    }
}
