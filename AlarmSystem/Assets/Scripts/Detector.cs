using System;
using UnityEngine;

public class Detector : MonoBehaviour
{
    public event Action HouseLogged;
    public event Action HouseLeft;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<PointMover>(out _))
        {
            HouseLogged?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<PointMover>(out _))
        {
            HouseLeft?.Invoke();
        }
    }
}