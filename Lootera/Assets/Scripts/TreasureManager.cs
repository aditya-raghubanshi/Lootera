using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class TreasureManager : MonoBehaviour
{
    [SerializeField] public GameObject treasureChest = null;
    List<int> weapons = new List<int>() {36, 37, 38, 39, 40, 41, 42, 44, 47, 56};                // 36 dragonblade, 37 viking sword, 38 healing shot, 39 roll, 40 magic circle, 41 shield, 42 bow
    List<int> weaponsRare = new List<int>() {43, 44, 45, 46, 47, 48, 49, 36, 37, 52};                // rare
    List<int> weaponsLegendary = new List<int>() {50, 51, 52, 53, 54, 55, 56, 38, 48, 49};                // legendary
    List<GameObject> chestObjects = new List<GameObject>();                // The weapon objects spawned.
    private Vector3[] weaponPositions;
    //[SerializeField] public float spawnTime = 4f;            // How long between each spawn.
    //[SerializeField] public float SpawnRadius = 5000;
    int numberOfChests = 4;
    public PlayerInventory playerInventory;
    public GameObject vaultPanel;
    public PauseManager pauseManager;
    public Inventory chestMenu;

    //public static List<int> inventory = new List<int>();

    protected GameObject player;
    //public Transform interactionTransform;

    void Start()
    {
        vaultPanel.SetActive(false);

        LoadSerializedBodyInv();
        LoadSerializedBackpackInv();
        populateChestObjects();

        player = GameObject.Find("Player");
        //interactionTransform = this.transform;

        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        weaponPositions = new Vector3[weapons.Count];
        //weaponObjects = new GameObject[weapons.Length];
        //for (int i = 0; i < numberOfChests; i++)
        //{
            Spawn();
        //}
    }

    void Update()
    {
    }

    private void populateChestObjects()
    {
        chestObjects.Add(GameObject.Find("treasure_chest_1"));
        chestObjects.Add(GameObject.Find("treasure_chest_2"));
        chestObjects.Add(GameObject.Find("treasure_chest_3"));
        chestObjects.Add(GameObject.Find("treasure_chest_4"));
    }

    public void interactionPressed()
    {
        Debug.Log("INTERACTION PRESSED!");
        for (int i = 0; i < chestObjects.Count; i++)
        {

            Debug.Log("LOOPING....");
            

            float distance = Vector3.Distance(player.transform.transform.position, chestObjects[i].transform.position);
            Debug.Log(distance);
            if (distance <= 3f)
            {
                
                Interact();

                Destroy(chestObjects[i]);
                chestObjects.RemoveAt(i);
                break;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 3f);
    }

    public void openInventories()
    {
        Debug.Log("heyyyyy");
        playerInventory.openMainInventory();
        playerInventory.openCharacterInventory();
        vaultPanel.SetActive(true);
        pauseManager.Pause();
        Debug.Log("opeingingigi");
    }

    public void closeInventories()
    {
        vaultPanel.SetActive(false);
        playerInventory.characterSystemInventory.closeInventory();
        playerInventory.mainInventory.closeInventory();
        if(chestMenu)
        {
            chestMenu.closeInventory();
        }
        pauseManager.Resume();
    }

    private void addItemToChestInventory(List<int> items)
    {
        System.Random rnd = new System.Random();

        chestMenu.addItemToInventory(items[rnd.Next(0, 10)]);
        chestMenu.addItemToInventory(items[rnd.Next(0, 10)]);
        chestMenu.addItemToInventory(items[rnd.Next(0, 10)]);
    }

    private void openChest()
    {
        chestMenu.deleteAllItems();

        if (Level.level >=1 && Level.level <= 3)
        {
            addItemToChestInventory(weapons);
        }
        else if(Level.level >= 4 && Level.level <= 7)
        {
            addItemToChestInventory(weaponsRare);
        }
        else
        {
            addItemToChestInventory(weaponsLegendary);
        }
        chestMenu.openInventory();
    }

    public void Interact()
    {
        Debug.Log("Interacting with Treausre");
        //inventory.Add(new WeaponSaveData(weapons[weaponIndex].ToString()));
        //inventory.Add(weapons[weaponIndex]);
        //playerInventory.addItemToMainInventory(weapons[weaponIndex], 1);
        openInventories();
        openChest();
        

        System.Random rnd = new System.Random();
        Gems.gems = Level.level + rnd.Next(1, 11);

        Debug.Log("opened!!!!");

        //SaveSerializedWeapons();
    }

    void Spawn()
    {
        // Find a random index between zero and one less than the number of spawn points.
        //int weaponIndex = Random.Range(0, weapons.Length);
        Quaternion rot = GameObject.Find("Player").transform.rotation;
        rot.y = System.Math.Abs(360 - rot.y);

        // Create an instance of the weapon prefab at the randomly selected spawn point's position and rotation.
        //Debug.Log("index:" + weaponIndex);
    
        weaponPositions[0] = new Vector3((float)86.8, (float)58.9, (float)116.5); //RandomNavmeshLocation(SpawnRadius);
        //weaponObjects[weaponIndex] = Instantiate(weapons[weaponIndex], weaponPositions[weaponIndex], rot);
        //weaponObjects.Add(Instantiate((GameObject)Resources.Load("treasure_chest_closed", typeof(GameObject)), weaponPositions[0], rot));
        //weaponIndex++;
        weaponPositions[1] = new Vector3((float)-0.7, (float)58.9, (float)133.6); //RandomNavmeshLocation(SpawnRadius);
        //weaponObjects[weaponIndex] = Instantiate(weapons[weaponIndex], weaponPositions[weaponIndex], rot);
        //weaponObjects.Add(Instantiate(treasureChest, weaponPositions[1], rot));

        weaponPositions[2] = new Vector3((float)32.6, (float)58.9, (float)151); //RandomNavmeshLocation(SpawnRadius);
        //weaponObjects[weaponIndex] = Instantiate(weapons[weaponIndex], weaponPositions[weaponIndex], rot);
        //weaponObjects.Add(Instantiate(treasureChest, weaponPositions[2], rot));

        weaponPositions[3] = new Vector3((float)-0.7, (float)58.9, (float)222.6); //RandomNavmeshLocation(SpawnRadius);
        //weaponObjects[weaponIndex] = Instantiate(weapons[weaponIndex], weaponPositions[weaponIndex], rot);
       // weaponObjects.Add(Instantiate(treasureChest, weaponPositions[3], rot));
    }

    /*public Vector3 RandomNavmeshLocation(float radius)
    {
        while (true)
        {
            Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * radius * (weaponIndex + 2);
            //randomDirection += transform.position;
            NavMeshHit hit;
            Vector3 finalPosition = Vector3.zero;
            if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
            {
                finalPosition = hit.position;
                finalPosition.y = 1;
                return finalPosition;
            }
        }
    }*/

    /*public void SaveSerializedBackpackInv()
    {
        string serializedWeaponFileName = Application.persistentDataPath + "/backpackInv.dat";
        BinaryFormatter bf = new BinaryFormatter();
        if (File.Exists(serializedWeaponFileName))
        {
            File.Delete(serializedWeaponFileName);
        }
        FileStream file = File.Create(serializedWeaponFileName);
        bf.Serialize(file, inventory);
        file.Close();
    }*/

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
                List<int> inventory = (List<int>)bf.Deserialize(fileStream);
                playerInventory.mainInventory.deleteAllItems();
                for (int i = 0; i < inventory.Count; i++)
                {
                    playerInventory.mainInventory.addItemToInventory(inventory[i]);
                }
            }

            fileStream.Close();
        }
        else
        {
            Debug.Log("Loading Data failed. File " + serializedWeaponFileName + "doesn't exist");
        }
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
                playerInventory.characterSystemInventory.deleteAllItems();
                List<int> inv = (List<int>)bf.Deserialize(fileStream);
                for (int i=0; i<inv.Count; i++) {
                    playerInventory.characterSystemInventory.addItemToInventory(inv[i]);
                }
            }

            fileStream.Close();
        }
        else
        {
            Debug.Log("Loading Data failed. File " + serializedWeaponFileName + "doesn't exist");
        }
    }

    [Serializable]
    public struct WeaponSaveData
    {
        public string name;

        public WeaponSaveData(string name)
        {
            this.name = name.ToString();
        }
    };
}
