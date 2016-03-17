using UnityEngine;
using System.Collections;

public class OrcController : MonoBehaviour
{
    public string enemyTag = "Skeleton";
    Animator animator;
    AnimatorStateInfo animatorState;
    bool attack;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        attack = false;
    }

    // Update is called once per frame
    void Update()
    {
        animatorState = animator.GetCurrentAnimatorStateInfo(0);
        if (attack && animatorState.IsName("idle"))
        {
            animator.SetTrigger("attack");
            attack = false;
        }
    }



    public void OnCollisionStay2D(Collision2D collision)
    {
        if (attack || !collision.gameObject.CompareTag(enemyTag))
            return;
        attack = true;
        // TODO any other stuff you need here
    }
}
