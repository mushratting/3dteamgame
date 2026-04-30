using UnityEngine;

// Example of an interactable object that implements the IInteractable interface.
// In this case, the object might be a diary, note, or item with descriptive text.

public class interactableobject : MonoBehaviour
{
    public GameObject[] toActivate;
    public GameObject[] toDeactivate;

    void Start()
    {

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
           foreach (GameObject obj in toActivate)
            {

                obj.SetActive(true);

        }
            foreach (GameObject obj in toDeactivate)
            {

                obj.SetActive(false);

        }

    }    
}
}
