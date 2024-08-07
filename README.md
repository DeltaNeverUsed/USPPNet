# USPPNet
 UdonSharp RPC with arguments!

# How to use
1. Download and install the project from my [VCC Listing](https://deltaneverused.github.io/VRChatPackages/)
2. Include USPPNet and System in your script.
3. Add "// USPPNet Init" at the bottom of your UdonSharpBehaviour.
4. Add "// USPPNet OnDeserialization" inside your OnDeserialization function.
5. Add "// USPPNet OnPostSerialization" inside your OnPostSerialization function.

## Usage
### Boilerplate 
You must have all of this somewhere in your UdonSharpBehaviour class.
It's recommened to have the functions and comments in this order to prevent pain when debugging your code.
```csharp
// you must inheret your class from USPPNetUdonSharpBehaviour
public class USPPNetTest : USPPNetUdonSharpBehaviour { 
    // Comments that start with USPPNet are important, you need them for USPPNet to work
   public override void OnDeserialization() {
       // USPPNet OnDeserialization
       // Your code here
   }
   
   public override void OnPreSerialization() {
       // USPPNet OnPreSerialization
       // your code here
   }
       
   public override void OnPostSerialization(VRC.Udon.Common.SerializationResult result) {
       // USPPNet OnPostSerialization
       // Your code here
   }
   
   // USPPNet Init
}


```
### Creating functions
```csharp
// To define a networked function
// You simply put USPPNET_ before the name of any function to make it a USPPNet function
public void USPPNET_Ping() {
    // Do something
}
```
### Calling functions
```csharp
// Only the network owner of the object will be able to call USPPNet functions

USPPNET_Ping(); // The PreProcessor will parse this and turn it into a USPPNet remote function call
// So "USPPNET_Ping();" will become USPPNet_RPC("Ping");
// But that isn't really something you have to think about since it all happens in the background

// If you want to call the function on another component you'd need to do this instead.
var component = GetComponent<your component>();
component.USPPNet_RPC(nameof(component.USPPNET_Ping));

// If you're using manual sync mode (which i recommend) you'll need to call RequestSerialization before the function call will sync
```
### Calling functions with parameters!
```csharp
// Create your function like normal
public void USPPNET_Ping(string message, float time) {
    // Do something
}

private void Start() {
    // And call it like normal
    USPPNET_Ping("Hello there!", 420);
    
    // If you want to call the function on another component you'd need to do this instead.
   var component = GetComponent<your component>();
   component.USPPNet_RPC(nameof(component.USPPNET_Ping), "Hello there!", 420);
}
```

## Temp Example
```csharp
using USPPNet; // You must include USPPNet or it'll fail to compile

using UdonSharp;
using VRC.SDKBase;
using VRC.Udon.Common;


namespace USPPNet.Examples {
    [UdonBehaviourSyncMode(BehaviourSyncMode.Manual)]
    public class Cube : USPPNetUdonSharpBehaviour {
        private void USPPNET_Test(string msg, int test, VRCPlayerApi caller, int[] testArray) // Demo method
        {
            Debug.Log($"Triggered! {msg}, num: {test}, caller: ({caller.displayName}, {caller.playerId}), DebugArray: {testArray[0]}, {testArray[1]}, {testArray[2]}");
        }

        public override void Interact() {
            if (!Networking.IsOwner(gameObject))
                Networking.SetOwner(Networking.LocalPlayer, gameObject);

            USPPNET_Test("Hello there!",69, Networking.LocalPlayer, new []{ 1, 2 ,3 }); // only the owner of the object can send RPC calls, this method gets called on everyone but the caller
            RequestSerialization(); // if you're using manual (i recommend you do) you need to call RequestSerialization to send the RPC
        }

        // Comments that start with USPPNet are important for it to work, don't remove these, or the PreProcessor won't be able to generate the code
        public override void OnDeserialization() {
            // USPPNet OnDeserialization
            
            // your code here
        }

        public override void OnPostSerialization(SerializationResult result) {
            // USPPNet OnPostSerialization
            
            // your code here
            Debug.Log(bytesSent);
        }
        
        public override void OnPreSerialization() {
            // USPPNet OnPreSerialization
            
            // your code here
        }

        // USPPNet Init
    }
}

```

# Known Issues
1. Serialization doesn't support nested arrays.
2. Trying to call USPPNET_[FUNC NAME] on a Component other than itself will not be networked, and get called on the local client instead. you can use USPPNet_RPC(nameof(function), param1, param2, ...); instead to call those functions remotely
3. Using function overloads will cause USPPNet to crash

# The TODO list
fix calling USPPNET functions on other components
