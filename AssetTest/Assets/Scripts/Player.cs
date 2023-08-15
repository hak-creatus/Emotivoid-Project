using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 15.0f;
    float hAxis;
    float vAxis;
    float xPlace;
    float zPlace;

    Vector3 moveVec;
    public Vector3 lookVec;
    Camera charCam;

    Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        charCam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        GetWalk();
        CharacterRotate();
    }

    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
    }

    void GetWalk()
    {
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;
        transform.position += moveVec * speed * Time.deltaTime;
        // 애니메이션 전환
        anim.SetBool("isWalk", moveVec != Vector3.zero);
    }

    void CharacterRotate()
    {
        /*
        Ray ray = charCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitResult;
        if(Physics.Raycast(ray, out hitResult))
        {
            lookVec = new Vector3(hitResult.point.x, transform.position.y, hitResult.point.z) - transform.position;
            transform.LookAt(lookVec);
        }
        */
        transform.LookAt(transform.position + moveVec);
    }
}
