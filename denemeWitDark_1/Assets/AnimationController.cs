/*
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;
    private bool animationPlayed;

    void Start()
    {
        animator = GetComponent<Animator>();
        animationPlayed = false;
    }

    void Update()
    {
        // G tuþuna basýldýðýnda ve animasyon henüz oynatýlmadýysa
        if (Input.GetKeyDown(KeyCode.G) && !animationPlayed)
        {
            // Animasyonu baþlat
            animator.Play("SpinAnimation");

            // Animasyonun sadece bir kez oynatýlmasý gerektiðinden, animationPlayed deðerini true olarak ayarla
            animationPlayed = true;
        }
    }
}
*/