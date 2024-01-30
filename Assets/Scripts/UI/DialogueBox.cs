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
            textComp.text += c; //the text componenet has the text that is being broken down into the individual letters
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++; //goes to the bext index amount aka the next line in the array
            textComp.text = string.Empty; //makes the text empty so its not the previous line
            StartCoroutine (TypeLines()); //types the lines thats a part of the current line in the arrray
        }
        else gameObject.SetActive(false);
    }
}
