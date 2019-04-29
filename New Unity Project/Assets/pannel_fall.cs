using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pannel_fall : MonoBehaviour
{
    public GameObject pannelPrefab = null;
    public PlayerMove playermove = null;
    protected List<Vector3> respawn_points;
    public float step_timer = 0.0f;

    public float RESPAWN_TIME_PANNEL = 2.0F;
    private float respawn_timer_pannel = 0.0f;

    public void respawnPannel()
    {
        GameObject go =
            GameObject.Instantiate(this.pannelPrefab) as GameObject;

        Vector3 pos = GameObject.Find("pannel_spawner").transform.position;

        go.transform.position = pos;

    }

    // Start is called before the first frame update
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
        
        respawn_timer_pannel += Time.deltaTime;
        
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
    }
}
