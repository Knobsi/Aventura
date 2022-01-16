using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{

    [TextArea]
    [Header("SortList")]
    [Tooltip("1 --> need buttom door \n 2 --> need top door \n 3 --> need left door \n 4 --> need right door")]
    public string tip;

    public int openingDirection;

    private RoomTemplates templates;
    private int rand;
    public bool spawned = false;

     void Start()
    {
        templates = GameObject.Find("RoomTemplates").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }

     void Spawn()
    {
        if(!spawned)
        {
            if (openingDirection == 1)
            {
                //Need to spawn a room whit a buttom door
                rand = Random.Range(0, templates.BottomRooms.Length -1);
                Instantiate(templates.BottomRooms[rand], transform.position, templates.BottomRooms[rand].transform.rotation);
            }
            else if (openingDirection == 2)
            {
                //Need to spawn a room whit a top door
                rand = Random.Range(0, templates.TopRooms.Length -1);
                Instantiate(templates.TopRooms[rand], transform.position, templates.TopRooms[rand].transform.rotation);
            }
            else if (openingDirection == 3)
            {
                //Need to spawn a room whit a left door
                rand = Random.Range(0, templates.LeftRooms.Length -1);
                Instantiate(templates.LeftRooms[rand], transform.position, templates.LeftRooms[rand].transform.rotation);
            }
            else if (openingDirection == 4)
            {
                //Need to spawn a room whit a right door
                rand = Random.Range(0, templates.RightRooms.Length -1);
                Instantiate(templates.RightRooms[rand], transform.position, templates.RightRooms[rand].transform.rotation);
            }
            spawned = true;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Base"))
        {
            Destroy(gameObject);
        }
    }
}
