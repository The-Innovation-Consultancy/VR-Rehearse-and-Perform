package com.reactify.NativeAudio;

import android.content.Context;
import android.net.Uri;
import android.view.ViewGroup;

import java.lang.ref.WeakReference;

public class UnityAudio
{
    //==============================================================================
    static
    {
        System.loadLibrary("3dtiUnity");
    }

    //==============================================================================
    public UnityAudio(Context context)
    {
        super();
        constructAudioEngine(context);
    }

    @Override
    public void finalize() throws java.lang.Throwable
    {
        destroyAudioEngine();
        super.finalize();
    }

    //==============================================================================
    public native void setupAudioChannels(int inChannels, int outChannels);

    //==============================================================================
    private native void constructAudioEngine(Context context);
    private native void destroyAudioEngine();

    public long getCppInstance() { return cppCounterpartInstance; }

    //==============================================================================
    private long cppCounterpartInstance = 0;
};

