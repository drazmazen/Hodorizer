﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hodor.Libraries
{
    using System;
    using System.Runtime.InteropServices;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace CSharpHodor
    {

        public static class ScanCode
        {
            public static ushort X = 0x2D;
            public static ushort Y = 0x15;
            public static ushort H = 35;
            public static ushort O = 24;
            public static ushort D = 32;
            public static ushort R = 19;
            public static ushort Space = 57;
            public static ushort Backspace = 14;
            public static ushort Escape = 0x01;
            public static ushort Enter = 28;
        }


        public class Interception
        {
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate int Predicate(int device);

            [Flags]
            public enum KeyState
            {
                Down = 0x00,
                Up = 0x01,
                E0 = 0x02,
                E1 = 0x04,
                TermsrvSetLED = 0x08,
                TermsrvShadow = 0x10,
                TermsrvVKPacket = 0x20
            }

            [Flags]
            public enum Filter : ushort
            {
                None = 0x0000,
                All = 0xFFFF,
                KeyDown = KeyState.Up,
                KeyUp = KeyState.Up << 1,
                KeyE0 = KeyState.E0 << 1,
                KeyE1 = KeyState.E1 << 1,
                KeyTermsrvSetLED = KeyState.TermsrvSetLED << 1,
                KeyTermsrvShadow = KeyState.TermsrvShadow << 1,
                KeyTermsrvVKPacket = KeyState.TermsrvVKPacket << 1
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct MouseStroke
            {
                public ushort state;
                public ushort flags;
                public short rolling;
                public int x;
                public int y;
                public uint information;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct KeyStroke
            {
                public ushort code;
                public ushort state;
                public uint information;
            }

            [StructLayout(LayoutKind.Explicit)]
            public struct Stroke
            {
                [FieldOffset(0)]
                public MouseStroke mouse;

                [FieldOffset(0)]
                public KeyStroke key;
            }

            [DllImport("interception.dll", EntryPoint = "interception_create_context", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr CreateContext();

            [DllImport("interception.dll", EntryPoint = "interception_destroy_context", CallingConvention = CallingConvention.Cdecl)]
            public static extern void DestroyContext(IntPtr context);

            [DllImport("interception.dll", EntryPoint = "interception_set_filter", CallingConvention = CallingConvention.Cdecl)]
            public static extern void SetFilter(IntPtr context, Predicate predicate, Filter filter);

            [DllImport("interception.dll", EntryPoint = "interception_receive", CallingConvention = CallingConvention.Cdecl)]
            public static extern int Receive(IntPtr context, int device, ref Stroke stroke, uint nstroke);

            [DllImport("interception.dll", EntryPoint = "interception_send", CallingConvention = CallingConvention.Cdecl)]
            public static extern int Send(IntPtr context, int device, ref Stroke stroke, uint nstroke);

            [DllImport("interception.dll", EntryPoint = "interception_is_keyboard", CallingConvention = CallingConvention.Cdecl)]
            public static extern int IsKeyboard(int device);

            [DllImport("interception.dll", EntryPoint = "interception_wait", CallingConvention = CallingConvention.Cdecl)]
            public static extern int Wait(IntPtr context);
        }
    }

}
