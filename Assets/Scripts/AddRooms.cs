using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRooms : MonoBehaviour
{

    private RoomTemplates roomTemplates;

    private void Start()
    {
        roomTemplates = GameObject.Find("RoomTemplates").GetComponent<RoomTemplates>();
        roomTemplates.rooms.Add(this.gameObject);
    }
}
