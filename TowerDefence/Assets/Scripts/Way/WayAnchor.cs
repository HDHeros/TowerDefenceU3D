using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayAnchor : MonoBehaviour
{
    [SerializeField] private GameObject nextAnchor;

    public GameObject GetNextAnchor()
    {
        return nextAnchor;
    }
}
