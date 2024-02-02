using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueBox : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textComp;
    [SerializeField] private string[] lines;
    [SerializeField] private float textSpeed;

    private int index;
    // Start is called before the first frame update
    void Start()
    {
        textComp.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComp.text == lines[index]) //if the dialogue is complete go to the next line
            {
                NextLine();
            }
            else //instantly fills up the text box for quicker reading
            {
                StopAllCoroutines();
                textComp.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLines());
    }  
    
    IEnumerator TypeLines() //types out each letter one by one 
    {
        foreach (char c in lines[index].ToCharArray())//breaks the string down into a character array
        {
            textComp.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComp.text = string.Empty;
            StartCoroutine (TypeLines());
        }
        else gameObject.SetActive(false);
    }
}
