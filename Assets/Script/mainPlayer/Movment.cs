using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.UI;

public class Movment : MonoBehaviour
{
    [SerializeField] float MovmentSpeed;

    //yön Alma De?erleri
    float MovementX;
    float MovementY;

    //Ba?lanG?çDe?erleriVectörleri
    Vector3 LocalSize;

    //Componentler
    [SerializeField] Rigidbody2D Rb;
    [SerializeField] Animator animator;



    void Start()
    {
       Rb = GetComponent<Rigidbody2D>();
       animator = GetComponent<Animator>();

       LocalSize = transform.localScale;
    }
    
    void Update()
    {
        GetInput();
    }
    private void FixedUpdate()
    {
        Move();
        AnimationHandler();
    }



    public void GetInput()
    {
        MovementX = Input.GetAxis("Horizontal");
        MovementY = Input.GetAxis("Vertical");
    }

    public void AnimationHandler()
    {
     if(Mathf.Abs(MovementY)>0 || Mathf.Abs(MovementX)>0)
        {
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }
    }

    #region MoveThePlayer
    public void Move()
    {
        Rb.velocity = new Vector3(MovementX, MovementY, 0)*MovmentSpeed;

        if (MovementX > 0)
        {
            transform.localScale = new Vector3(LocalSize.x,LocalSize.y,LocalSize.z);
        }
        else if(MovementX < 0)
        {
            transform.localScale = new Vector3(LocalSize.x*-1, LocalSize.y, LocalSize.z);
        }

    }

    #endregion
}
