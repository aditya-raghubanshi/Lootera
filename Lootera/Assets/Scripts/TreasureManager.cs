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
    List<int> weapons = new List<int>() {42, 42, 42, 42};                // 36 dragonblade, 37 viking sword, 38 healing shot, 42 bow
    List<GameObject> weaponObjects = new List<GameObject>();                // The weapon objects spawned.
    private Vector3[] weaponPositions;
    [SerializeField] public float spawnTime = 4f;            // How long between each spawn.
    [SerializeField] public float SpawnRadius = 5000;
    [SerializeField] public int spawnNumber = 4;
    static int weaponIndex = 0;
    public PlayerInventory playerInventory;
    public GameObject vaultPanel;
    public PauseManager pauseManager;

    public static List<int> inventory = new List<int>();

    protected InteractionButton interaction;
    protected GameObject player;
    //public Transform interactionTransform;

    void Start()
    {
        vaultPanel.SetActive(false);

        LoadSerializedBodyInv();
        LoadSerializedBackpackInv();

        interaction = FindObjectOfType<InteractionButton>();
        player = GameObject.Find("Player");
        //interactionTransform = this.transform;

        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        weaponPositions = new Vector3[weapons.Count];
        //weaponObjects = new GameObject[weapons.Length];
        for (int i = 0; i < spawnNumber; i++)
        {
            Spawn();
        }
    }

    void Update()
    {
        if (interaction && interaction.Pressed)
        {

            Debug.Log("INTERACTION PRESSED!");
            for (int i = 0; i < weaponPositions.Length; i++)
            {

                Debug.Log("LOOPING....");
                float distance = Vector3.Distance(player.transform.transform.position, weaponPositions[i]);
                if (distance <= 3f)
                {
                    Interact(i);
                    break;
                }
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
        pauseManager.Resume();
    }

    public void Interact(int weaponIndex)
    {
        Debug.Log("Interacting with Treausre");
        //inventory.Add(new WeaponSaveData(weapons[weaponIndex].ToString()));
        inventory.Add(weapons[weaponIndex]);
        playerInventory.addItemToMainInventory(weapons[weaponIndex], 1);
        openInventories();

        System.Random rnd = new System.Random();
        Gems.gems = Level.level + rnd.Next(1, 11);

        Destroy(weaponObjects[weaponIndex]);
        weaponObjects.RemoveAt(weaponIndex);
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
        Debug.Log("index:" + weaponIndex);
        weaponPositions[weaponIndex] = RandomNavmeshLocation(SpawnRadius);
        //weaponObjects[weaponIndex] = Instantiate(weapons[weaponIndex], weaponPositions[weaponIndex], rot);
        weaponObjects.Add(Instantiate(treasureChest, weaponPositions[weaponIndex], rot));
        weaponIndex++;
    }

    public Vector3 RandomNavmeshLocation(float radius)
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
        bf.Serialize(file, inventory);
        file.Close();
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
                inventory = (List<int>)bf.Deserialize(fileStream);
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
