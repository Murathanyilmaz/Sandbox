using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using NAudio.CoreAudioApi;
using System.Collections.Generic;

namespace Sandbox {
    public partial class Form1 : Form {
        // KEYBOARD HOOKS
        [DllImport("user32.dll")] public static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hMod, uint dwThreadId);
        [DllImport("user32.dll")] public static extern bool UnhookWindowsHookEx(IntPtr hhk);
        [DllImport("user32.dll")] public static extern int CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")] public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);
        [DllImport("user32.dll")] public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")] public static extern bool SetForegroundWindow(IntPtr focusWindow);
        [DllImport("user32.dll", CharSet = CharSet.Auto)] public static extern uint MapVirtualKey(uint uCode, uint uMapType);

        private const int WH_KEYBOARD_LL = 13; //Low-level keyboard hook
        private const int WM_KEYDOWN = 0x0100; //0X0101 KEYUP
        private IntPtr hookHandle = IntPtr.Zero;
        private HookProc hookProcDelegate; //SO IT LIVES WITH FORM
        public delegate int HookProc(int nCode, IntPtr wParam, IntPtr lParam); //PUBLIC
        //MY VARIABLES
        private static bool canFish = false;
        private static bool isStarted = false;
        private static int bindingKey = -1;
        private static int fishButton = 115;
        private static int intButton = 116;
        private static int currentDevice = 0;
        private static int counter = 0;

        //FORM SETTINGS
        public Form1() {
            InitializeComponent();
            hookProcDelegate = new HookProc(KeyboardHookProc);
            modeList.Items.Add("Automatic");
            modeList.Items.Add("Manual");
            modeList.SelectedIndex = 0;
            using (var enumerator = new MMDeviceEnumerator()) {
                var devices = enumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active).ToList();
                foreach (var device in devices) {
                    deviceList.Items.Add(device);
                }
                deviceList.SelectedIndex = 0;
            }
        }
        private void Form1_Load(object sender, EventArgs e) {

        }
        //LOADS FORM AND STARTS HOOK
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e); //Does the Form1_Load
            hookHandle = SetWindowsHookEx(WH_KEYBOARD_LL, hookProcDelegate, IntPtr.Zero, 0);
        }
        //UNHOOKS WHEN FORM CLOSES
        protected override void OnFormClosing(FormClosingEventArgs e) {
            // Unhook the keyboard hook when the form is
            if (hookHandle != IntPtr.Zero) {
                UnhookWindowsHookEx(hookHandle);
            }
            base.OnFormClosing(e);
        }
        //VKCODE SPECIAL CASES
        public string GetSpecialKeyName(int vkCode) {
            switch (vkCode) {
                case 0x70: return "F1";
                case 0x71: return "F2";
                case 0x72: return "F3";
                case 0x73: return "F4";
                case 0x74: return "F5";
                case 0x75: return "F6";
                case 0x76: return "F7";
                case 0x77: return "F8";
                case 0x78: return "F9";
                case 0x79: return "F10";
                case 0x7A: return "F11";
                case 0x7B: return "F12";
                case 0x20: return "Space";
                case 0x09: return "Tab";
                case 0x10: return "Shift";
                case 0x11: return "Ctrl";
                case 0x12: return "Alt";
                case 0x1B: return "Esc";
                default: return null;
            }
        }
        //KEYBINDER
        private int KeyboardHookProc(int nCode, IntPtr wParam, IntPtr lParam) {
            if (bindingKey == -1) {
                //SKIPS
            }
            else {
                Console.WriteLine("Working");
                if (nCode >= 0 && wParam == (IntPtr) WM_KEYDOWN) {
                    int vkCode = Marshal.ReadInt32(lParam);
                    if (vkCode == 0x0D) { //Enter
                        return CallNextHookEx(hookHandle, nCode, wParam, lParam);
                    }
                    uint result = MapVirtualKey((uint)vkCode, 2);
                    if (bindingKey == 0) {
                        fishButton = vkCode;
                        if (GetSpecialKeyName(vkCode) != null) {
                            fishKey.Text = GetSpecialKeyName(vkCode);
                        }
                        else if (result != 0) {
                            fishKey.Text = ((char)result).ToString();
                        }
                    }
                    else if (bindingKey == 1) {
                        intButton = vkCode;
                        if (GetSpecialKeyName(vkCode) != null) {
                            intKey.Text = GetSpecialKeyName(vkCode);
                        }
                        else if (result != 0) {
                            intKey.Text = ((char)result).ToString();
                        }
                    }
                    bindingKey = -1;
                    EnablerDisabler();
                    fishKeyButton.Text = "Bind Fishing";
                    intKeyButton.Text = "Bind Interact";
                }
            }
            return CallNextHookEx(hookHandle, nCode, wParam, lParam);
        }
        //HOOK THE FISH - canFish

        private static async void HookFish() {
            Random random = new Random();
            //PRESS F5
            int rnd = random.Next(0203, 0886);
            await Task.Delay(rnd);
            keybd_event((byte)intButton, 0, 0x0000, UIntPtr.Zero);
            //PULL F5
            rnd = random.Next(0022, 0057);
            await Task.Delay(rnd);
            keybd_event((byte)intButton, 0, 0x0002, UIntPtr.Zero);
            Console.WriteLine("Hook Fish");
            //PRESS F4
            rnd = random.Next(1133, 2256);
            await Task.Delay(rnd);
            keybd_event((byte)fishButton, 0, 0x0000, UIntPtr.Zero);
            //PULL F4
            rnd = random.Next(0024, 0054);
            await Task.Delay(rnd);
            keybd_event((byte)fishButton, 0, 0x0002, UIntPtr.Zero);
            Console.WriteLine("Cast Hook");
            await Task.Delay(1000);
            canFish = true;
        }
        //LISTENER - isStarted // canFish
        private void Timer1_Tick(object sender, EventArgs e) {
            if (!isStarted) return;
            List<MMDevice> devices;
            using (var enumerator = new MMDeviceEnumerator()) {
                devices = enumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active).ToList();
            }
            counter++;
            if (counter > 150) {
                counter = 0;
                IntPtr focusWindow = FindWindow(null, "World of Warcraft");
                if (focusWindow != IntPtr.Zero) {
                    SetForegroundWindow(focusWindow);
                    HookFish();
                }
            }
            if (logSound.Checked) {
                Console.WriteLine(devices[currentDevice].AudioMeterInformation.MasterPeakValue);
            }
            if (devices[currentDevice].AudioMeterInformation.MasterPeakValue > 0.10 && canFish) {
                if (logSound.Checked) Console.WriteLine("Passed threshold");
                canFish = false;
                counter = 0;
                IntPtr focusWindow = FindWindow(null, "World of Warcraft");
                if (focusWindow != IntPtr.Zero) {
                    SetForegroundWindow(focusWindow);
                    HookFish();
                }
            }
        }
        //START BUTTON
        private void startButton_Click(object sender, EventArgs e) {
            EnablerDisabler();
            startButton.Enabled = !startButton.Enabled;
            isStarted = !isStarted;
            if (isStarted) {
                startButton.Text = "Stop";
                IntPtr focusWindow = FindWindow(null, "World of Warcraft");
                if (focusWindow != IntPtr.Zero) {
                    SetForegroundWindow(focusWindow);
                    HookFish();
                }
            }
            else {
                canFish = false;
                startButton.Text = "Start";
            }
        }
        //ENABLING-DISABLING OBJECTS
        private void EnablerDisabler() {
            modeList.Enabled = !modeList.Enabled;
            fishKeyButton.Enabled = !fishKeyButton.Enabled;
            intKeyButton.Enabled = !intKeyButton.Enabled;
            deviceList.Enabled = !deviceList.Enabled;
            volumeBar.Enabled = !volumeBar.Enabled;
            startButton.Enabled = !startButton.Enabled;
        }
        //KEY SELECTER
        private void fishKeyButton_Click(object sender, EventArgs e) {
            fishKeyButton.Text = "Press a key...";
            bindingKey = 0;
            EnablerDisabler();
        }
        private void intKeyButton_Click(object sender, EventArgs e) {
            intKeyButton.Text = "Press a key...";
            bindingKey = 1;
            EnablerDisabler();
        }
        //DEVICE SELECTER
        private void deviceList_SelectedIndexChanged(object sender, EventArgs e) {
            currentDevice = deviceList.SelectedIndex;
        }
    }
}

/*
Process[] processes = Process.GetProcesses();
foreach (Process p in processes) {
    if (!String.IsNullOrEmpty(p.MainWindowTitle)) {
        //p.CloseMainWindow() or Kill();
        comboBox1.Items.Add(p.MainWindowTitle);
    }
}
if (vkCode == (int)Keys.F5)
*/