using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] private new string name;


    public string GetName()
    {
        return name;
    }
    
}
