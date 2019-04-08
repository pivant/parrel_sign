using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_s
{
    public enum TYPE
    {
        NONE = -1,
        DOOR = 0,
        NUM,
    };
};


public class EventRoot : MonoBehaviour
{

    public Event_s.TYPE getEventType(GameObject event_go)
    {
        Event_s.TYPE type = Event_s.TYPE.NONE;

        if(event_go != null)
        {
            if(event_go.tag == "other_object")
            {
                type = Event_s.TYPE.DOOR;
            }
        }
        return (type);
    }

    public bool isEventIgnitable(Item.TYPE carried_item,GameObject event_go)
    {
        bool ret = false;

        Event_s.TYPE type = Event_s.TYPE.NONE;

        if(event_go != null)
        {
            type = this.getEventType(event_go);
        }

        switch(type)
        {
            case Event_s.TYPE.DOOR:
                if(carried_item == Item.TYPE.DOOR_KEY)
                {
                    ret = true;
                }
                break;
        }
        
      


        return (ret);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
