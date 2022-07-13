
package com.innovationagency.VRRehearsePerform;

import android.os.Bundle;
import com.unity3d.player.UnityPlayerActivity;
import com.reactify.NativeAudio.UnityAudio;

public class VRRehearsePerformActivity extends UnityPlayerActivity {

    protected UnityAudio audioEngine = null;
    
    protected void onCreate(Bundle savedInstanceState) {
        
        // Initialise audio engine before Unity player
        audioEngine = new UnityAudio(this);

        super.onCreate (savedInstanceState);
    }
}