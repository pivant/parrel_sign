using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item
{
    public enum TYPE
    {
        NONE = -1,
        DOOR_KEY = 0,
        FALLING_PAD,
        JUMPING_PAD,
        OTHER_OBJECT,
        OTHER_OBJECT_2,
    }
}

public class ItemRoot : MonoBehaviour
{

    public Item.TYPE getItemType(GameObject item_go)
    {
        Item.TYPE type = Item.TYPE.NONE;

        if(item_go != null)
        {
            switch(item_go.tag)
            {
                case "door_kry":type = Item.TYPE.DOOR_KEY; break;
                case "jumping_pad":type = Item.TYPE.JUMPING_PAD; break;
                case "falling_pad":type = Item.TYPE.FALLING_PAD; break;
                
            }
        }


        return (type);
    }


}
