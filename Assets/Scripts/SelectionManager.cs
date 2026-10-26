using TMPro;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{

    public static SelectionManager Instance {get; private set;}

    [SerializeField] private TextMeshProUGUI selectionText;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    
    void Update()
    {
        CheckSelectedObject();
    }

    private void CheckSelectedObject()
    {
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hitInfo))
        {
            InteractableObject interactableObject;
            if(hitInfo.collider.TryGetComponent<InteractableObject>(out interactableObject))
            {
                selectionText.text = interactableObject.GetName();
            }
            else
            {
                selectionText.text = "";
            }
        }
    }
}
