using System;
using System.Runtime.InteropServices;

public static class BinauralBridge
{
    #if UNITY_IOS && !UNITY_EDITOR
    private const string _dllName = "__Internal";
#else
    private const string _dllName = "lib3dtiUnity";
#endif

    [DllImport (_dllName, EntryPoint = "UnityIOSAudioIO_new")]
    public static extern IntPtr New (double sampleRate, int numSamples);

    [DllImport (_dllName, EntryPoint = "UnityIOSAudioIO_init")]
    public static extern void Init (IntPtr ctx);

    [DllImport (_dllName, EntryPoint = "UnityIOSAudioIO_free")]
    public static extern void Free (IntPtr ctx);

    [DllImport (_dllName, EntryPoint = "UnityIOSAudioIO_setParameter")]
    public static extern void SetParameter (IntPtr ctx, [MarshalAs(UnmanagedType.LPStr)]string name,  float value);

    [DllImport (_dllName, EntryPoint = "UnityIOSAudioIO_processInlineInterleaved")]
    public static extern int ProcessInlineInterleaved (IntPtr ctx, [In] float[] inBuffer, int numSamples);

    [DllImport (_dllName, EntryPoint = "UnityIOSAudioIO_loadHRTF")]
    public static extern bool LoadHRTF (IntPtr ctx, [MarshalAs(UnmanagedType.LPStr)]string path);

    [DllImport (_dllName, EntryPoint = "UnityIOSAudioIO_loadHRTF_ILD")]
    public static extern bool LoadHRTF_ILD (IntPtr ctx, [MarshalAs(UnmanagedType.LPStr)]string path);

    [DllImport (_dllName, EntryPoint = "UnityIOSAudioIO_loadNearfieldILD")]
    public static extern bool LoadNearFieldILD (IntPtr ctx, [MarshalAs(UnmanagedType.LPStr)]string path);

    [DllImport (_dllName, EntryPoint = "UnityIOSAudioIO_loadBRIR")]
    public static extern bool LoadBRIR (IntPtr ctx, [MarshalAs(UnmanagedType.LPStr)]string path);

    [DllImport (_dllName, EntryPoint = "UnityIOSAudioIO_loadBundledBRIR")]
    public static extern bool LoadBundledBRIR (IntPtr ctx, int index);
}
