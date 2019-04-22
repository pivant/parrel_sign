using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private string horizontalInputName;
    [SerializeField] private string verticalInputName;
    [SerializeField] public float movementSpeed;


    [SerializeField] private float slopeForce;
    [SerializeField] private float slopeForceRayLength;

    private CharacterController charController;

    [SerializeField] private AnimationCurve jumpFallOff;
    [SerializeField] private float jumpMultiplier;
    [SerializeField] private KeyCode jumpKey;

    private struct Key
    {
        public bool pick;
        public bool clock_up;
    }

    private Key key;

    private bool isJumping;

    public Time playerTime;

    /// <summary>
    /// other
    /// </summary>
    private GameObject closest_item = null;
    private GameObject carried_item = null;

    private GameObject closest_stage_object = null;
    private EventRoot event_root = null;
    private GameObject door_object = null;
    private GameObject real_door = null;

    private ItemRoot item_root = null;
    public GUIStyle guistyle;

    //public TimeRoot timeroot;

    public float jumpPower = 1;

    public bool slowChecker;

    public bool solve;

    public bool is_holding_item;

    private void Awake()
    {
        
        charController = GetComponent<CharacterController>();
    }

    void Start()
    {
        solve = false;
        slowChecker = false;
        is_holding_item = false;

        this.item_root = GameObject.Find("GameRoot").GetComponent<ItemRoot>();
        this.event_root = GameObject.Find("GameRoot").GetComponent<EventRoot>();
        this.door_object = GameObject.Find("keyholder").transform.Find("keyholder_model").gameObject; // findchild->find 유니티 버전업 이후 바뀜
        this.real_door = GameObject.Find("dooor").transform.Find("door").gameObject;
        //this.falling_pad = GameObject.FindWithTag("falling_pad");
    }

    private void Update()
    {
        this.Get_input();

        PlayerMovement();
        pick_or_drop_control();
        slowDown();
    }

    private void PlayerMovement()
    {
        float vertInput = Input.GetAxis(verticalInputName);
        float horizInput = Input.GetAxis(horizontalInputName);

        Vector3 fowardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horizInput;

        charController.SimpleMove(Vector3.ClampMagnitude(fowardMovement + rightMovement, 1.0f) * movementSpeed);

        if ((vertInput != 0 || horizInput != 0) && OnSlope())
            charController.Move(Vector3.down * charController.height / 2 * slopeForce * Time.deltaTime);

        JumpInput();

    }

    private bool OnSlope()
    {
        if (isJumping)
            return false;
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, charController.height / 2 * slopeForceRayLength))
            if (hit.normal != Vector3.up)
                return true;
        return false;
    }

    private void JumpInput()
    {
        if (Input.GetKeyDown(jumpKey) && !isJumping)
        {
            isJumping = true;
            StartCoroutine(JumpEvent());
        }
    }

    private IEnumerator JumpEvent()
    {

        charController.slopeLimit = 90.0f;


        float timeInAir = 0.0f;

        do
        {
            float jumpForce = jumpFallOff.Evaluate(timeInAir) * jumpPower;
            charController.Move(Vector3.up * jumpForce * jumpMultiplier * Time.deltaTime);
            timeInAir += Time.deltaTime*jumpPower;

            yield return null;
        } while (!charController.isGrounded && charController.collisionFlags != CollisionFlags.Above);

        charController.slopeLimit = 45.0f;
        isJumping = false;
    }

    void OnTriggerStay(Collider other)
    {
        GameObject other_go = other.gameObject;

        //트리거의 게임 오브젝트 레이어 설정이 Item이라면.
        if (other_go.layer == LayerMask.NameToLayer("item"))
        {
            Debug.Log("트리거의 게임 오브젝트 레이어 설정이 Item이라면.");
            //아무것도 주목하고 있지 않으면
            if (this.closest_item == null) // 정면에 있으면
            {
                Debug.Log("아이템 정면확인");
                this.closest_item = other_go; // 주목한다
                Debug.Log("아이템 주목");
            }
            //뭔가 주목하고 있으면
            else if (this.closest_item == other_go)
            {
                Debug.Log("아이템을 이미 주목하고 있으면");
                if (!this.is_other_in_viwe(other_go))// 정면에 없으면
                {
                    Debug.Log("아이템 정면확인");
                    this.closest_item = null;// 주목을 그만둔다.
                    Debug.Log("아이템 정면 그만둠");
                }
            }

        }
        else if (other_go.layer == LayerMask.NameToLayer("stage"))
        {
            Debug.Log("트리거 게임오브젝트의 스테이지 레이어 체크");
            if(this.closest_stage_object == null)
            {
                Debug.Log("주목중인 스테이지 레이어가 없다면");
                if (this.is_other_in_viwe(other_go))
                {
                    Debug.Log("정면인지 체크");
                    this.closest_stage_object = other_go;
                    Debug.Log("주목");
                }
            }

            else if(this.closest_stage_object == other_go)
            {
                Debug.Log("스테이지 이미 주목하고 있으면");
                if (!this.is_other_in_viwe(other_go))
                {
                    Debug.Log("스테이지 정면에 없으면");
                    this.closest_stage_object = null;
                    Debug.Log("스테이지 주목해재");
                }
            }
        }

    }

    private bool is_event_ignitable()
    {
        bool ret = false;
        do
        {
            if (this.closest_stage_object == null)
            {
                break;
            }

            Item.TYPE carried_item_type =
                this.item_root.getItemType(this.carried_item);

            if (!this.event_root.isEventIgnitable(carried_item_type, closest_stage_object))
            {
                break;
            }

            ret = true;

        } while (false);

        return(ret);
    }

    

    private bool is_other_in_viwe(GameObject other)
    {
        bool ret = false;

        do
        {
            Vector3 heading =
                this.transform.TransformDirection(Vector3.forward); //지금자기가 보는쪽
            Vector3 to_other =
               other.transform.position - this.transform.position;

            heading.y = 0.0f;
            to_other.y = 0.0f;

            heading.Normalize();//정규화
            to_other.Normalize();

            float dp = Vector3.Dot(heading, to_other);//내적

            if (dp < Mathf.Cos(45.0f))
            {
                break;
            }

            ret = true;
        } while (false);

        return (ret);
    }

    void OnTriggerExit(Collider other)
    {
        if(this.closest_item == other.gameObject)
        {
            this.closest_item = null;
        }

        if(this.closest_stage_object == other.gameObject)
        {
            this.closest_stage_object = null;
        }
    }

    private void pick_or_drop_control()
    {
        do
        {
            {
                if (!this.key.pick) // 줍기/버리기 키가 눌리지 않았으면.
                    break;          // 아무것도 하지 않고 종료
            }

            if (this.carried_item == null) // 들고 있는 아이템이 없고
            {
                if (this.closest_item == null)//주목중인 아이템이 없으면
                {
                    break;                  // 아무것도 하지않고 메서드 종료
                }

                // 주목중인 아이템을 들어 올린다.
                this.carried_item = this.closest_item;
                //들고 있는 아이템을 자신의 자식으로 설정.
                this.carried_item.transform.parent = this.transform;
                //2.0f위에 배치(머리위로 이동)
                this.carried_item.transform.localPosition = Vector3.forward * 1.0f;
                //주목중인 아이템을 없엔다
                this.closest_item = null;

                is_holding_item = true;

            }

            else // 들고 있는 아이템이 있을 경우
            {
                if (is_event_ignitable()== true)
                {
                    Debug.Log("플레이어 무브 이벤트 이그나이트");
                    carried_item.transform.position = new Vector3(-4.0f, -8.0f, 0.0f);
                    this.carried_item.transform.parent = null; // 자식 설정을 해재
                    this.carried_item = null;

                    solve = true;

                    break;
                }

                Debug.Log("플레이어 무브 이벤트 이그나이트 작동안함");
                this.carried_item.transform.localPosition =
                    Vector3.forward * 1.0f;
                    this.carried_item.transform.parent = null; // 자식 설정을 해재
                    this.carried_item = null;                  // 들고 있는 아이템을 없앤다.
                
            }


        } while (false);

    }

    private void Get_input()
    {
        this.key.pick = Input.GetKeyDown(KeyCode.F);
        this.key.clock_up = Input.GetKeyDown(KeyCode.E);
    }

    void OnGUI()
    {
        float x = 20.0f;
        float y = Screen.height - 40.0f;

        //들고 있는 아이템이 있다면.
        if (this.carried_item != null)
        {
            GUI.Label(new Rect(x, y, 200.0f, 20.0f), "F:버린다", guistyle);
        }
        else
        {
            //주목하는 아이템이 있다면
            if (this.closest_item != null)
            {
                GUI.Label(new Rect(x, y, 200.0f, 20.0f), "F:줍는다", guistyle);
            }

         
        }

    }

    void slowDown()
    {
        do
        {
            if (!this.key.clock_up)
                break;


            if (slowChecker == false)
                slowChecker = true;
            else
                slowChecker = false;

            

        } while (false);
    }

}
