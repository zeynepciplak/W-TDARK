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
        // G tu�una bas�ld���nda ve animasyon hen�z oynat�lmad�ysa
        if (Input.GetKeyDown(KeyCode.G) && !animationPlayed)
        {
            // Animasyonu ba�lat
            animator.Play("SpinAnimation");

            // Animasyonun sadece bir kez oynat�lmas� gerekti�inden, animationPlayed de�erini true olarak ayarla
            animationPlayed = true;
        }
    }
}
*/