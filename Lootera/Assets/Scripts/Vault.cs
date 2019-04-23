using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Vault : MonoBehaviour
{
    public Inventory vaultMenu;
    public Inventory backpackMenu;
    public Inventory bodyMenu;
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
        Debug.Log("opening inv");
        vaultPanel.gameObject.SetActive(true);

        LoadSerializedBackpackInv();
        LoadSerializedBodyInv();
        LoadSerializedVaultInv();

        vaultMenu.openInventory();
        backpackMenu.openInventory();
        bodyMenu.openInventory();
    }

    public void closeInventories()
    {
        if (bodyMenu.closeInventory()) {
            vaultPanel.gameObject.SetActive(false);
            Debug.Log("closing all...");
            SaveSerializedBackpackInv();
            SaveSerializedBodyInv();
            SaveSerializedVaultInv();

            Debug.Log("step 2...");
            vaultMenu.closeInventory();
            backpackMenu.closeInventory();

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
                backpackMenu.deleteAllItems();
                for (int i = 0; i < inv.Count; i++)
                {
                    backpackMenu.addItemToInventory(inv[i]);
                }
            }

            fileStream.Close();
        }
        else
        {
            Debug.Log("Loading Data failed. File " + serializedWeaponFileName + "doesn't exist");
        }
    }

    /*private void addBasicInventory()
    {
        Debug.Log("adding basic");
        bodyMenu.addItemToInventory(36);
        bodyMenu.addItemToInventory(38);
        bodyMenu.addItemToInventory(39);
        bodyMenu.addItemToInventory(40);
    }*/

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
                bodyMenu.deleteAllItems();
                List<int> inv = (List<int>)bf.Deserialize(fileStream);
                Debug.Log(inv.Count);
                /*if(inv.Count == 0)
                {
                    addBasicInventory();
                }*/
                for (int i = 0; i < inv.Count; i++)
                {
                    bodyMenu.addItemToInventory(inv[i]);
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
                vaultMenu.deleteAllItems();
                List<int> inv = (List<int>)bf.Deserialize(fileStream);
                for (int i = 0; i < inv.Count; i++)
                {
                    vaultMenu.addItemToInventory(inv[i]);
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
        bf.Serialize(file, getIDs(backpackMenu));
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
        Debug.Log(getIDs(bodyMenu).Count);
        bf.Serialize(file, getIDs(bodyMenu));
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
        bf.Serialize(file, getIDs(vaultMenu));
        file.Close();
    }
}
