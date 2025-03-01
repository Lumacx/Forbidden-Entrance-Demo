using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using Thirdweb; // Ensure Thirdweb SDK is installed and this namespace is available.
using Thirdweb.Unity;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Numerics;

public class ClaimManager : MonoBehaviour
{
    // For URL parameter extraction in WebGL
    [DllImport("__Internal")]
    private static extern string GetParameter(string paramName);

    private string walletAddressFromURL;
    private string connectedWalletAddress; // Store the connected wallet address

    public async Task ClaimNFT()
    {
        var contract = await ThirdwebManager.Instance.GetContract(
            address: "0x20D478cB87BFEB23CbEf5aeC516341ab7B256904",
            chainId: 123420111,
            abi: "optional-abi" // Replace with your actual ABI if needed.
        );

        // Ensure we have the connected wallet address from the active wallet.
        var activeWallet = ThirdwebManager.Instance.ActiveWallet;
        if (activeWallet != null)
        {
            connectedWalletAddress = await activeWallet.GetAddress();
        }
        else
        {
            UnityEngine.Debug.LogError("No active wallet connected!");
            return;
        }

        // Call the "claimTo" function on the contract using the static Write method.
        await ThirdwebContract.Write(activeWallet, contract, "claimTo", BigInteger.Zero, connectedWalletAddress, "35", 1);
    }

    public async void Claim()
    {
        await ClaimNFT();
    }
}
