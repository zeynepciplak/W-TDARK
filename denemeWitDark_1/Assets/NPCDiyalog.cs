using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;    

public class NPCDiyalog : MonoBehaviour
{
    public GameObject diyalogPanel;
    public Text diyalogText;
    public string[] diyalog;
    private int index;

    public GameObject devamButonu;
    public float wordSpeed;
    public bool playerIsClose;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerIsClose) 
        {
            if(diyalogPanel.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                diyalogPanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }

        if (diyalogText.text == diyalog[index])
        {
            devamButonu.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Space)) // Space tuþu ile devam etme
            {
                NextLine();
            }

        }
    }




    public void zeroText()
    {
        diyalogText.text = "";
        index = 0;
        diyalogPanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach (char letter in diyalog[index].ToCharArray()) 
        {
            diyalogText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {
        devamButonu.SetActive(false) ;

        if(index < diyalog.Length -1)
        {
            index++;
            diyalogText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText() ;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            zeroText();
        }
    }








}
