using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timebody : MonoBehaviour
{
    public bool isRewinding = false;

    List<Vector3> positions;

    // Start is called before the first frame update
    void Start()
    {
        positions = new List<Vector3>(); // 포지션을 리스트로 저장
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            StartRewind();
        if (Input.GetKeyUp(KeyCode.Return))
            StopRewind();
    }

    void FixedUpdate()
    {
        if (isRewinding)
            Rewind();
        else
            Record(); // 대상의 포지션을 기록
    }

    void Rewind()
    {
        if (positions.Count > 0)
        {
            transform.position = positions[0];
            positions.RemoveAt(0);
        }
        else
            StopRewind();

    }

    public void StartRewind()
    {
        isRewinding = true;
    }

    public void StopRewind()
    {
        isRewinding = false;
    }

    void Record()
    {
        positions.Insert(0, transform.position); // 리스트에 대상의 포지션을 실시간으로 기록
    }

}
