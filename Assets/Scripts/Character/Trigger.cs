using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == Tags.ACTIVE_ZONE && transform.tag == Tags.LOOSE_LETTER)
        {
            //to activate input
            CharacterAttachment.ActivateLetter(transform.GetComponent<TextMeshPro>().text[0], transform);
            //todo: assign character only one time, not in trigger ? do I need asignment?
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == Tags.ACTIVE_ZONE && transform.tag == Tags.LOOSE_LETTER)
        {
            //to deactivate input
            CharacterAttachment.DeactivateLetter(transform.GetComponent<TextMeshPro>().text[0], transform);
        }
    }
}
