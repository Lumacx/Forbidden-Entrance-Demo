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
    private string connectedWalletAddress; // Store the connected wallet address


    void Start()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        walletAddressFromURL = GetParameter("Wallet ID"); // Expecting URL like: index.html?wallet=0x1234...
        UnityEngine.Debug.Log("Wallet Address from URL: " + walletAddressFromURL);
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

        connected.SetActive(true);
        disconnected.SetActive(false);

        await CheckBalance();

    }

    public async Task CheckBalance()
    {
        var contract = await ThirdwebManager.Instance.GetContract(
            address: "0x20D478cB87BFEB23CbEf5aeC516341ab7B256904",
            chainId: 123420111,
            abi: "optional-abi"
        );

        // Assuming token id is 1. Using the connected wallet address.
        BigInteger balanceBigInt = await contract.ERC1155_BalanceOf(connectedWalletAddress, 1);

        // Convert BigInteger to string for parsing to a float
        string balance = balanceBigInt.ToString();
        float balanceFloat = float.Parse(balance);

        if (balanceFloat == 0)
        {
            ownsNftTxt.text = "First Time Player, Welcome!";
            enterBtn.SetActive(true);
        }
        else
        {
            ownsNftTxt.text = "Welcome Back Mammoth!";
            enterBtn.SetActive(true);
        }
    }

    public void EnterGame ()
    {
        SceneManager.LoadScene("1 Level - Snow 1.0");

    }

}
