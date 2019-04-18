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

    public GameObject pannelPrefab = null;
    public GameObject doorkeyPrefab = null;

    public PlayerMove playermove = null;

    protected List<Vector3> respawn_points;

    public float step_timer = 0.0f;

    public float RESPAWN_TIME_PANNEL = 2.0F;
    public float RESPAWN_TIME_PANNEL_02 = 2.0F;

    public static float RESPAWN_TIME_DOORKEY = 8.0F;

    private float respawn_timer_pannel = 0.0f;
    private float respawn_timer_doorkey = 0.0f;



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

    public void respawnPannel()
    {
        GameObject go =
            GameObject.Instantiate(this.pannelPrefab) as GameObject;

        Vector3 pos = GameObject.Find("pannel_spawner").transform.position;

        go.transform.position = pos;

    }

    void Start()
    {
        this.playermove = GameObject.Find("Player").GetComponent<PlayerMove>();

        // 리스폰 포인트의 게임 오브젝트를 찾아서 좌표를 배열로 해둔다.
        this.respawn_points = new List<Vector3>();  // list
        GameObject[] respawns = GameObject.FindGameObjectsWithTag("object_spawner");   // ItemRespawn(TAG)
        foreach (GameObject go in respawns)
        {
            // 메시는 비표시로 한다.
            MeshRenderer renderer = go.GetComponentInChildren<MeshRenderer>();
            if (renderer != null)
            {
                renderer.enabled = false;
            }
            this.respawn_points.Add(go.transform.position);
        }


        // GameObject applerespawn = GameObject.Find("AppleRespawn");
        // applerespawn.GetComponentInChildren<MeshRenderer>().enabled = false;
        GameObject pannelrespawn = GameObject.Find("pannel_spawner");
        pannelrespawn.GetComponentInChildren<MeshRenderer>().enabled = false;

        this.respawnPannel();
    }

    void Update()
    {
        // respawn_timer_apple	+= Time.deltaTime;
        respawn_timer_pannel += Time.deltaTime;
        //respawn_timer_plant += Time.deltaTime;

        // 사과의 리스폰은 treeControl로 이동했다-----.
        /*
		if(respawn_timer_apple > RESPAWN_TIME_APPLE){
			respawn_timer_apple = 0.0f;
			this.respawnApple();
		}
		*/
        if (respawn_timer_pannel > RESPAWN_TIME_PANNEL)
        {
            respawn_timer_pannel = 0.0f;
            this.respawnPannel();
        }

        if (playermove.slowChecker == true)
        {
            RESPAWN_TIME_PANNEL = 6.0f;
        }
        else
        {
            RESPAWN_TIME_PANNEL -= Time.fixedDeltaTime;
            RESPAWN_TIME_PANNEL = Mathf.Clamp(RESPAWN_TIME_PANNEL, 2.0f, 6.0f);
        }



        //if (respawn_timer_plant > RESPAWN_TIME_PLANT)
        //{
        //    respawn_timer_plant = 0.0f;
        //    this.respawnPlant();
        //}
    }


}
