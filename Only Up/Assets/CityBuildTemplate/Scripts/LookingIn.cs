using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingIn : MonoBehaviour
{
    public GameObject looking;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Building")
        {
            looking = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Building")
        {
            looking = null;
        }
    }
}
