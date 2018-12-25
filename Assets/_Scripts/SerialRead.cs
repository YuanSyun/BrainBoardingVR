using UnityEngine;
using System.Collections;
using System.Threading;

using System.IO.Ports;

public class SerialRead : MonoBehaviour {

    private MySerialPortThread mythread;
	// Use this for initialization
	void Start () {
        mythread = new MySerialPortThread();
        new Thread(mythread.Run).Start();
	}
	
	// Update is called once per frame
	void Update () {


	}

    void OnApplicationQuit()
    {
        // 結束 Unity 關閉執行緒
        mythread.isRun = false;
    }
}

class MySerialPortThread
{
    public bool isRun = true;

    public void Run()
    {
        SerialPort port = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
        // 開啟 RS232
        port.Open();

        // 持續讀取 RS232
        while (isRun)
        {
            string read = port.ReadLine();
            if (read.Length != 0) MonoBehaviour.print("Serial " + read);
        }
    }

}
