using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AddressableManager : MonoBehaviour
{
    [SerializeField]
    AssetReference TreeGO;

    // Start is called before the first frame update
    void Start()
    {
        Addressables.InitializeAsync().Completed += AddressableManager_Completed;
    }

    private void AddressableManager_Completed(AsyncOperationHandle<IResourceLocator> obj)
    {
        Debug.Log("Addressable has been initialised");

        TreeGO.InstantiateAsync().Completed += (go) =>
        {
            Debug.Log("Tree Asset has been instantiated");

            var treeGO = go.Result;
            treeGO.transform.position = Vector3.zero;
            Debug.Log("Tree Asset has been placed");
        };
    }
}
