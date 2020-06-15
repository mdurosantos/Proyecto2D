using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCollider : MonoBehaviour
{
    private Door door;
    private void Start()
    {
        door = GetComponentInParent<Door>();
    }
    void deactivateCollider()
    {
        door.CollidersActive(false);
    }
}
