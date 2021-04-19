using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private Animator animator;

    void Update()
    {
        animator = this.GetComponent<Animator>();
        if (EncounterManager.isBattle == false && TownPortal.inPortal == false && GameStatusGUI.isOpen == false)
        {
            if (Input.GetKey("right"))
            {
                animator.SetInteger("direction", 3);
                transform.Translate((Vector2.right) * moveSpeed * Time.deltaTime);
            }
            if (Input.GetKey("left"))
            {
                animator.SetInteger("direction", 1);
                transform.Translate((-Vector2.right) * moveSpeed * Time.deltaTime);
            }
            if (Input.GetKey("up"))
            {
                animator.SetInteger("direction", 2);
                transform.Translate((Vector2.up) * moveSpeed * Time.deltaTime);
            }
            if (Input.GetKey("down"))
            {
                animator.SetInteger("direction", 0);
                transform.Translate((-Vector2.up) * moveSpeed * Time.deltaTime);
            }
            //if (!Input.GetKey("right") && !Input.GetKey("left") && !Input.GetKey("up") && !Input.GetKey("down"))
            //{
            //    animator.SetInteger("direction", 4);
            //}
        }
    }
}
