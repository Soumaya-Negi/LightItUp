using UnityEngine;

public class BiomeManager : MonoBehaviour
{
    [System.Serializable]
    public class BiomeData
    {
        public string biomeName;
        public GameObject biomeRoot;  // parent GameObject that contains the tilemaps for this biome
        public int unlockLevel;       // podLevel at/after which this biome is used
    }

    public BiomeData[] biomes;
    private int currentBiomeIndex = 0;

    void Start()
    {
        // Enable only the first biome at start
        ActivateBiome(0);
    }

    // Call this from UpgradeManager after podLevel changes
    public void UpdateBiomeByLevel(int podLevel)
    {
        int nextIndex = currentBiomeIndex;

        // Pick the highest biome whose unlockLevel <= podLevel
        for (int i = 0; i < biomes.Length; i++)
        {
            if (podLevel >= biomes[i].unlockLevel)
                nextIndex = i;
        }

        if (nextIndex != currentBiomeIndex)
            ActivateBiome(nextIndex);
    }

    private void ActivateBiome(int index)
    {
        // Disable all, enable chosen
        for (int i = 0; i < biomes.Length; i++)
        {
            if (biomes[i].biomeRoot != null)
                biomes[i].biomeRoot.SetActive(i == index);
        }

        currentBiomeIndex = index;
        Debug.Log($"Biome changed to: {biomes[index].biomeName} (index {index})");
    }
}
