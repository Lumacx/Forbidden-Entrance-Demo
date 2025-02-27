using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using Thirdweb; // Ensure Thirdweb SDK is installed and this namespace is available.
using Thirdweb.Unity;
using System.Runtime.InteropServices;
using System.Diagnostics;

public class StartManager : MonoBehaviour
{
    public GameObject connected;
    public GameObject disconnected;
    public GameObject enterBtn;
    public TMPro.TextMeshProUGUI addressTxt;
    public TMPro.TextMeshProUGUI ownsNftTxt;

    // For URL parameter extraction in WebGL
    [DllImport("__Internal")]
    private static extern string GetParameter(string paramName);

    private string walletAddressFromURL;

    void Start()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        walletAddressFromURL = GetParameter("Wallet ID"); // Expecting URL like: index.html?wallet=0x1234...
        Debug.Log("Wallet Address from URL: " + walletAddressFromURL);
#else
        walletAddressFromURL = "0xDefaultTestAddress"; // Use a default for testing in the Editor
        UnityEngine.Debug.Log("Simulated Wallet Address: " + walletAddressFromURL);
#endif
    }

    void Update()
    {

    }

    public async void ConnectWallet()
    {
        // Example: Use the wallet address from URL to customize wallet options
        // Note: Adjust the WalletProvider and chain ID (84532 in this example) as needed.
        var walletOptions = new WalletOptions(WalletProvider.PrivateKeyWallet, 84532);
        var wallet = await ThirdwebManager.Instance.ConnectWallet(walletOptions);
        var address = await wallet.GetAddress();

        // Update UI with the retrieved address
        addressTxt.text = address;
        UnityEngine.Debug.Log("Connected wallet: " + address);
    }

    public async Task CheckBalance()
    {

    }


}
