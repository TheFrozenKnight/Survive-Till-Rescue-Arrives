using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
    public class Player : MonoBehaviour
    {
        public InventoryObject Inventory;
        private bool isBagOpen = false;
        public GameObject inventoryPanel;
        public GameObject PressEToast;
        public Button interactButton;

        private StarterAssetsInputs _input;
        private void Start()
        {
            _input = GetComponent<StarterAssetsInputs>();
        }

        private void Update()
        {
            if(_input.bag)
            {
                isBagOpen = !isBagOpen;
                inventoryPanel.SetActive(isBagOpen);
                _input.bag = false;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Pickups"))
            {
#if UNITY_STANDALONE || UNITY_EDITOR
                PressEToast.SetActive(true);
#endif
#if UNITY_ANDROID
                interactButton.interactable = true;
#endif
            }
        }
        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Pickups"))
            {
                if (_input.interact)
                {
                    var item = other.GetComponent<Item>();
                    Inventory.AddItem(item.item, 1);
                    Destroy(other.gameObject);

#if UNITY_STANDALONE||UNITY_EDITOR
                    PressEToast.SetActive(false);
#endif
#if UNITY_ANDROID
                    interactButton.interactable = false;
#endif
                }
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Pickups"))
            {
                PressEToast.SetActive(false);
                interactButton.interactable = false;
            }
        }

        private void OnApplicationQuit()
        {
            Inventory.Container.Clear();
        }
    }
}