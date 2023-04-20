using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class NPCInteraction : MonoBehaviour
{
    [SerializeField] private bool isInRange;
    [SerializeField] private bool isInteracting;

    [HideInInspector] public DialogueController dialogueController;
    [HideInInspector] public DialogueSystem dialogueSystem;

    public bool IsInRange { get => isInRange; set => isInRange = value; }

    public void Update()
    {
        if (isInRange)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                isInteracting = true;
            }
        }
        else if (!isInRange && isInteracting)
        {
            isInteracting = false;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
        }
    }
}
