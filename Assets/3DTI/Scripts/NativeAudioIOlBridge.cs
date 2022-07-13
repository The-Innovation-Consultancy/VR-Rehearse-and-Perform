using System;
using System.Runtime.InteropServices;

public static class NativeAudioIOBridge {
    #if UNITY_IOS && !UNITY_EDITOR
    private const string _dllName = "__Internal";
#else
    private const string _dllName = "lib3dtiUnity";
#endif

#if PLATFORM_ANDROID
    [DllImport (_dllName)]
    public static extern IntPtr getAudioEngineInstance();
#endif

    [DllImport(_dllName, EntryPoint = "UnityAudio_New")]
    public static extern IntPtr New (double sampleRate, int numSamples);

    [DllImport (_dllName, EntryPoint = "UnityAudio_Free")]
    public static extern void Free (IntPtr ctx);

    [DllImport (_dllName, EntryPoint = "UnityAudio_SetupAudioChannels")]
    public static extern void SetChannels (IntPtr ctx, int inChannels, int outChannels);

    [DllImport (_dllName, EntryPoint = "UnityAudio_SetBlockSize")]
    public static extern void SetBlockSize (IntPtr ctx, int blockSize);

    [DllImport (_dllName, EntryPoint = "UnityAudio_GetBlockSize")]
    public static extern int GetBlockSize (IntPtr ctx);

    [DllImport (_dllName, EntryPoint = "UnityAudio_GetSampleRate")]
    public static extern int GetSampleRate (IntPtr ctx);

    [DllImport (_dllName, EntryPoint = "UnityAudio_GetData")]
    public static extern int ProcessInterleaved (IntPtr ctx, [Out] float[] outBuffer, int numSamples);

    [DllImport (_dllName, EntryPoint = "UnityAudio_EnableProcessing")]
    public static extern void EnableProcessing (IntPtr ctx, bool enabled);

    [DllImport (_dllName, EntryPoint = "UnityAudio_EnableMicrophone")]
    public static extern void EnableMicrophone (IntPtr ctx, bool enabled);

    [DllImport (_dllName, EntryPoint = "UnityAudio_EnableTestNoise")]
    public static extern void EnableTestNoise (IntPtr ctx, bool enabled);

    [DllImport (_dllName, EntryPoint = "UnityAudio_SetProcessor")]
    public static extern int SetProcessor (IntPtr ctx, IntPtr processor);

    // public delegate void AudioCallback (IntPtr buffer, int numFrames, IntPtr userData);
}
