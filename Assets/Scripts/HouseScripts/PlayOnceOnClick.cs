using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnceOnClick : MonoBehaviour
{
    private Animator animator;
    private bool hasPlayed = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        // Ensure the animation doesn't loop
        animator.GetComponent<Animator>().SetBool("isPlaying", false);
        animator.Play("clock2", -1, 0f);
    }

    void OnMouseDown()
    {
        if (!hasPlayed)
        {
            hasPlayed = true;
            animator.SetBool("isPlaying", true); // Start the animation
            animator.Play("clock2", -1, 0f);
            StartCoroutine(ResetAfterAnimation());
        }
    }

    private IEnumerator ResetAfterAnimation()
    {
        // Wait until the animation finishes (assuming 1 second per frame, adjust as needed)
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        animator.SetBool("isPlaying", false);
    }
}
