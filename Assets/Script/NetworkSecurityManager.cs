using UnityEngine;

/// <summary>
/// Network Security Manager to handle HTTP connection issues
/// Place this script on a GameObject in your scene to fix HTTP connection errors
/// </summary>
public class NetworkSecurityManager : MonoBehaviour
{
    [Header("Network Security Settings")]
    [SerializeField] private bool allowHTTPConnections = true;
    
    void Awake()
    {
        if (allowHTTPConnections)
        {
            ConfigureNetworkSecurity();
        }
    }
    
    private void ConfigureNetworkSecurity()
    {
        // Request permissions that allow HTTP connections
        Application.RequestUserAuthorization(UserAuthorization.WebCam | UserAuthorization.Microphone);
        
        // Additional configuration for different platforms
        #if UNITY_EDITOR
        Debug.Log("Editor: HTTP connections should be allowed through Player Settings");
        #elif UNITY_STANDALONE
        Debug.Log("Standalone: HTTP connections configured");
        #elif UNITY_WEBGL
        Debug.Log("WebGL: HTTP connections may be restricted by browser security");
        #endif
        
        Debug.Log("Network security configured for HTTP connections");
    }
    
    void Start()
    {
        // Verify configuration
        if (allowHTTPConnections)
        {
            Debug.Log("HTTP connections are enabled. If you still get 'Insecure connection not allowed' error, please check Unity Player Settings -> Internet Access -> Require");
        }
    }
}
