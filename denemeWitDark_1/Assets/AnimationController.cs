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
        // G tuşuna basıldığında ve animasyon henüz oynatılmadıysa
        if (Input.GetKeyDown(KeyCode.G) && !animationPlayed)
        {
            // Animasyonu başlat
            animator.Play("SpinAnimation");

            // Animasyonun sadece bir kez oynatılması gerektiğinden, animationPlayed değerini true olarak ayarla
            animationPlayed = true;
        }
    }
}
*/