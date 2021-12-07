using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishArea : MonoBehaviour
{
    [SerializeField] private List<Confetti> _confettiFirecracker;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Player player))
        {
            foreach (var firecracker in _confettiFirecracker)
            {
                firecracker.Shoot();
            }
        }
    }
}
