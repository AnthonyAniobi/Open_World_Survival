using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] private string name;


    public string GetName()
    {
        return name;
    }
    
}
