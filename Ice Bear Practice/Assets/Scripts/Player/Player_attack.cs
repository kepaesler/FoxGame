using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Player_attack : MonoBehaviour
{
    public Animator animator;

    BoxCollider2D m_Collider;

    public GameObject weapon;

    private float attackTime = .5f;

    [SerializeField]
    private PlayerMovement movement;

    [SerializeField]
    private PlayableDirector director;

    void Start()
    {
        //Fetch the GameObject's Collider (make sure it has a Collider component)
        m_Collider = weapon.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //player is supposed to be stopped
        if (movement.stop)
        {
            return;
        }
        //cutscene
        if (director.state == PlayState.Playing)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_Collider.enabled = true;
            Attack();
            StartCoroutine(waitForSec(attackTime));
        }
    }

    void Attack()
    {

        //if jumping do jump attack else reg attack
        if (animator.GetBool("isJumping"))
        {
            animator.SetBool("JumpAttack", true);
        }
        else
        {
            animator.SetTrigger("Attack");
        }

    }

    private IEnumerator waitForSec(float sec)
    {
        yield return new WaitForSeconds(sec);
        m_Collider.enabled = false;
    }
}
