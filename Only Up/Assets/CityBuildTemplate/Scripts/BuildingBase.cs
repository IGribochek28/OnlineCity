using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBase : MonoBehaviour
{
    public bool block;
    public Vector3 indicatorCorrection;


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Building")
        {
            block = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Building")
        {
            block = true;
        }
    }
}
