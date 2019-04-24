using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Vault : MonoBehaviour
{
    public GameObject vaultMenu;
    public GameObject backpackMenu;
    public GameObject bodyMenu;
    public GameObject vaultPanel;

    // Start is called before the first frame update
    void Start()
    {
        vaultPanel.gameObject.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void openInventories()
    {

        LoadSerializedBodyInv();
        LoadSerializedVaultInv();
        LoadSerializedBackpackInv();

        Debug.Log("opening inv");
        vaultPanel.gameObject.SetActive(true);

        //if (!vaultMenu) { vaultMenu = GameObject.Find("VaultMenu").GetComponent <Inventory> (); }
        Debug.Log(vaultMenu);
        vaultMenu.GetComponent<Inventory>().openInventory();

        //if (!backpackMenu) { backpackMenu = GameObject.Find("BackpackMenu").GetComponent<Inventory>(); }
        Debug.Log(backpackMenu);
        backpackMenu.GetComponent<Inventory>().openInventory();

        //if (!bodyMenu) { bodyMenu = GameObject.Find("BodyMenu").GetComponent<Inventory>(); }
        Debug.Log(bodyMenu);
        bodyMenu.GetComponent<Inventory>().openInventory();
        
    }

    public void closeInventories()
    {
        SaveSerializedBackpackInv();
        SaveSerializedBodyInv();
        SaveSerializedVaultInv();

        if (bodyMenu.GetComponent<Inventory>().closeInventory()) {
            vaultPanel.gameObject.SetActive(false);
            Debug.Log("closing all...");

            Debug.Log("step 2...");
            vaultMenu.GetComponent<Inventory>().closeInventory();
            backpackMenu.GetComponent<Inventory>().closeInventory();
            Debug.Log("step 3...");
        }
    }

    private void LoadSerializedBackpackInv()
    {
        string serializedWeaponFileName = Application.persistentDataPath + "/backpackInv.dat";
        if (File.Exists(serializedWeaponFileName))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fileStream = File.Open(serializedWeaponFileName, FileMode.Open);
            if (fileStream.Length != 0)
            {
                //inventory = (List<WeaponSaveData>)bf.Deserialize(fileStream);
                List<int> inv = (List<int>)bf.Deserialize(fileStream);
                backpackMenu.GetComponent<Inventory>().deleteAllItems();
                for (int i = 0; i < inv.Count; i++)
                {
                    backpackMenu.GetComponent<Inventory>().addItemToInventory(inv[i]);
                }
            }

            fileStream.Close();
        }
        else
        {
            Debug.Log("Loading Data failed. File " + serializedWeaponFileName + "doesn't exist");
        }
    }

    private void addBasicInventory()
    {
        Debug.Log("adding basic");
        bodyMenu.GetComponent<Inventory>().addItemToInventory(37, 1);
        bodyMenu.GetComponent<Inventory>().addItemToInventory(38, 1);
        bodyMenu.GetComponent<Inventory>().addItemToInventory(39, 1);
        bodyMenu.GetComponent<Inventory>().addItemToInventory(40, 1);
    }

    private void LoadSerializedBodyInv()
    {
        string serializedWeaponFileName = Application.persistentDataPath + "/bodyInv.dat";
        if (File.Exists(serializedWeaponFileName))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fileStream = File.Open(serializedWeaponFileName, FileMode.Open);
            if (fileStream.Length != 0)
            {
                //inventory = (List<WeaponSaveData>)bf.Deserialize(fileStream);
                bodyMenu.GetComponent<Inventory>().deleteAllItems();
                List<int> inv = (List<int>)bf.Deserialize(fileStream);
                Debug.Log(inv.Count);
                if(inv.Count == 0)
                {
                    addBasicInventory();
                }
                for (int i = 0; i < inv.Count; i++)
                {
                    Debug.Log("FileItem:" + inv[i]);
                    bodyMenu.GetComponent<Inventory>().addItemToInventory(inv[i], 1);
                }
            }

            fileStream.Close();
        }
        else
        {
            //addBasicInventory();
            Debug.Log("Loading Data failed. File " + serializedWeaponFileName + "doesn't exist");
        }
    }


    private void LoadSerializedVaultInv()
    {
        string serializedWeaponFileName = Application.persistentDataPath + "/vaultInv.dat";
        if (File.Exists(serializedWeaponFileName))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fileStream = File.Open(serializedWeaponFileName, FileMode.Open);
            if (fileStream.Length != 0)
            {
                //inventory = (List<WeaponSaveData>)bf.Deserialize(fileStream);
                vaultMenu.GetComponent<Inventory>().deleteAllItems();
                List<int> inv = (List<int>)bf.Deserialize(fileStream);
                for (int i = 0; i < inv.Count; i++)
                {
                    vaultMenu.GetComponent<Inventory>().addItemToInventory(inv[i]);
                }
            }

            fileStream.Close();
        }
        else
        {
            Debug.Log("Loading Data failed. File " + serializedWeaponFileName + "doesn't exist");
        }
    }

    public List<int> getIDs(Inventory inventory)
    {
        List<int> IDs = new List<int>();
        for(int i=0; i<inventory.getItemList().Count; i++)
        {
            IDs.Add(inventory.getItemList()[i].itemID);
        }
        return IDs;
    }

    public void SaveSerializedBackpackInv()
    {
        string serializedWeaponFileName = Application.persistentDataPath + "/backpackInv.dat";
        BinaryFormatter bf = new BinaryFormatter();
        if (File.Exists(serializedWeaponFileName))
        {
            File.Delete(serializedWeaponFileName);
        }
        FileStream file = File.Create(serializedWeaponFileName);
        bf.Serialize(file, getIDs(backpackMenu.GetComponent<Inventory>()));
        file.Close();
    }

    public void SaveSerializedBodyInv()
    {
        string serializedWeaponFileName = Application.persistentDataPath + "/bodyInv.dat";
        BinaryFormatter bf = new BinaryFormatter();
        if (File.Exists(serializedWeaponFileName))
        {
            File.Delete(serializedWeaponFileName);
        }
        FileStream file = File.Create(serializedWeaponFileName);
        Debug.Log(getIDs(bodyMenu.GetComponent<Inventory>()).Count);
        bf.Serialize(file, getIDs(bodyMenu.GetComponent<Inventory>()));
        file.Close();
    }

    public void SaveSerializedVaultInv()
    {
        string serializedWeaponFileName = Application.persistentDataPath + "/vaultInv.dat";
        BinaryFormatter bf = new BinaryFormatter();
        if (File.Exists(serializedWeaponFileName))
        {
            File.Delete(serializedWeaponFileName);
        }
        FileStream file = File.Create(serializedWeaponFileName);
        bf.Serialize(file, getIDs(vaultMenu.GetComponent<Inventory>()));
        file.Close();
    }
}
