using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryButtons : MonoBehaviour
{
    [SerializeField] private GameObject inventory;
    [SerializeField] private GameObject information;
    public void OpenInventory(){
        inventory.SetActive(true);
    }

    public void CloseInventory(){
        inventory.SetActive(false);
    }

}
