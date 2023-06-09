﻿#if UNITY_EDITOR && !COMPILER_UDONSHARP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEditor;

using USPPPatcher;

namespace USPPNet
{
    public class PreProcessorInstance
    {
        public Dictionary<string,string[]> functions;
    }
    
    public static class PreProcessorSnippits
    {
        #region Init
        public static string USPPNetInit = @"
    private int USPPNet_updateIndexLast = -1;
    [UdonSynced] private int USPPNet_updateIndex = -1;
    [UdonSynced] private string[] USPPNet_methods = Array.Empty<string>();

#if USPPNet_byte
    [UdonSynced] private byte[] USPPNet_args_byte = Array.Empty<byte>();
#endif
#if USPPNet_int
    [UdonSynced] private int[] USPPNet_args_int = Array.Empty<int>();
#endif
#if USPPNet_string
    [UdonSynced] private string[] USPPNet_args_string = Array.Empty<string>();
#endif
#if USPPNet_bool
    [UdonSynced] private bool[] USPPNet_args_bool = Array.Empty<bool>();
#endif
#if USPPNet_short
    [UdonSynced] private short[] USPPNet_args_short = Array.Empty<short>();
#endif
#if USPPNet_uint
    [UdonSynced] private uint[] USPPNet_args_uint = Array.Empty<uint>();
#endif
#if USPPNet_long
    [UdonSynced] private long[] USPPNet_args_long = Array.Empty<long>();
#endif
#if USPPNet_ulong
    [UdonSynced] private ulong[] USPPNet_args_ulong = Array.Empty<ulong>();
#endif
#if USPPNet_float
    [UdonSynced] private float[] USPPNet_args_float = Array.Empty<float>();
#endif
#if USPPNet_double
    [UdonSynced] private double[] USPPNet_args_double = Array.Empty<double>();
#endif
#if USPPNet_Vector2
    [UdonSynced] private Vector2[] USPPNet_args_Vector2 = Array.Empty<Vector2>();
#endif
#if USPPNet_Vector3
    [UdonSynced] private Vector3[] USPPNet_args_Vector3 = Array.Empty<Vector3>();
#endif
#if USPPNet_Vector4
    [UdonSynced] private Vector4[] USPPNet_args_Vector4 = Array.Empty<Vector4>();
#endif
#if USPPNet_Quaternion
    [UdonSynced] private Quaternion[] USPPNet_args_Quaternion = Array.Empty<Quaternion>();
#endif
#if USPPNet_VRCUrl
    [UdonSynced] private VRCUrl[] USPPNet_args_VRCUrl = Array.Empty<VRCUrl>();
#endif
#if USPPNet_Color
    [UdonSynced] private Color[] USPPNet_args_Color = Array.Empty<Color>();
#endif
    
    private byte[] USPPNet_args_byte_empty = Array.Empty<byte>();
    private int[] USPPNet_args_int_empty = Array.Empty<int>();
    private string[] USPPNet_args_string_empty = Array.Empty<string>();
    private bool[] USPPNet_args_bool_empty = Array.Empty<bool>();
    private short[] USPPNet_args_short_empty = Array.Empty<short>();
    private uint[] USPPNet_args_uint_empty = Array.Empty<uint>();
    private long[] USPPNet_args_long_empty = Array.Empty<long>();
    private ulong[] USPPNet_args_ulong_empty = Array.Empty<ulong>();
    private float[] USPPNet_args_float_empty = Array.Empty<float>();
    private double[] USPPNet_args_double_empty = Array.Empty<double>();
    private Vector2[] USPPNet_args_Vector2_empty = Array.Empty<Vector2>();
    private Vector3[] USPPNet_args_Vector3_empty = Array.Empty<Vector3>();
    private Vector4[] USPPNet_args_Vector4_empty = Array.Empty<Vector4>();
    private Quaternion[] USPPNet_args_Quaternion_empty = Array.Empty<Quaternion>();
    private VRCUrl[] USPPNet_args_VRCUrl_empty = Array.Empty<VRCUrl>();
    private Color[] USPPNet_args_Color_empty = Array.Empty<Color>();
    
    private string[] USPPNet_methods_empty = Array.Empty<string>();
    private int[] USPPNet_args_empty = Array.Empty<int>();

        private void USPPNet_RPC(string method, params object[] args)
    {
        USPPNet_updateIndex++;
        
        USPPNet_methods = USPPNet_methods.USPPNet_AppendArray(method);

        foreach (var arg in args)
        {
            var argType = arg.GetType();

#if USPPNet_byte
            if (argType == typeof(byte))
                USPPNet_args_byte = USPPNet_args_byte.USPPNet_AppendArray(arg);
#endif
#if USPPNet_int
            if (argType == typeof(int))
                USPPNet_args_int = USPPNet_args_int.USPPNet_AppendArray(arg);
#endif
#if USPPNet_string
            if (argType == typeof(string))
                USPPNet_args_string = USPPNet_args_string.USPPNet_AppendArray(arg);
#endif
#if USPPNet_bool
            if (argType == typeof(bool))
                USPPNet_args_bool = USPPNet_args_bool.USPPNet_AppendArray(arg);
#endif
#if USPPNet_short
            if (argType == typeof(short))
                USPPNet_args_short = USPPNet_args_short.USPPNet_AppendArray(arg);
#endif
#if USPPNet_uint
            if (argType == typeof(uint))
                USPPNet_args_uint = USPPNet_args_uint.USPPNet_AppendArray(arg);
#endif
#if USPPNet_long
            if (argType == typeof(long))
                USPPNet_args_long = USPPNet_args_long.USPPNet_AppendArray(arg);
#endif
#if USPPNet_ulong
            if (argType == typeof(ulong))
                USPPNet_args_ulong = USPPNet_args_ulong.USPPNet_AppendArray(arg);
#endif
#if USPPNet_float
            if (argType == typeof(float))
                USPPNet_args_float = USPPNet_args_float.USPPNet_AppendArray(arg);
#endif
#if USPPNet_double
            if (argType == typeof(double))
                USPPNet_args_double = USPPNet_args_double.USPPNet_AppendArray(arg);
#endif
#if USPPNet_Vector2
            if (argType == typeof(Vector2))
                USPPNet_args_Vector2 = USPPNet_args_Vector2.USPPNet_AppendArray(arg);
#endif
#if USPPNet_Vector3
            if (argType == typeof(Vector3))
                USPPNet_args_Vector3 = USPPNet_args_Vector3.USPPNet_AppendArray(arg);
#endif
#if USPPNet_Vector4
            if (argType == typeof(Vector4))
                USPPNet_args_Vector4 = USPPNet_args_Vector4.USPPNet_AppendArray(arg);
#endif
#if USPPNet_Quaternion
            if (argType == typeof(Quaternion))
                USPPNet_args_Quaternion = USPPNet_args_Quaternion.USPPNet_AppendArray(arg);
#endif
#if USPPNet_VRCUrl
            if (argType == typeof(VRCUrl))
                USPPNet_args_VRCUrl = USPPNet_args_VRCUrl.USPPNet_AppendArray(arg);
#endif
#if USPPNet_Color
            if (argType == typeof(Color))
                USPPNet_args_Color = USPPNet_args_Color.USPPNet_AppendArray(arg);
#endif
        }
    }
";
        #endregion

        #region OnPostSerialization
        public static string USPPNetOnPostSerialization = @"if (result.success)
        {
            Debug.Log($""Sent: {result.byteCount}"");
    USPPNet_methods = USPPNet_methods_empty; 
            
#if USPPNet_byte
            USPPNet_args_byte = USPPNet_args_byte_empty;
#endif
#if USPPNet_int
            USPPNet_args_int = USPPNet_args_int_empty;
#endif
#if USPPNet_string
            USPPNet_args_string = USPPNet_args_string_empty;
#endif
#if USPPNet_bool
            USPPNet_args_bool = USPPNet_args_bool_empty;
#endif
#if USPPNet_short
            USPPNet_args_short = USPPNet_args_short_empty;
#endif
#if USPPNet_uint
            USPPNet_args_uint = USPPNet_args_uint_empty;
#endif
#if USPPNet_long
            USPPNet_args_long = USPPNet_args_long_empty;
#endif
#if USPPNet_ulong
            USPPNet_args_ulong = USPPNet_args_ulong_empty;
#endif
#if USPPNet_float
            USPPNet_args_float = USPPNet_args_float_empty;
#endif
#if USPPNet_double
            USPPNet_args_double = USPPNet_args_double_empty;
#endif
#if USPPNet_Vector2
            USPPNet_args_Vector2 = USPPNet_args_Vector2_empty;
#endif
#if USPPNet_Vector3
            USPPNet_args_Vector3 = USPPNet_args_Vector3_empty;
#endif
#if USPPNet_Vector4
            USPPNet_args_Vector4 = USPPNet_args_Vector4_empty;
#endif
#if USPPNet_Quaternion
            USPPNet_args_Quaternion = USPPNet_args_Quaternion_empty;
#endif
#if USPPNet_VRCUrl
            USPPNet_args_VRCUrl = USPPNet_args_VRCUrl_empty;
#endif
#if USPPNet_Color
            USPPNet_args_Color = USPPNet_args_Color_empty;
#endif
}";
        #endregion

        #region OnDeserialization
        public static string USPPNetOnDeserialization = @"
        int USPPNet_args_byte_offset = 0;
        int USPPNet_args_int_offset = 0;
        int USPPNet_args_string_offset = 0;
        int USPPNet_args_bool_offset = 0;
        int USPPNet_args_short_offset = 0;
        int USPPNet_args_uint_offset = 0;
        int USPPNet_args_long_offset = 0;
        int USPPNet_args_ulong_offset = 0;
        int USPPNet_args_float_offset = 0;
        int USPPNet_args_double_offset = 0;
        int USPPNet_args_Vector2_offset = 0;
        int USPPNet_args_Vector3_offset = 0;
        int USPPNet_args_Vector4_offset = 0;
        int USPPNet_args_Quaternion_offset = 0;
        int USPPNet_args_VRCUrl_offset = 0;
        int USPPNet_args_Color_offset = 0;
        
        if (USPPNet_updateIndexLast != USPPNet_updateIndex)
        {
            for (var call = 0; call < USPPNet_methods.Length; call++)
            {
                var method = USPPNet_methods[call];

                // USPPNet TEMP REPLACE ME!!!
            }
        }

        USPPNet_updateIndexLast = USPPNet_updateIndex;";
        #endregion
    }
    
    public static class PreProcessor
    {
        private static string RemoveNewLines(string code)
        {
            return code.Replace('\n', ' ');
        }
        
        private static string StripComments(string code)
        {
            var re = @"(@(?:""[^""]*"")+|""(?:[^""\n\\]+|\\.)*""|'(?:[^'\n\\]+|\\.)*')|//.*|/\*(?s:.*?)\*/";
            return Regex.Replace(code, re, "$1");
        }
        private static string[] StripComments(string[] code)
        {
            for (var i = 0; i < code.Length; i++)
            {
                code[i] = StripComments(code[i]);
            }
            return code;
        }

        private static void get_USPPNet_Functions(string[] lines, ref Dictionary<string, string[]> functions)
        {
            functions = new Dictionary<string, string[]>();
            
            foreach (var line in lines)
            {
                var l = StripComments(line);
                var start = l.IndexOf("void USPPNET_", StringComparison.Ordinal);
                if (start == -1) // check if line is USPPNET function
                    continue;

                var argsStart = l.IndexOf("(", start+5, StringComparison.Ordinal)+1;
                var argsEnd = l.IndexOf(")", argsStart, StringComparison.Ordinal);

                var argsSubstring = l.Substring(argsStart, argsEnd - argsStart);

                var args = argsSubstring.Split(',');
                var functionArgs = new string[args.Length];
                for (var index = 0; index < args.Length; index++) // adds function argument types to dict
                {
                    var split = args[index].Split(' ');
                    split = split.Where(x => !string.IsNullOrEmpty(x)).ToArray(); // remove blank strings
                    functionArgs[index] = split[0];
                }

                var functionName = l.Substring(start+5, argsStart-(start+6));
                
                //Debug.Log($"Function: {functionName}, arg types: {ObjectDumper.Dump(functionArgs)}");
                
                functions.Add(functionName, functionArgs);
                
            }
        }
        
        /*
         * Turns USPPNET_Test("Hello there!", 69);
         * Into USPPNet_RPC("USPPNET_Test", "Hello there!", 69);
         */
        private static string[] replace_USPPNet_Calls(this string[] lines, ref Dictionary<string, string[]> functions)
        {
            var functionNames = functions.Keys.ToArray();

            var lineNum = 0;

            for (var index = 0; index < lines.Length; index++)
            {
                var line = lines[index];
                lineNum++;
                var l = StripComments(line);
                if (!functionNames.Any(c => l.Contains(c)))
                    continue;
                if (!l.Contains(");"))
                    continue;


                var namestart = l.IndexOf("USPPNET_", StringComparison.Ordinal);
                var nameEnd = l.IndexOf("(", namestart, StringComparison.Ordinal);
                var functionEnd = l.IndexOf(";", nameEnd, StringComparison.Ordinal);

                var functionName = l.Substring(namestart, nameEnd - namestart);
                var function = l.Substring(namestart, nameEnd - namestart + 1);

                lines[index] = l.Replace(function, $"USPPNet_RPC(\"{functionName}\", ");

                //Debug.Log($"Line: {lineNum}, Line: {lines[index]}");
                //break; // remember to remove
            }

            return lines;
        }

        private static string create_OnDeserialization_MethodCall(ref Dictionary<string, string[]> functions)
        {
            var tempIf = "";

            var functionNames = functions.Keys.ToArray();
            
            
            foreach (var func in functionNames)
            {
                var tempArgs = "";
                var argindex = new Dictionary<string, int>();
                for (var index = 0; index < functions[func].Length; index++)
                {
                    var argType = functions[func][index];
                    if (index > 0)
                        tempArgs += ", ";

                    int offset;
                    if (!argindex.ContainsKey(argType))
                    {
                        offset = 0;
                        argindex.Add(argType, 1);
                    }
                    else
                    {
                        offset = argindex[argType];
                        argindex[argType]++;
                    }

                    tempArgs += $"USPPNet_args_{argType}[USPPNet_args_{argType}_offset + {offset}]";
                    
                }

                tempIf += $@"
                if(method == ""{func}"") "+"{"+$@"
                    {func}({tempArgs});
                    USPPNet_args_byte_offset += {functions[func].Count(s => s == "byte" )};
                    USPPNet_args_int_offset += {functions[func].Count(s => s == "int" )};
                    USPPNet_args_string_offset += {functions[func].Count(s => s == "string" )};
                    USPPNet_args_bool_offset += {functions[func].Count(s => s == "bool" )};
                    USPPNet_args_short_offset += {functions[func].Count(s => s == "short" )};
                    USPPNet_args_uint_offset += {functions[func].Count(s => s == "uint" )};
                    USPPNet_args_long_offset += {functions[func].Count(s => s == "long" )};
                    USPPNet_args_ulong_offset += {functions[func].Count(s => s == "ulong" )};
                    USPPNet_args_float_offset += {functions[func].Count(s => s == "float" )};
                    USPPNet_args_double_offset += {functions[func].Count(s => s == "double" )};
                    USPPNet_args_Vector2_offset += {functions[func].Count(s => s == "Vector2" )};
                    USPPNet_args_Vector3_offset += {functions[func].Count(s => s == "Vector3" )};
                    USPPNet_args_Vector4_offset += {functions[func].Count(s => s == "Vector4" )};
                    USPPNet_args_Quaternion_offset += {functions[func].Count(s => s == "Quaternion" )};
                    USPPNet_args_VRCUrl_offset += {functions[func].Count(s => s == "VRCUrl" )};
                    USPPNet_args_Color_offset += {functions[func].Count(s => s == "Color" )};
                "+"}\n"; // Hate it, but it's finneeee, probably also slow, but i'm too lazy to do it *smartly*
            }

            return RemoveNewLines(tempIf);
        }

        private static bool Uses_USPPNet(ref string prog)
        {
            return prog.Contains("using USPPNet;");
        }

        private static string[] replace_Placeholder_Comments(this string[] lines, ref Dictionary<string, string[]> functions)
        {
            var methcall = create_OnDeserialization_MethodCall(ref functions);
            //Debug.Log("Goobed:"+methcall);
            
            for (var i = 0; i < lines.Length; i++)
            {
                lines[i] = lines[i].Replace("// USPPNet Init",  PreProcessorSnippits.USPPNetInit);
                lines[i] = lines[i].Replace("// USPPNet OnPostSerialization",  PreProcessorSnippits.USPPNetOnPostSerialization);
                lines[i] = lines[i].Replace("// USPPNet OnDeserialization",  RemoveNewLines(PreProcessorSnippits.USPPNetOnDeserialization));
                lines[i] = lines[i].Replace("// USPPNet TEMP REPLACE ME!!!",  methcall);
            }
            
            return lines;
        }

        private static string Parse(string prog, PPInfo info)
        {
            if (!Uses_USPPNet(ref prog))
                return prog;

            PreProcessorInstance inst = new PreProcessorInstance();
            var lines = prog.Split(new [] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            get_USPPNet_Functions(lines, ref inst.functions);

            lines = lines.replace_USPPNet_Calls(ref inst.functions).replace_Placeholder_Comments(ref inst.functions);

            prog = lines.Aggregate("", (current, line) => current + line + "\n");
            //Debug.Log(prog); // Uncomment to get program after parsing

            return prog;
        }

        [InitializeOnLoadMethod]
        private static void Subscribe()
        {
            PPHandler.Subscribe(Parse, 1, "USPPNet");
        }
    }
}
#endif  