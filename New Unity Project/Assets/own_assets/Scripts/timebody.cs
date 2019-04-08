using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timebody : MonoBehaviour
{
    bool isRewinding = false;

    public float recordTime = 5f; // 기록하는 시간 = 5초

    List<pointintime> pointsInTime; // 로테이션도 저장하기위해 리스트 따로 생성

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        pointsInTime = new List<pointintime>(); // 포지션을 리스트로 저장
        rb = GetComponent<Rigidbody>();
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
        if (pointsInTime.Count > 0)
        {
            pointintime pointInTime_ = pointsInTime[0];
            transform.position = pointInTime_.position;
            transform.rotation = pointInTime_.rotation;
            pointsInTime.RemoveAt(0);
        }
        else
            StopRewind();

    }

    public void StartRewind()
    {
        isRewinding = true;
        rb.isKinematic = true;
    }

    public void StopRewind()
    {
        isRewinding = false;
        rb.isKinematic = false;
    }

    void Record()
    {
        if(pointsInTime.Count > Mathf.Round(recordTime / Time.fixedDeltaTime)) // 돌릴수 있는 타이머 제한
        {
            pointsInTime.RemoveAt(pointsInTime.Count - 1); // 오래된 리스트 삭제
        }

        pointsInTime.Insert(0, new pointintime(transform.position,transform.rotation)); // 리스트에 대상의 포지션을 실시간으로 기록
    }

}
