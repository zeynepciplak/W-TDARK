using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;
public class npc2Etkileşim : MonoBehaviour
{


    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;


    private void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();

    }

    void Update()
    {
        
    }


    void StartDialogue()
      
    {
        index = 0;
        StartCoroutine(Typline());
    }

    IEnumerator Typline()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

}